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
    /// Логика взаимодействия для ListOfBook.xaml
    /// </summary>
    public partial class ListOfBook : Page
    {
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
        public ListOfBook(int a)
        {
            InitializeComponent();
            ProductList.ItemsSource= Core.GMEntities.BookInList.Where(b=> b.UserID == Static.user.id && b.TypeListID==a).ToList();
        }

        private void Read_Click(object sender, RoutedEventArgs e)
        {
            if(ProductList.SelectedItem!=null)
            {
                BookInList book = ProductList.SelectedItem as BookInList;
                Book book1 = Core.GMEntities.Book.Find(book.BookID);    
                mainWindow.MainFrame.NavigationService.Navigate(new ReadBook(book1));
            }
            
        }

        private void ChangeList_Click(object sender, RoutedEventArgs e)
        {
            //сделать окно с выбором списка
            if (ProductList.SelectedItem != null)
            {
                BookInList book = ProductList.SelectedItem as BookInList;
                BookInList book1 = Core.GMEntities.BookInList.Find(book.BookID);
                book1.TypeListID = 2;

            }
        }
    }
}
