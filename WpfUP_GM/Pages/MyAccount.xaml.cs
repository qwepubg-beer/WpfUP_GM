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
    /// Логика взаимодействия для MyAccount.xaml
    /// </summary>
    public partial class MyAccount : Page
    {
        public MyAccount()
        {
            DataContext = Static.user;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
                        TypeBid = 2,
                        IsCompleted = false,
                    };
                    Core.GMEntities.Bid.Add(rep);
                    MessageBox.Show($"Заявка отправлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
