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
    /// Логика взаимодействия для AdminListOfRewiew.xaml
    /// </summary>
    public partial class AdminListOfRewiew : Page
    {
        public AdminListOfRewiew()
        {
            InitializeComponent();
            ProductList.ItemsSource = Core.GMEntities.Rewiew.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ProductList.SelectedItem != null)
            {
                Rewiew change = Core.GMEntities.Rewiew.Find(ProductList.SelectedItem as Rewiew);
                if (change != null)
                {
                    //change.IsActive = change.IsActive ? false : true;
                    //Core.GMEntities.SaveChanges();
                }
                ProductList.ItemsSource = Core.GMEntities.Rewiew.ToList();
            }
        }
    }
}
