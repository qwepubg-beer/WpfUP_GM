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
using static WpfUP_GM.Function;

namespace WpfUP_GM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new Katalog(false));
            LoadDate();

        }
        public void LoadDate()
        {
            if (IsReg() && Static.user.RoleID == 3) { Admin.Visibility = Visibility.Visible; }
            if (IsReg() && Static.user.RoleID == 2 && Static.user.IsActive) { Author.Visibility = Visibility.Visible; }
            if (IsReg() && UserIsActive()) { Block.Visibility = Visibility.Visible; }
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
            MainFrame.NavigationService.Navigate(new Katalog(false));
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            if (IsReg()) 
            {
                MainFrame.NavigationService.Navigate(new AccInfoPage());
            }
            else
            {
                MainFrame.NavigationService.Navigate(new Enter());
            }
        }

        private void Block_Click(object sender, RoutedEventArgs e)
        {
            if (IsReg())
            {
                MainFrame.NavigationService.Navigate(new FreezePage());
            }
        }

        private void Author_Click(object sender, RoutedEventArgs e)
        {   
          MainFrame.NavigationService.Navigate(new AuthorPage());
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new AdminPage());
        }
    }
}
