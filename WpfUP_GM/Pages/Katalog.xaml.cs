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
    /// Логика взаимодействия для Katalog.xaml
    /// </summary>
    public partial class Katalog : Page
    {
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
        public Katalog(bool avtor)
        {
            InitializeComponent();
            ProductList.ItemsSource = avtor ? Core.GMEntities.Book.Where(y=> y.Author==Static.user.id).ToList() : Core.GMEntities.Book.ToList();
            GenreComboBox.ItemsSource = Core.GMEntities.Genre.ToList();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProductList.ItemsSource= Core.GMEntities.Book.Where(a=>a.Name.Contains(TextSearch.Text) || a.User.Name.Contains(TextSearch.Text)).ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextSearch.Text = "";
            GenreComboBox.SelectedItem = null;
            TypeComboBox.SelectedItem = null;
            ProductList.ItemsSource = Core.GMEntities.Book.ToList();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ProductList.SelectedItem != null)
            {
                mainWindow.MainFrame.NavigationService.Navigate(new BookInfo(ProductList.SelectedItem as Book));
            }
        }
        private void GenreComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GenreComboBox.SelectedItem != null)
            {
                Genre g = GenreComboBox.SelectedItem as Genre;
                ProductList.ItemsSource = Core.GMEntities.Book.Where(b => b.GenreBook.Any(gb => gb.GenreID == g.id)).ToList();
            }
        }

        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                switch (TypeComboBox.SelectedIndex)
                {
                    case 0:
                    ProductList.ItemsSource = Core.GMEntities.Book.OrderBy(b => b.Rating).ToList();
                    break;
                    case 1:
                    ProductList.ItemsSource = Core.GMEntities.Book.OrderByDescending(b => b.Rating).ToList();
                    break;
                    case 2:
                    ProductList.ItemsSource = Core.GMEntities.Book.OrderBy(b => b.Name).ToList();
                    break;
                    default:   
                    break;
                }
        }

 
    }
}