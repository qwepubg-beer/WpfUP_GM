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
    /// Логика взаимодействия для AdminListOfBook.xaml
    /// </summary>
    public partial class AdminListOfBook : Page
    {
        public AdminListOfBook()
        {
            InitializeComponent();
            ProductList.ItemsSource = Core.GMEntities.Book.ToList();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(ProductList.SelectedItem!=null)
            {
                Book change = Core.GMEntities.Book.Find(ProductList.SelectedItem as Book);
                if (change != null) 
                {
                    change.IsActive = change.IsActive? false : true;
                    Core.GMEntities.SaveChanges();
                }
                ProductList.ItemsSource = Core.GMEntities.Book.ToList();
            }
        }
    }
}
