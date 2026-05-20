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
using static System.Net.Mime.MediaTypeNames;
using static WpfUP_GM.Function;
namespace WpfUP_GM.Pages
{
    /// <summary>
    /// Логика взаимодействия для Regestaration.xaml
    /// </summary>
    public partial class Regestaration : Page
    {
        public Regestaration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Reg(login.Text, Email.Text, name.Text, password.Password))
            {
                MessageBox.Show("Вы зарегистрированы");
            }
        }
    }
}
