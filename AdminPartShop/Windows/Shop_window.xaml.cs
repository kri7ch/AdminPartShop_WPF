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
using Newtonsoft.Json;
using System.IO;
using AdminPartShop.Pages;

namespace AdminPartShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для Shop_window.xaml
    /// </summary>
    public partial class Shop_window : Window
    {
        private int currentUserId;
        public Shop_window(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            Frame_Shop.Content = new Main_Shop_Window(currentUserId);
        }
    }
}
