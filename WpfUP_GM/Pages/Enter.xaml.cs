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
using static WpfUP_GM.Funcction;
namespace WpfUP_GM.Pages
{
    /// <summary>
    /// Логика взаимодействия для Enter.xaml
    /// </summary>
    public partial class Enter : Page
    {
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
        public Enter()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainFrame.NavigationService.Navigate(new Regestaration());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Funcction.Enter(log.Text,pasw.Password))
            {
                mainWindow.MainFrame.NavigationService.Navigate(new Katalog());
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
        }
    }
}
