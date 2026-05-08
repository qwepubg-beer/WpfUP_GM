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
    /// Логика взаимодействия для ListOfAuthorBook.xaml
    /// </summary>
    public partial class ListOfAuthorBook : Page
    {
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
        public ListOfAuthorBook()
        {
            InitializeComponent();
            ProductList.ItemsSource = Core.GMEntities.Book.Where(b => b.Author == Static.user.id).ToList();
        }
        private void Read_Click(object sender, RoutedEventArgs e)
        {
            if (ProductList.SelectedItem != null)
            {
                Book book = ProductList.SelectedItem as Book;
                mainWindow.MainFrame.NavigationService.Navigate(new ReadBook(book));
            }
        }
    }
}
