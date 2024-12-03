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
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using AdminPartShop.Models;

namespace AdminPartShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для CodePass_Page.xaml
    /// </summary>
    public partial class CodePass_Page : Page
    {
        private readonly TwoFactorAuthenticationService authenticationService;
        public string email_addres;
        public string code;
        public CodePass_Page(string email)
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
                MessageBox.Show("Введите код", "Пустое поле", MessageBoxButton.OK, MessageBoxImage.Error);
                textbox_code.Focus();
                textbox_code.Select(textbox_code.Text.Length, 0);
                return;
            }

            if (!authenticationService.IsCodeValid(textbox_code.Text))
            {
                MessageBox.Show("Неверный код или код истек!", "Неверный код", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Следуйте инструкции по восстановлению пароля", "Верный код", MessageBoxButton.OK, MessageBoxImage.Information);
            Entry_window();
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
                message.Subject = "Код восстановления пароля";
                message.Body = $"Здравствуйте!\r\nВы запросили код для восстановления пароля. Ваш код: {code}.\r\n" +
                    $"Пожалуйста, не сообщайте этот код никому и используйте его только для восстановления доступа к вашей учетной записи.\r\nС уважением,\r\nВаша команда поддержки";

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
        public void Entry_window()
        {
            var window = Window.GetWindow(this);
            NavigationService.Navigate(new PasswordRecovery_Page(email_addres));
        }
        private void remembered_password_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }
    }
}
