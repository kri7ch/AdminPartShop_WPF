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
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using Newtonsoft.Json;
using AdminPartShop.Models;
using System.Net.Http.Headers;
using System.Net.Http;

namespace AdminPartShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для Redactor_Card.xaml
    /// </summary>
    public partial class Redactor_Card : Window
    {
        public Action OnProductCreated;

        public event RoutedEventHandler EditButtonClicked;

        public string ImagePath { get; private set; }

        public string ProductName { get; private set; }

        private bool IsEditing = false;

        private bool Existing = false;

        private int productId;

        private bool Del = false;
        public string path = "C:\\Users\\rakhm\\source\\repos\\AdminPartShop\\AdminPartShop\\JsonFiles\\products.json";
        public Redactor_Card(Products product = null)
        {
            InitializeComponent();
            ProductImage.MouseLeftButtonDown += ProductImage_MouseLeftButtonDown;
            btn_redact.Click += BtnRedact_Click;

            if (product != null)
            {
                IsEditing = true;
                productId = product.Id;
                textbox_name.Text = product.Name_Product;
                textbox_price.Text = product.Price;
                textbox_count.Text = product.Count_Product.ToString();
                textbox_description.Text = product.Description;
                textbox_category_id.Text = product.CategoryID.ToString();
                ImagePath = product.ImagePath;
                ProductImage.Source = new BitmapImage(new Uri(ImagePath));
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditButtonClicked?.Invoke(this, e);
        }

        private void ProductImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Image Files (*.png)|*.png",
                    Title = "Выберите изображение товара"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    ProductImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                    ImagePath = openFileDialog.FileName;
                }
            }
            catch(Exception) 
            {
                MessageBox.Show("Выберите фотографию с верным форматом!");
                return;
            }
        }

        private async Task AddProduct(Products product)
        {
            product.ImageBase64 = ConvertImageToBase64(product.ImagePath);
            using (HttpClient client = new HttpClient())
            {
                string url = "http://localhost:5140/api/Product/Add";
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var json = JsonConvert.SerializeObject(product);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Товар успешно добавлен!");
                }
                else
                {
                    MessageBox.Show($"Ошибка: {response.ReasonPhrase}");
                }
            }
        }

        private async Task UpdateProduct(int id, Products product)
        {
            product.ImageBase64 = ConvertImageToBase64(product.ImagePath);
            using (HttpClient client = new HttpClient())
            {
                string url = $"http://localhost:5140/api/Product/Update/{id}";
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var json = JsonConvert.SerializeObject(product);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Товар успешно обновлён!");
                }
                else
                {
                    MessageBox.Show($"Ошибка: {response.ReasonPhrase}");
                }
            }
        }

        private string ConvertImageToBase64(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                return Convert.ToBase64String(imageBytes);
            }
            return null;
        }

        private async void BtnRedact_Click(object sender, RoutedEventArgs e)
        {
            var product = new Products
            {
                Id = IsEditing ? productId : 0,
                Name_Product = textbox_name.Text,
                Price = textbox_price.Text,
                Count_Product = int.Parse(textbox_count.Text),
                Description = textbox_description.Text,
                ImagePath = ImagePath,
                CategoryID = int.Parse(textbox_category_id.Text)
            };

            try
            {
                if (IsEditing)
                {
                    await UpdateProduct(product.Id, product);
                }
                else
                {
                    await AddProduct(product);
                }

                OnProductCreated?.Invoke();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private bool IsValidProductName(string name)
        {
            return name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        private bool IsValidCategory(string categoryId)
        {
            return int.TryParse(categoryId, out int category) && (category == 1 || category == 2);
        }

        private void SaveProductToFile(Products product)
        {
            List<Products> allProducts;

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                allProducts = JsonConvert.DeserializeObject<List<Products>>(json);
            }
            else
            {
                allProducts = new List<Products>();
            }

            allProducts.Add(product);

            string newJson = JsonConvert.SerializeObject(allProducts, Formatting.Indented);
            File.WriteAllText(path, newJson);
        }

        private void UpdateProductInFile(Products updatedProduct)
        {
            string json = File.ReadAllText(path);
            List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(json);

            var existingProduct = allProducts.FirstOrDefault(p => p.Name_Product == updatedProduct.Name_Product);
            if (existingProduct != null)
            {
                existingProduct.Price = updatedProduct.Price;
                existingProduct.Count_Product = updatedProduct.Count_Product;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.ImagePath = updatedProduct.ImagePath;
                existingProduct.CategoryID = updatedProduct.CategoryID;
            }

            string newJson = JsonConvert.SerializeObject(allProducts, Formatting.Indented);
            File.WriteAllText(path, newJson);
        }

        private void UpdateProduct(Products updatedProduct)
        {
            List<Products> allProducts;

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                allProducts = JsonConvert.DeserializeObject<List<Products>>(json);
            }
            else
            {
                allProducts = new List<Products>();
            }
        }

        private void exitCard()
        {
            this.Close();
        }
        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            exitCard();
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            string productName = textbox_name.Text;

            if (string.IsNullOrWhiteSpace(productName))
            {
                MessageBox.Show("Невозможно удалить несуществующий товар!", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var result = MessageBox.Show("Вы точно хотите удалить товар?", "Удаление товара", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                DeleteProductFromFile(productName);

                if (Del)
                {
                    OnProductCreated?.Invoke();
                    this.Close();
                }
                else return;

                DeleteProductFromFile(productName);
            }
        }

        private void DeleteProductFromFile(string productName)
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                List<Products> allProducts = JsonConvert.DeserializeObject<List<Products>>(json);

                var productToDelete = allProducts.FirstOrDefault(p => p.Name_Product == productName);
                if (productToDelete != null)
                {
                    allProducts.Remove(productToDelete);

                    string newJson = JsonConvert.SerializeObject(allProducts, Formatting.Indented);
                    File.WriteAllText(path, newJson);
                    Del = true;
                    MessageBox.Show("Товар был удален!", "Удаление товара", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void textbox_number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!int.TryParse(e.Text, out int value))
            {
                e.Handled = true;
            }
        }
    }
}
