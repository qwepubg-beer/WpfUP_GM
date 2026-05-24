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
    /// Логика взаимодействия для AccInfoPage.xaml
    /// </summary>
    public partial class AccInfoPage : Page
    {

        public AccInfoPage()
        {
            InitializeComponent();
            TypeListComboBox.ItemsSource = Core.GMEntities.TypeBookList.ToList();
            TypeBookList typeBookList= TypeListComboBox.SelectedItem as  TypeBookList;
            UserFrame.NavigationService.Navigate(new ListOfBook(typeBookList));
        }

        private void TypeListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypeBookList typeBookList = TypeListComboBox.SelectedItem as TypeBookList;
            UserFrame.NavigationService.Navigate(new ListOfBook(typeBookList));
        }

        private void Freeze_Click(object sender, RoutedEventArgs e)
        {
            UserFrame.NavigationService.Navigate(new FreezePage());
        }

        private void Rewiews_Click(object sender, RoutedEventArgs e)
        {
            UserFrame.NavigationService.Navigate(new MyRewiew());
        }

        private void MyAccount_Click(object sender, RoutedEventArgs e)
        {
            UserFrame.NavigationService.Navigate(new MyAccount());
        }
    }
}
