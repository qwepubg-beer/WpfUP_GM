using System;
using System.Collections.Generic;
using System.Data;
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
            BidList.ItemsSource = Core.GMEntities.Bid.Where(a => a.TypeBid1 == bidtype).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (BidList.SelectedItem != null)
            {
                Bid bid = BidList.SelectedItem  as Bid;
                var result = MessageBox.Show($"Внести изменения?", "Предупреждение", MessageBoxButton.YesNo);
                switch (bid.TypeBid1.BidName)
                {
                    case "Получение роль автор":
                        if (result == MessageBoxResult.Yes) { User edituser = Core.GMEntities.User.Find(bid.User.id); edituser.RoleID = 2; Core.GMEntities.SaveChanges();}
                        break;
                    case "Разморозка аккаунта":
                        if (result == MessageBoxResult.Yes) { User edituser = Core.GMEntities.User.Find(bid.User.id); edituser.IsActive = true; Core.GMEntities.SaveChanges(); }
                        break;
                    case "Разморозка книги"://добавить книгу в bid
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
