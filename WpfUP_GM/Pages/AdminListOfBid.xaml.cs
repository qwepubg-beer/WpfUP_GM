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
    /// Логика взаимодействия для AdminListOfBid.xaml
    /// </summary>
    public partial class AdminListOfBid : Page
    {
        public AdminListOfBid(TypeBid bidtype)
        {
            InitializeComponent();
            //сделать проверку на тип switch
            BidList.ItemsSource = Core.GMEntities.Bid.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
