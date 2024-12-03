using Newtonsoft.Json;
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
using AdminPartShop.Models;

namespace AdminPartShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для PasswordRecovery_Page.xaml
    /// </summary>
    public partial class PasswordRecovery_Page : Page
    {
        private string email_user;
        private List<User> users;
        private string path = "C:\\Users\\rakhm\\source\\repos\\AdminPartShop\\AdminPartShop\\JsonFiles\\users.json";
        public PasswordRecovery_Page(string email)
        {
            InitializeComponent();
            email_user = email;
        }
        private void textBox_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Paste || e.Command == ApplicationCommands.Cut)
            {
                e.Handled = true;
            }
        }
        private void textbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
        private void checkingCorrectnessPassword()
        {
            if(textbox_pass.Text == "" || textbox_pass_2.Text == "")
            {
                MessageBox.Show("Заполните пустые поля!", "Пустые поля", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!Regex.IsMatch(textbox_pass.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"))
            {
                MessageBox.Show("Пароль слишком простой. Пароль должен содержать минимум одну заглавную букву, одну маленькую букву, одну цифру и быть не менее 8 символов.",
                    "Предупреждение: неверный пароль", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            if (textbox_pass.Text != textbox_pass_2.Text)
            {
                MessageBox.Show("Пароли не совпадают!", "Разные пароли", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            savingPassword();
        }
        private void LoadUsers()
        {
            string json = File.ReadAllText(path);
            users = JsonConvert.DeserializeObject<List<User>>(json);
        }

        private void savingPassword()
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
            }
            else
            {
                MessageBox.Show("Файла не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var user = users.FirstOrDefault(u => u.Email == email_user);
            user.Password = textbox_pass.Text;
            string newJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(path, newJson);
            MessageBox.Show("Пароль успешно изменен!", "Смена пароля", MessageBoxButton.OK, MessageBoxImage.Information);
            LoadUsers();
            Window.GetWindow(this)?.Close();
        }

        private void btn_enter_Click(object sender, RoutedEventArgs e)
        {
            checkingCorrectnessPassword();
        }

        private void textbox_pass_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"\p{IsCyrillic}"))
            {
                e.Handled = true;
            }
        }

        private void remembered_password_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }
    }
}
