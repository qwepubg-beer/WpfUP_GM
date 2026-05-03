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
        }

        private void TypeListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (TypeListComboBox.SelectedIndex)
            {
                case 1: //навигация по листам с книгами
                    break;
                case 2: 
                    break;
                case 3: 
                    break;
                case 4: 
                    break;
            }

        }

        private void Freeze_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Rewiews_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MyAccount_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
