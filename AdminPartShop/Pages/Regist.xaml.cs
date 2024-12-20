﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Net.Http;
using AdminPartShop.Models;


namespace AdminPartShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для Regist.xaml
    /// </summary>
    public partial class Regist : Page
    {
        public Regist()
        {
            InitializeComponent();
        }
        public void Entry_window()
        {
            var window = Window.GetWindow(this);
            window.Title = "Авторизация";
            NavigationService.Navigate(new Aut());
        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Entry_window();
        }
        private bool Checking_for_completion()
        {
            bool isEmpty = false;

            List<TextBox> textBoxes = new List<TextBox>
            {
                textbox_surname,
                textbox_name,
                textbox_email,
            };

            List<PasswordBox> passwordBoxes = new List<PasswordBox>
            {
                textbox_password,
                textbox_password_2
            };
            List<TextBox> tb_pass = new List<TextBox>
            {
                textbox_show_password,
                textbox_show_password_2
            };

            foreach (TextBox textBox in textBoxes)
            {
                if (textBox.Text == "")
                {
                    isEmpty = true;
                }
            }

            foreach (PasswordBox passwordBox in passwordBoxes)
            {
                if (passwordBox.Password == "")
                {
                    foreach (TextBox tb_password in tb_pass)
                    {
                        if (tb_password.Text == "")
                        {
                            isEmpty = true;
                        }
                        else
                        {
                            isEmpty = false;
                        }
                    }
                }
            }

            if (isEmpty)
            {
                MessageBox.Show("Заполнены не все поля! Заполните поля и возвращайтесь вновь", "Предупреждение: Пустые поля", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            return isEmpty;
        }

        public async void SaveUser(User newUser)
        {
            HttpClient client = new HttpClient();
            
            string url = "https://localhost:7244/api/User/Register";

            var json = JsonConvert.SerializeObject(newUser);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            try
            {
                HttpResponseMessage response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    Entry_window();
                    MessageBox.Show("Вы успешно зарегистрировались!");
                }
                else
                {
                    MessageBox.Show("Ошибка валидации");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"HTTP Request Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Прочие ошибки: {ex.Message}");
            }
        }

        private bool Checking_mail()
        {
            bool isEmpty = false;
            if (!Regex.IsMatch(textbox_email.Text, @"^[a-zA-Z0-9]+[a-zA-Z0-9._%]+[a-zA-Z0-9]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$") || textbox_email.Text.Count(c => c == '@') != 1 || textbox_email.Text.Count(c => c == '.') != 1 || textbox_email.Text.Contains(".."))
            {
                isEmpty = true;
            }
            if (isEmpty)
            {
                MessageBox.Show("Пожалуйста, введите правильный адрес электронной почты.", "Предупреждение: Неверный адрес почты", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            return isEmpty;
        }
        private bool Password_verification()
        {
            bool isEmpty = false;
            if (checkbox_password.IsChecked == true)
            {
                if (!Regex.IsMatch(textbox_show_password.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"))
                {
                    isEmpty = true;
                }
            }
            else
            {
                if (!Regex.IsMatch(textbox_password.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"))
                {
                    isEmpty = true;
                }
            }
            if (isEmpty)
            {
                MessageBox.Show("Пароль слишком простой. Пароль должен содержать минимум одну заглавную букву, одну маленькую букву, одну цифру и быть не менее 8 символов.", "Предупреждение: неверный пароль", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            return isEmpty;
        }
        private bool Checking_for_password_approval()
        {
            bool isEmpty = false;
            if (checkbox_password.IsChecked == true)
            {
                if (checkbox_password_2.IsChecked == true)
                {
                    if (textbox_show_password.Text != textbox_show_password_2.Text)
                    {
                        isEmpty = true;
                    }
                }
                else
                {
                    if (textbox_show_password.Text != textbox_password_2.Password)
                    {
                        isEmpty = true;
                    }
                }
            }
            if (checkbox_password_2.IsChecked == true)
            {
                if (checkbox_password.IsChecked == true)
                {
                    if (textbox_show_password.Text != textbox_show_password_2.Text)
                    {
                        isEmpty = true;
                    }
                }
            }
            else
            {
                if (textbox_password.Password != textbox_password_2.Password)
                {
                    isEmpty = true;
                }
            }
            if (isEmpty)
            {
                MessageBox.Show("Пароли не совпадают, повторите ввод пароля!", "Предупреждение: не совпадают пароли", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                textbox_password_2.Clear();
            }
            return isEmpty;
        }
        public void Save_in_File()
        {
            if (Checking_for_completion() || Checking_mail() || Password_verification() || Checking_for_password_approval())
            {
                return;
            }
            User newUser = new User(
                textbox_surname.Text,
                textbox_name.Text,
                textbox_middle_name.Text,
                textbox_email.Text,
                textbox_password.Password
            );

            SaveUser(newUser);
        }
        private void btn_enter_Click(object sender, RoutedEventArgs e)
        {
            Save_in_File();
        }

        private void textbox_email_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"\p{IsCyrillic}"))
            {
                e.Handled = true;
            }
        }

        private void textbox_Correct_input_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            TextBox textBox = sender as TextBox;
            if (!Regex.IsMatch(e.Text, @"\p{IsCyrillic}"))
            {
                e.Handled = true;
                return;
            }

            if (textBox.Text.Length == 0)
            {
                e.Handled = true;
                textBox.Text += e.Text.ToUpper();
                textBox.CaretIndex = textBox.Text.Length;
            }
            else
            {
                e.Handled = true;
                textBox.Text += e.Text.ToLower();
                textBox.CaretIndex = textBox.Text.Length;
            }
        }

        private void textBox_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Paste || e.Command == ApplicationCommands.Cut)
            {
                e.Handled = true;
            }
        }
        private void textBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void textbox_password_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void checkbox_password_Checked(object sender, RoutedEventArgs e)
        {
            TogglePasswordVisibility(textbox_password, textbox_show_password, checkbox_password.IsChecked == true);
        }

        private void checkbox_password_Unchecked(object sender, RoutedEventArgs e)
        {
            TogglePasswordVisibility(textbox_password, textbox_show_password, false);
        }

        private void checkbox_password_Checked_2(object sender, RoutedEventArgs e)
        {
            TogglePasswordVisibility(textbox_password_2, textbox_show_password_2, checkbox_password_2.IsChecked == true);
        }

        private void checkbox_password_Unchecked_2(object sender, RoutedEventArgs e)
        {
            TogglePasswordVisibility(textbox_password_2, textbox_show_password_2, false);
        }

        private void TogglePasswordVisibility(PasswordBox passwordBox, TextBox showPasswordBox, bool isChecked)
        {
            if (isChecked)
            {
                showPasswordBox.Text = passwordBox.Password;
                passwordBox.Visibility = Visibility.Hidden;
                RemovePasswordBox(showPasswordBox);
            }
            else
            {
                passwordBox.Password = showPasswordBox.Text;
                showPasswordBox.Visibility = Visibility.Hidden;
                RestorePasswordBox(passwordBox);
            }
        }

        private void RemovePasswordBox(TextBox showPasswordBox)
        {
            showPasswordBox.Visibility = Visibility.Visible;
            showPasswordBox.Focus();
            showPasswordBox.Select(showPasswordBox.Text.Length, 0);
        }

        private void RestorePasswordBox(PasswordBox passwordBox)
        {
            passwordBox.Visibility = Visibility.Visible;
            passwordBox.Focus();
        }
    }
}
