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
using WpfUP_GM.Windows;

namespace WpfUP_GM.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorPage.xaml
    /// </summary>
    public partial class AuthorPage : Page
    {
        public AuthorPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Authorframe.NavigationService.Navigate(new Katalog(true));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Authorframe.NavigationService.Navigate(new AdminListOfReport(false));

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var bookWindow = new AddChangeBookWindow(book: null, authorId: Static.user.id);
            bookWindow.Owner = Window.GetWindow(this);
            bool? result = bookWindow.ShowDialog();
            if (result == true && bookWindow.IsConfirmed)
            {
                MessageBox.Show("Книга успешно добавлена!", "Успех",
                                MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
