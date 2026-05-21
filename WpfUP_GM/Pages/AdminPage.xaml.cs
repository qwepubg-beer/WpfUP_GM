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
namespace WpfUP_GM.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }
        private void ListOfReport_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.NavigationService.Navigate(new AdminListOfReport(true));
        }

        private void Frezze_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.NavigationService.Navigate(new AdminListOfBid(Core.GMEntities.TypeBid.FirstOrDefault(u=>u.BidName != "Получение роль автор")));
        }

        private void BidAuthor_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.NavigationService.Navigate(new AdminListOfBid(Core.GMEntities.TypeBid.FirstOrDefault(u => u.BidName == "Получение роль автор")));
        }
        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            AdminFrame.NavigationService.Navigate(new AdminListOfUser());
        }

        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            AdminFrame.NavigationService.Navigate(new AdminListOfBook());
        }

        private void ComboBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            AdminFrame.NavigationService.Navigate(new AdminListOfRewiew());
        }
    }
}
