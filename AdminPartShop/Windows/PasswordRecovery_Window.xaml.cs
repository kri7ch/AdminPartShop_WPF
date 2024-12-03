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
using AdminPartShop.Pages;

namespace AdminPartShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для PasswordRecovery_Window.xaml
    /// </summary>
    public partial class PasswordRecovery_Window : Window
    {
        public PasswordRecovery_Window(string Email)
        {
            InitializeComponent();
            PassRec_Window.Content = new CodePass_Page(Email);
        }
    }
}
