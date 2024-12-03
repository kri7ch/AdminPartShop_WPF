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
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Mail;
using System.Net;
using EasyCaptcha.Wpf;
using AdminPartShop.Models;
using AdminPartShop.Windows;
using AdminPartShop.Pages;

namespace AdminPartShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для Profile_Page.xaml
    /// </summary>
    public partial class Profile_Page : Page
    {
        private int currentUserId;
        string json = File.ReadAllText("C:\\Users\\rakhm\\source\\repos\\AdminPartShop\\AdminPartShop\\JsonFiles\\users.json");
        public Profile_Page(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            twoFactorVerification();
            ProvidingInformation();
        }

        private void twoFactorVerification()
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);

            User currentUser = users.FirstOrDefault(user => user.Id == currentUserId);

            if (currentUser.TwoFactor_Authentication)
            {
                twofactorEnabled();
            }
        }

        private void ProvidingInformation()
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);

            User currentUser = users.FirstOrDefault(user => user.Id == currentUserId);

            text_email.Content = currentUser.Email;
            text_surname.Content = currentUser.Surname;
            text_name.Content = currentUser.Name;
            text_lastname.Content = currentUser.Middle_Name;

            if (currentUser.TwoFactor_Authentication)
            {
                text_enable.Visibility = Visibility.Visible;
                tb_turnedOff.Visibility = Visibility.Hidden;
            }
        }

        public void MainMenu_Page()
        {
            var window = Window.GetWindow(this);
            window.Title = "Главное меню";
            NavigationService.Navigate(new Main_Shop_Window(currentUserId));
        }
        private void Hyperlink_Click_MainMenu(object sender, RoutedEventArgs e)
        {
            MainMenu_Page();
        }

        public void Exit_account()
        {
            var result = MessageBox.Show("Выйти из аккаунта?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Window.GetWindow(this)?.Close();
            }
        }

        private void Hyperlink_Click_Aut(object sender, RoutedEventArgs e)
        {
            Exit_account();
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

        private bool Checking_for_completion()
        {
            bool isEmpty = false;
            List<TextBox> textBoxes = new List<TextBox>
            {
                textbox_surname,
                textbox_name
            };
            foreach (TextBox textBox in textBoxes)
            {
                if (textBox.Text == "")
                {
                    isEmpty = true;
                }
            }
            if (isEmpty)
            {
                MessageBox.Show("Заполнены не все поля! Заполните поля и возвращайтесь вновь", "Предупреждение: Пустые поля", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            return isEmpty;
        }
        private void EditingData()
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
            User currentUser = users.FirstOrDefault(userInfo => userInfo.Id == currentUserId);


            if (Checking_for_completion())
            {
                return;
            }

            currentUser.Surname = textbox_surname.Text;
            currentUser.Name = textbox_name.Text;
            currentUser.Middle_Name = textbox_lastname.Text;
            text_surname.Content = currentUser.Surname;
            text_name.Content = currentUser.Name;
            text_lastname.Content = currentUser.Middle_Name;

            string newJson = JsonConvert.SerializeObject(users);
            File.WriteAllText(json, newJson);
            UpdatingElementsAfterEditing();
            MessageBox.Show("Данные были обновлены!", "Обновление данных", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            EditingData();
        }

        private void ActivatingEditing()
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
            User currentUser = users.FirstOrDefault(userInfo => userInfo.Id == currentUserId);

            textbox_surname.Text = currentUser.Surname;
            textbox_surname.Focus();
            textbox_surname.Select(textbox_surname.Text.Length, 0);

            textbox_name.Text = currentUser.Name;
            textbox_lastname.Text = currentUser.Middle_Name;
            UpdatingElementsEditing();

        }
        private void twofactorEnabled()
        {
            tb_turnedOff.Visibility = Visibility.Hidden;
            text_enable.Visibility = Visibility.Visible;
        }

        private void enablingTwo_FactorAuthentication()
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
            User currentUser = users.FirstOrDefault(userInfo => userInfo.Id == currentUserId);

            TwoFactorActivation_Window twoFactorActivation_Window = new TwoFactorActivation_Window(currentUser.Email, currentUserId);
            twoFactorActivation_Window.ShowDialog();

            if (twoFactorActivation_Window.connectionStatus is true)
            {
                twofactorEnabled();
            }
            else
            {
                MessageBox.Show("Двуфакторная аунтефикация не была добавлена!", "Отмена добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btn_redact_Click(object sender, RoutedEventArgs e)
        {
            ActivatingEditing();
        }

        private void btn_cancel_redact_Click(object sender, RoutedEventArgs e)
        {
            UpdatingElementsAfterEditing();
        }

        private void hp_aunt_Click(object sender, RoutedEventArgs e)
        {
            enablingTwo_FactorAuthentication();
        }

        private void UpdatingElementsEditing()
        {
            text_surname.Visibility = Visibility.Hidden;
            text_name.Visibility = Visibility.Hidden;
            text_lastname.Visibility = Visibility.Hidden;

            textbox_name.Visibility = Visibility.Visible;
            textbox_lastname.Visibility = Visibility.Visible;
            textbox_surname.Visibility = Visibility.Visible;

            btn_save.Visibility = Visibility.Visible;
            btn_cancel_redact.Visibility = Visibility.Visible;
            btn_redact.Visibility = Visibility.Hidden;
        }

        private void UpdatingElementsAfterEditing()
        {
            text_surname.Visibility = Visibility.Visible;
            text_name.Visibility = Visibility.Visible;
            text_lastname.Visibility = Visibility.Visible;

            textbox_name.Visibility = Visibility.Hidden;
            textbox_lastname.Visibility = Visibility.Hidden;
            textbox_surname.Visibility = Visibility.Hidden;

            btn_save.Visibility = Visibility.Hidden;
            btn_cancel_redact.Visibility = Visibility.Hidden;
            btn_redact.Visibility = Visibility.Visible;
        }
    }
}
