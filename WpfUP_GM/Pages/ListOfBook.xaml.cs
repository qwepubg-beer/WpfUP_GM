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
        public ListOfBook(int a)
        {
            InitializeComponent();
            List<BookInList> bookList = Core.GMEntities.BookInList.Where(b=> b.UserID == Static.user.id && b.TypeListID==a).ToList();
        }

        private void Read_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeList_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
