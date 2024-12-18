using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text.RegularExpressions;
using AdminPartShop.Models;
using AdminPartShop.Windows;
using System.Net.Http;

namespace AdminPartShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main_Shop_Window.xaml
    /// </summary>
    public partial class Main_Shop_Window : Page
    {
        private int currentUserId;
        private List<Products> allProducts;
        public Main_Shop_Window(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            LoadProducts();
            categoryComboBox.SelectedIndex = 0;
            priceFilterComboBox.SelectedIndex = 0;
        }
        private async void LoadProducts()
        {
            string url = "http://localhost:5140/api/Product/All Products";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        List<Products> products = JsonConvert.DeserializeObject<List<Products>>(jsonResponse);

                        list_view_products.Items.Clear();

                        foreach (var product in products)
                        {
                            var productControl = new Product_card();
                            productControl.SetProductData(product);

                            productControl.EditButtonClicked += ProductControl_EditButtonClicked;
                            list_view_products.Items.Add(productControl);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при загрузке товаров: " + response.ReasonPhrase);
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"HTTP Request Error: {ex.Message}");
                }
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = searchTextBox.Text.ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                SearchProducts(searchText);
                tovar_ne_naiden.Visibility = Visibility.Visible;
            }
            else
            {
                LoadProducts();
                tovar_ne_naiden.Visibility = Visibility.Hidden;
            }
        }


        private async void SearchProducts(string searchText)
        {
            string url = $"http://localhost:5140/api/Product/Search?query={searchText}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var filteredProducts = JsonConvert.DeserializeObject<List<Products>>(jsonResponse);
                        UpdateProductList(filteredProducts);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при выполнении поиска: " + response.ReasonPhrase);
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"HTTP Request Error: {ex.Message}");
                }
            }
        }

        private void UpdateProductList(List<Products> products)
        {
            list_view_products.Items.Clear();
            foreach (var product in products)
            {
                var productControl = new Product_card();
                productControl.SetProductData(product);
                productControl.EditButtonClicked += ProductControl_EditButtonClicked;
                list_view_products.Items.Add(productControl);
            }
        }

        private async void FilterProducts(int categoryId, string priceFilter)
        {
            string url = $"http://localhost:5140/api/Product/Filter?categoryId={categoryId}&priceFilter={priceFilter}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var filteredProducts = JsonConvert.DeserializeObject<List<Products>>(jsonResponse);
                        UpdateProductList(filteredProducts);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при применении фильтров: " + response.ReasonPhrase);
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"HTTP Request Error: {ex.Message}");
                }
            }
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (categoryComboBox.SelectedItem != null)
            {
                var selectedCategory = (categoryComboBox.SelectedItem as ComboBoxItem)?.Tag.ToString();
                int categoryId = int.Parse(selectedCategory);

                if (categoryId != 0)
                {
                    var selectedPriceFilter = priceFilterComboBox.SelectedItem != null ? (priceFilterComboBox.SelectedItem as ComboBoxItem)?.Tag.ToString(): null;
                    FilterProducts(categoryId, selectedPriceFilter);
                }
                else
                {
                    LoadProducts();
                }
            }
        }

        private void PriceFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (priceFilterComboBox.SelectedItem != null)
            {
                var selectedPriceFilter = (priceFilterComboBox.SelectedItem as ComboBoxItem)?.Tag.ToString();
                var selectedCategory = (categoryComboBox.SelectedItem as ComboBoxItem)?.Tag.ToString();
                int categoryId = int.Parse(selectedCategory);
                FilterProducts(categoryId, selectedPriceFilter);
            }
        }

        private void ProductControl_EditButtonClicked(object sender, RoutedEventArgs e)
        {
            var productControl = sender as Product_card;
            if (productControl != null)
            {
                var product = GetProductByName(productControl.NameTextBlock.Text);

                if (product != null)
                {
                    Redactor_Card redactorCard = new Redactor_Card(product);
                    redactorCard.OnProductCreated = LoadProducts;
                    redactorCard.ShowDialog();
                }
            }
        }

        private Products GetProductByName(string productName)
        {
            string path = "C:\\Users\\rakhm\\source\\repos\\AdminPartShop\\AdminPartShop\\JsonFiles\\products.json";
            string json = File.ReadAllText(path);
            List<Products> all_product_json = JsonConvert.DeserializeObject<List<Products>>(json);
            return all_product_json.FirstOrDefault(p => p.Name_Product == productName);
        }

        public void Profile_Page()
        {
            var window = Window.GetWindow(this);
            window.Title = "Профиль";
            NavigationService.Navigate(new Profile_Page(currentUserId));
        }

        private void Hyperlink_Click_Profile(object sender, RoutedEventArgs e)
        {
            Profile_Page();
        }

        private void btn_add_product_Click(object sender, RoutedEventArgs e)
        {
            Redactor_Card redactorCard = new Redactor_Card();
            redactorCard.OnProductCreated = LoadProducts;
            redactorCard.ShowDialog();
        }
    }
}
