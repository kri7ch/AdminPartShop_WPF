using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel;
using AdminPartShop.Models;

namespace AdminPartShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для TwoFactorActivation_Window.xaml
    /// </summary>
    public partial class TwoFactorActivation_Window : Window
    {
        private readonly TwoFactorAuthenticationService authenticationService;
        public string email_addres;
        public string code;
        public bool connectionStatus = false;

        private int currentUserId;
        string json = File.ReadAllText("C:\\Users\\rakhm\\source\\repos\\AdminPartShop\\AdminPartShop\\JsonFiles\\users.json");

        public TwoFactorActivation_Window(string email, int Id)
        {
            InitializeComponent();
            email_addres = email;
            currentUserId = Id;
            authenticationService = new TwoFactorAuthenticationService();
            authenticationService.GenerateCode();
            code = authenticationService.GetCode();
            sendingСode();
        }

        private void checkingCode()
        {
            if (textbox_code.Text == "")
            {
                MessageBox.Show("Введите код", "Пустое поле", MessageBoxButton.OK, MessageBoxImage.Error);
                textbox_code.Focus();
                textbox_code.Select(textbox_code.Text.Length, 0);
                return;
            }

            if (!authenticationService.IsCodeValid(textbox_code.Text))
            {
                MessageBox.Show("Неверный код!\nПовторите попытку ввода!", "Неверный код", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Двухфакторная аутентификация успешно подключена", "Успешное подключение", MessageBoxButton.OK, MessageBoxImage.Information);
            connectionStatus = true;
            activationTwoFactor();
            this.Close();
        }

        private void activationTwoFactor()
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
            User currentUser = users.FirstOrDefault(userInfo => userInfo.Id == currentUserId);

            currentUser.TwoFactor_Authentication = true;

            string Newjson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(json, Newjson);
        }

        private void sendingСode()
        {
            try
            {
                SmtpClient myClient = new SmtpClient();
                myClient.Credentials = new NetworkCredential("rakhmaevdanil@mail.ru", "Fz7Jszvrhy0VHFyGsd9Q");
                myClient.Host = "smpt.mail.ru";
                myClient.Port = 587;
                myClient.EnableSsl = true;
                MailMessage message = new MailMessage();
                message.From = new MailAddress("rakhmaevdanil@mail.ru");
                message.To.Add(new MailAddress(email_addres));
                message.Subject = "Активация двухфакторной аутентификации";
                message.Body = $"Здравствуйте!\r\nВы запросили код для подключения двухфакторной аутентификации. Ваш код: {code}.\r\n" +
                    $"Пожалуйста, не сообщайте этот код никому и используйте его только для подключения двухфакторной аутентификации к вашей учетной записи." +
                    $"\r\nС уважением,\r\n\nВаша команда поддержки";
                myClient.Send(message);
            }
            catch (Exception)
            {
                MessageBox.Show($"Произошла ошибка при отправке кода.\nПопробуйте поздее.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
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

        private void btn_enter_Click(object sender, RoutedEventArgs e)
        {
            checkingCode();
        }

        private void changedMyMind_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }
    }
}
