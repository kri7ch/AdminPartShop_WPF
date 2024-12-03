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
        private void LoadProducts()
        {
            list_view_products.Items.Clear();
            string path = "C:\\Users\\rakhm\\source\\repos\\AdminPartShop\\AdminPartShop\\JsonFiles\\products.json";
            string json = File.ReadAllText(path);
            allProducts = JsonConvert.DeserializeObject<List<Products>>(json);

            foreach (var product in allProducts)
            {
                var productControl = new Product_card();
                productControl.SetProductData(product);

                productControl.EditButtonClicked += ProductControl_EditButtonClicked;

                list_view_products.Items.Add(productControl);
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = searchTextBox.Text.ToLower();
            list_view_products.Items.Clear();

            var filteredProducts = allProducts.Where(p => p.Name_Product.ToLower().Contains(searchText)).ToList();

            foreach (var product in filteredProducts)
            {
                var productControl = new Product_card();
                productControl.SetProductData(product);

                productControl.EditButtonClicked += ProductControl_EditButtonClicked;

                list_view_products.Items.Add(productControl);
            }

            if (list_view_products.Items.Count == 0)
            {
                tovar_ne_naiden.Visibility = Visibility.Visible;
            }
            else
            {
                tovar_ne_naiden.Visibility = Visibility.Hidden;
            }
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (categoryComboBox.SelectedItem != null)
            {
                var selectedCategory = (categoryComboBox.SelectedItem as ComboBoxItem)?.Tag.ToString();
                FilterProductsByCategory(selectedCategory);
            }
        }

        private void FilterProductsByCategory(string categoryID)
        {
            list_view_products.Items.Clear();

            var filteredProducts = allProducts;

            if (categoryID != "0")
            {
                int categoryInt = int.Parse(categoryID);
                filteredProducts = allProducts
                    .Where(p => p.CategoryID == categoryInt)
                    .ToList();
            }

            foreach (var product in filteredProducts)
            {
                var productControl = new Product_card();
                productControl.SetProductData(product);

                productControl.EditButtonClicked += ProductControl_EditButtonClicked;

                list_view_products.Items.Add(productControl);
            }
        }
        private void PriceFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (priceFilterComboBox.SelectedItem != null)
            {
                var selectedPriceFilter = (priceFilterComboBox.SelectedItem as ComboBoxItem)?.Tag.ToString();
                FilterProductsByPrice(selectedPriceFilter);
            }
        }

        private void FilterProductsByPrice(string priceFilter)
        {
            list_view_products.Items.Clear();

            var filteredProducts = allProducts;

            if (categoryComboBox.SelectedItem != null)
            {
                var selectedCategory = (categoryComboBox.SelectedItem as ComboBoxItem)?.Tag.ToString();
                if (selectedCategory != "0")
                {
                    int categoryInt = int.Parse(selectedCategory);
                    filteredProducts = filteredProducts
                        .Where(p => p.CategoryID == categoryInt)
                        .ToList();
                }
            }

            if (priceFilter != "0")
            {
                if (priceFilter == "1")
                {
                    filteredProducts = filteredProducts.OrderBy(p => ParsePrice(p.Price)).ToList();
                }
                else if (priceFilter == "2")
                {
                    filteredProducts = filteredProducts.OrderByDescending(p => ParsePrice(p.Price)).ToList();
                }
                else if (priceFilter == "3")
                {
                    filteredProducts = filteredProducts.Where(p => p.Rating >= 1 && p.Rating <= 5).OrderBy(p => p.Rating).ToList();
                }
                else if (priceFilter == "4")
                {
                    filteredProducts = filteredProducts.Where(p => p.Rating >= 1 && p.Rating <= 5).OrderByDescending(p => p.Rating).ToList();
                }
            }

            foreach (var product in filteredProducts)
            {
                var productControl = new Product_card();
                productControl.SetProductData(product);

                productControl.EditButtonClicked += ProductControl_EditButtonClicked;
                list_view_products.Items.Add(productControl);
            }
        }

        private decimal ParsePrice(string priceText)
        {
            var match = Regex.Match(priceText, @"\d+");
            if (match.Success)
            {
                return decimal.Parse(match.Value);
            }
            return 0;
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
