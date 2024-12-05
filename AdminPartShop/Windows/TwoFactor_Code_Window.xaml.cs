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
using Microsoft.Toolkit.Uwp.Notifications;
using AdminPartShop.Models;

namespace AdminPartShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для TwoFactor_Code_Window.xaml
    /// </summary>
    public partial class TwoFactor_Code_Window : Window
    {
        private readonly TwoFactorAuthenticationService authenticationService;
        public bool check_code = false;
        public string email_addres;
        private string code;

        public TwoFactor_Code_Window(string email)
        {
            InitializeComponent();
            email_addres = email;
            authenticationService = new TwoFactorAuthenticationService();
            authenticationService.GenerateCode();
            code = authenticationService.GetCode();
            sendingСode();
        }

        private void checkingCode()
        {
            if (textbox_code.Text == "")
            {
                ShowNotification("Введите код!");
                textbox_code.Focus();
                textbox_code.Select(textbox_code.Text.Length, 0);
                return;
            }
            if (!authenticationService.IsCodeValid(textbox_code.Text))
            {
                ShowNotification("Неверный код или код истек!");
                return;
            }

            check_code = true;
            ShowNotification("Двухфакторная аутентификация успешно пройдена!");
            Window.GetWindow(this)?.Close();
        }

        private void ShowNotification(string message)
        {
            MessageBox.Show(message);
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
                message.Body = $"Здравствуйте!\r\nВы запросили код для двухфакторной аутентификации. Ваш код: {code}.\r\n" +
                    $"Пожалуйста, не сообщайте этот код никому и используйте его только для прохода двухфакторной аутентификации к вашей учетной записи." +
                    $"\r\nС уважением,\r\n\nВаша команда поддержки";
                myClient.Send(message);
            }
            catch (Exception)
            {
                MessageBox.Show($"Произошла ошибка при отправке кода.\nПопробуйте поздее.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }
    }
}
