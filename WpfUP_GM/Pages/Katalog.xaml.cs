using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfUP_GM.Windows;

namespace WpfUP_GM.Pages
{
    /// <summary>
    /// Логика взаимодействия для Katalog.xaml
    /// </summary>
    public partial class Katalog : Page
    {
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
        ObservableCollection<Book> BooksList { get; set; }
        bool AuthorList=false;
        public Katalog(bool au)
        {
            InitializeComponent();
            AuthorList=au;
            GenreComboBox.ItemsSource = Core.GMEntities.Genre.ToList();
            LoadData(); 
            ProductList.ItemsSource = BooksList;
        }
        void LoadData()
        {
            if (AuthorList)
            {
                if (Static.user != null && Static.user.RoleID == 2)
                {
                    BooksList = new ObservableCollection<Book>(Core.GMEntities.Book.Where(y => y.Author == Static.user.id).ToList());
                }
            }
            else
            {
                BooksList = new ObservableCollection<Book>(Core.GMEntities.Book.Where(a => a.IsActive == true).ToList());
            }
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
            LoadData();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ProductList.SelectedItem != null)
            {
                if(Static.user.RoleID == 2)
                {
                    Book book = ProductList.SelectedItem as Book;
                    var bookWindow = new AddChangeBookWindow(book: book, authorId: Static.user.id);
                    bookWindow.Owner = Window.GetWindow(this);
                    bool? result = bookWindow.ShowDialog();
                    if (result == true && bookWindow.IsConfirmed)
                    {
                        MessageBox.Show("Книга успешно добавлена!", "Успех",
                                        MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    mainWindow.MainFrame.NavigationService.Navigate(new BookInfo(ProductList.SelectedItem as Book));
                }
                
            }
        }
        private void GenreComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GenreComboBox.SelectedItem != null)
            {
                Genre g = GenreComboBox.SelectedItem as Genre;
                ProductList.ItemsSource = BooksList.Where(b => b.GenreBook.Any(gb => gb.GenreID == g.id)).ToList();
            }
        }

        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                switch (TypeComboBox.SelectedIndex)
                {
                    case 0:
                    ProductList.ItemsSource = BooksList.OrderBy(b => b.Rating).ToList();
                    break;
                    case 1:
                    ProductList.ItemsSource = BooksList.OrderByDescending(b => b.Rating).ToList();
                    break;
                    case 2:
                    ProductList.ItemsSource = BooksList.OrderBy(b => b.Name).ToList();
                    break;
                    default:   
                    break;
                }
        }

 
    }
}