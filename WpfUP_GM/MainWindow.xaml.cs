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
using WpfUP_GM.Pages;

namespace WpfUP_GM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new Katalog());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if(MainFrame.NavigationService.CanGoBack)
            {
                MainFrame.NavigationService.GoBack();
            }
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Katalog());
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            if (Static.user != null) 
            {
                MainFrame.NavigationService.Navigate(new AccInfoPage());
            }
        }

        private void Block_Click(object sender, RoutedEventArgs e)
        {
            if (Static.user != null)
            {
                MainFrame.NavigationService.Navigate(new FreezePage());
            }
        }
    }
}
