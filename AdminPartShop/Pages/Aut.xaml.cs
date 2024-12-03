using Microsoft.Win32;
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
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using EasyCaptcha.Wpf;
using AdminPartShop.Models;
using AdminPartShop.Windows;

namespace AdminPartShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для Aut.xaml
    /// </summary>
    public partial class Aut : Page
    {
        private ObservableCollection<User> users;
        static int counter = 6;
        private string path = "C:\\Users\\rakhm\\source\\repos\\AdminPartShop\\AdminPartShop\\JsonFiles\\users.json";

        public Aut()
        {
            InitializeComponent();
            LoadUsers();
        }
        private void LoadUsers()
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                var userList = JsonConvert.DeserializeObject<List<User>>(json);
                users = new ObservableCollection<User>(userList);
            }
            else
            {
                users = new ObservableCollection<User>();
            }
        }

        public void Entry_window()
        {
            var window = Window.GetWindow(this);
            window.Title = "Регистрация";
            NavigationService.Navigate(new Regist());
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Entry_window();
        }

        private void textbox_email_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            btn_enter.IsEnabled = true;
            counter = 6;
            lb_quantity.Content = $"Осталось попыток: {counter}";
            lb_quantity.Visibility = Visibility.Hidden;
        }

        private void passwordRecovery_Click(object sender, RoutedEventArgs e)
        {
            verificationRecovery();
        }

        private void verificationRecovery()
        {
            string email = textbox_email.Text;
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Введите почту для восстановления!\nВ поле <Почта>", "Пустое поле почта", MessageBoxButton.OK, MessageBoxImage.Question);
                textbox_email.Focus();
                textbox_email.Select(textbox_email.Text.Length, 0);
                return;
            }

            User user = users.FirstOrDefault(u => u.Email == email);

            if (user != null)
            {
                PasswordRecovery_Window passwordRecovery_Window = new PasswordRecovery_Window(email);
                passwordRecovery_Window.ShowDialog();
            }
            else
            {
                MessageBox.Show("Пользователь с данной почтой не найден!", "Неизвестная почта", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private bool formatVerification()
        {
            bool isFormat = false;
            if (!Regex.IsMatch(textbox_email.Text, @"^[a-zA-Z]+[a-zA-Z0-9._%]+[a-zA-Z0-9]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$") || textbox_email.Text.Count(c => c == '@') != 1 ||  textbox_email.Text.Contains(".."))
            {
                isFormat = true;
            }
            if (checkbox_password.IsChecked == true)
            {
                if (!Regex.IsMatch(textbox_show_password.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"))
                {
                    isFormat = true;
                }
            }
            else
            {
                if (!Regex.IsMatch(textbox_password.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"))
                {
                    isFormat = true;
                }
            }
            if (isFormat)
            {
                MessageBox.Show("Неверный формат почты/пароля", "Предупреждение: неверный формат", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            return isFormat;
        }

        private bool checkingEmptyFields()
        {
            string email = textbox_email.Text;
            string password = textbox_password.Password;
            string prominent_password = textbox_show_password.Text;

            bool emptyFields = false;
            if (checkbox_password.IsChecked == true)
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(prominent_password))
                {
                    emptyFields = true;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    emptyFields = true;
                }
            }
            if (emptyFields)
            {
                MessageBox.Show("Заполнены не все поля! Заполните поля и возвращайтесь вновь", "Предупреждение: Пустые поля", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            return emptyFields;
        }

        private void Checking_the_data()
        {
            LoadUsers();

            string email = textbox_email.Text;
            string password = textbox_password.Password;
            string prominent_password = textbox_show_password.Text;

            if (checkingEmptyFields() || formatVerification())
            {
                return;
            }

            User user = users.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                MessageBox.Show("Пользователя с данной почтой не существует!", "Предупреждение: неверные данные", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (user.LockoutEnd.HasValue && user.LockoutEnd > DateTime.Now)
            {
                TimeSpan remainingTime = user.LockoutEnd.Value - DateTime.Now;
                string message = $"Ваш аккаунт заблокирован. Осталось {remainingTime.Hours} часов(ы) и {remainingTime.Minutes} минут(ы) и {remainingTime.Seconds} секунд(ы) до разблокировки.";
                MessageBox.Show(message, "Блокировка аккаунта", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (checkbox_password.IsChecked == true)
            {
                if (user.Password == prominent_password)
                {
                    SuccessfulLogin(user);
                    return;
                }
                numberAttempts(email);
            }
            else if (checkbox_password.IsChecked == false)
            {
                if (user.Password == password)
                {
                    SuccessfulLogin(user);
                    return;
                }
                numberAttempts(email);
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!", "Предупреждение: неверные данные", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Неверный логин или пароль!", "Предупреждение: неверные данные", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void SuccessfulLogin(User user)
        {
            if (user.TwoFactor_Authentication)
            {
                if (!twoFactorAuthenticationWindow(user))
                {
                    return;
                }
            }

            if (!captchaWindow(user))
            {
                return;
            }
            MessageBox.Show("Вы успешно вошли в аккаунт!", "Успешный вход", MessageBoxButton.OK, MessageBoxImage.Information);
            Shop_window shop_Window = new Shop_window(user.Id);
            shop_Window.Show();
            broadcast(user.Id);
            Window.GetWindow(this)?.Close();
        }

        private bool twoFactorAuthenticationWindow(User user)
        {
            TwoFactor_Code_Window twoFactorecode = new TwoFactor_Code_Window(user.Email);
            twoFactorecode.ShowDialog();
            return twoFactorecode.check_code;
        }

        private bool captchaWindow(User user)
        {
            Captcha_Window captcha = new Captcha_Window(user.Id);
            captcha.ShowDialog();
            return captcha.check_capcha;
        }

        private void numberAttempts(string email_user)
        {
            counter--;
            lb_quantity.Content = $"Осталось попыток: {counter}";
            lb_quantity.Visibility = Visibility.Visible;

            if (counter <= 0)
            {
                User user = GetUserByEmail(email_user);
                if (user != null)
                {
                    user.LockoutEnd = DateTime.Now.AddMinutes(5);
                    SaveUsers();
                }
            }
        }

        private User GetUserByEmail(string email)
        {
            return users.FirstOrDefault(u => u.Email == email);
        }

        private void SaveUsers()
        {
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public void broadcast(int id)
        {
            Profile_Page profilePage = new Profile_Page(id);
            Main_Shop_Window main_Shop_Window = new Main_Shop_Window(id);
        }
        private void checkbox_password_Checked(object sender, RoutedEventArgs e)
        {
            TogglePasswordVisibility(textbox_password, textbox_show_password, checkbox_password.IsChecked == true);
        }

        private void checkbox_password_Unchecked(object sender, RoutedEventArgs e)
        {
            TogglePasswordVisibility(textbox_password, textbox_show_password, false);
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

        private void textBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
        private void btn_enter_Click(object sender, RoutedEventArgs e)
        {
            Checking_the_data();
        }
    }
}
