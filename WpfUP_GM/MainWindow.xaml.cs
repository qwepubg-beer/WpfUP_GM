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
using WpfUP_GM.Pages;
using static WpfUP_GM.Function;

namespace WpfUP_GM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new Katalog(false));

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if(MainFrame.NavigationService.CanGoBack)
            {
                MainFrame.NavigationService.GoBack();
            }
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Katalog(false));
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            if (IsReg()) 
            {
                MainFrame.NavigationService.Navigate(new AccInfoPage());
            }
            else
            {
                MainFrame.NavigationService.Navigate(new Enter());
            }
        }

        private void Block_Click(object sender, RoutedEventArgs e)
        {
            if (IsReg())
            {
                MainFrame.NavigationService.Navigate(new FreezePage());
            }
        }

        private void Author_Click(object sender, RoutedEventArgs e)
        {   
            if(IsReg())
            { 
            if (Static.user.RoleID == 2)
            {
                MainFrame.NavigationService.Navigate(new AuthorPage());
            }
            else
            {
                if (Static.user != null)
                {
                    var orderWindow = new FreezeWindow();
                    orderWindow.Owner = Window.GetWindow(this);
                    bool? dialogResult = orderWindow.ShowDialog();
                    if (dialogResult == true && orderWindow.IsConfirmed)
                    {
                        string RewText = orderWindow.TextFr;
                        Bid rep = new Bid()
                        {
                            UserID = Static.user.id,
                            Text = RewText,
                            TypeBid = 1,
                            IsCompleted = false,
                        };
                        Core.GMEntities.Bid.Add(rep);
                        MessageBox.Show($"Заявка на автора отправлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            }
        }
    }
}
