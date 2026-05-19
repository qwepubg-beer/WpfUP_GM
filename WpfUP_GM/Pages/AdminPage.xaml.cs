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

        private void TypeListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (TypeListComboBox.SelectedIndex)
            {
                case 0:
                    AdminFrame.NavigationService.Navigate(new AdminListOfUser());
                    break;
                case 1:
                    AdminFrame.NavigationService.Navigate(new AdminListOfBook());
                    break;
                case 2:
                    AdminFrame.NavigationService.Navigate(new AdminListOfRewiew());
                    break;
            }

        }
    }
}
