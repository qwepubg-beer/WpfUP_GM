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
    /// Логика взаимодействия для BookInfo.xaml
    /// </summary>
    public partial class BookInfo : Page
    {
        public BookInfo()
        {
            InitializeComponent();
            DataContext = Static.ChoosingBook;
            LoadRewiew();
        }
        private void LoadRewiew()
        {
            RewiewList.ItemsSource=Core.GMEntities.Rewiew.Where(a =>a.BookID== Static.ChoosingBook.id).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Static.user!=null && RewiewList.ItemsSource !=null)
            { 
                var orderWindow = new RewiewWindow();
                orderWindow.Owner = Window.GetWindow(this);
                bool? dialogResult = orderWindow.ShowDialog();
                if (dialogResult == true && orderWindow.IsConfirmed)
                {

                    string RewText = orderWindow.RewiewSting;
                    Report rep= new Report()
                    {
                        UserID = Static.user.id,
                        Text = RewText,
                        Rewiew = RewiewList.ItemsSource as Rewiew
                    };
                    Core.GMEntities.Report.Add(rep);
                    MessageBox.Show($"Жалоба отправлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Static.user!=null && RewiewList.ItemsSource !=null)
            {
                var orderWindow = new AddRewiew();
                orderWindow.Owner = Window.GetWindow(this);
                bool? dialogResult = orderWindow.ShowDialog();
                if (dialogResult == true && orderWindow.IsConfirmed)
                {

                    string RewText = orderWindow.RewiewSting;
                    double Rating = orderWindow.RatingFilm;
                    Rewiew rep = new Rewiew()
                    {
                        UserID = Static.user.id,
                        Text = RewText,
                        BookID = Static.ChoosingBook.id,
                        Rating = Rating
                    };
                    Core.GMEntities.Rewiew.Add(rep);
                    MessageBox.Show($"Отзыв отправлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
