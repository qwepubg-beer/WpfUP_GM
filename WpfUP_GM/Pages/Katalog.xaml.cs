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
        public Katalog()
        {
            InitializeComponent();
            ProductList.ItemsSource = Core;
            ManufacturerComboBox.ItemsSource = LoadManufacturers();
            TypeComboBox.ItemsSource = LoadTypeOfProduct();
        }
        private void ManufacturerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProductList.ItemsSource = LoadProducts(TextSearch.Text, ManufacturerComboBox.SelectedItem as Manufacturers, TypeComboBox.SelectedItem as TypeOfProduct);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextSearch.Text = "";
            ManufacturerComboBox.SelectedItem = null;
            TypeComboBox.SelectedItem = null;
            ManufacturerComboBox.ItemsSource = LoadManufacturers();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ProductList.SelectedItem != null)
            {
                Products SelelectProduct = ProductList.SelectedItem as Products;
                addProduct(SelelectProduct.ID);
            }

        }
        public void addProduct(int ProductID)
        {
            if (Static.user != null)
            {
                Product_Basket product = Core.Context.Product_Basket.FirstOrDefault(u => u.ProductID == ProductID && u.UserID == Static.user.ID);
                if (product != null)
                {
                    product.Count += 1;
                }
                else
                {
                    Product_Basket NewPrB = new Product_Basket(ProductID, Static.user.ID, 1);
                    Core.Context.Product_Basket.Add(NewPrB);

                }
                Core.Context.SaveChanges();
            }

        }
    }
}
