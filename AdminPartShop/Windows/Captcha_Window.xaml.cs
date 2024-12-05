using EasyCaptcha.Wpf;
using Microsoft.Toolkit.Uwp.Notifications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using AdminPartShop.Models;

namespace AdminPartShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для Captcha_Window.xaml
    /// </summary>
    public partial class Captcha_Window : Window
    {
        private ObservableCollection<User> users;
        string path = "C:\\Users\\rakhm\\source\\repos\\AdminPartShop\\AdminPartShop\\JsonFiles\\users.json";
        string json = File.ReadAllText("C:\\Users\\rakhm\\source\\repos\\AdminPartShop\\AdminPartShop\\JsonFiles\\users.json");
        public bool check_capcha = false;
        private int user_id;
        static int counter = 4;
        public Captcha_Window(int userId)
        {
            InitializeComponent();
            user_id = userId;
            LoadUsers();
            captchaGeneration();
            focusOnInput();
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
                    user.LockoutEnd = DateTime.Now.AddYears(999);
                    SaveUsers();
                    this.Close();
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

        private void captchaGeneration()
        {
            MyCaptcha.CreateCaptcha(EasyCaptcha.Wpf.Captcha.LetterOption.Alphanumeric, 5);
        }

        private void checkinСaptcha()
        {
            ObservableCollection<User> users = JsonConvert.DeserializeObject<ObservableCollection<User>>(json);
            User currentUser = users.FirstOrDefault(user => user.Id == user_id);

            if (textbox_captcha.Text == "")
            {
                ShowNotification("Введите капчу!");
                numberAttempts(currentUser.Email);
                focusOnInput();
                return;
            }
            if(textbox_captcha.Text.ToLower() == MyCaptcha.CaptchaText.ToLower())
            {
                check_capcha = true;
                ShowNotification("Капча успешно пройдена!");
                this.Close();
            }
            else
            {
                ShowNotification("Неверно введена капча!");
                numberAttempts(currentUser.Email);
                captchaGeneration();
                focusOnInput();
                textbox_captcha.Clear();
                return;
            }
        }

        private void ShowNotification(string message)
        {
            MessageBox.Show(message);
        }

        private void focusOnInput()
        {
            textbox_captcha.Focus();
            textbox_captcha.Select(textbox_captcha.Text.Length, 0);
        }

        private void textbox_captcha_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void textBox_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Paste || e.Command == ApplicationCommands.Cut)
            {
                e.Handled = true;
            }
        }

        private void Hyperlink_Click_Reload(object sender, RoutedEventArgs e)
        {
            captchaGeneration();
        }
        private void btn_enter_Click(object sender, RoutedEventArgs e)
        {
            checking_ban();
            checkinСaptcha();
        }
        private void checking_ban()
        {
            ObservableCollection<User> users = JsonConvert.DeserializeObject<ObservableCollection<User>>(json);
            User currentUser = users.FirstOrDefault(user => user.Id == user_id);

            if (currentUser.LockoutEnd.HasValue && currentUser.LockoutEnd > DateTime.Now)
            {
                TimeSpan remainingTime = currentUser.LockoutEnd.Value - DateTime.Now;
                string message = $"Ваш аккаунт заблокирован. Осталось {remainingTime.Hours} часов(ы)";
                MessageBox.Show(message, "Блокировка аккаунта", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }
    }
}
