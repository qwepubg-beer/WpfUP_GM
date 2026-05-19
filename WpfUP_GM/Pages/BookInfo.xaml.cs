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
    /// Логика взаимодействия для BookInfo.xaml
    /// </summary>
    public partial class BookInfo : Page
    {
        Book Book { get; set; }
        public BookInfo(Book book)
        {
            InitializeComponent();
            this.Book = book;
            DataContext = Book;
            LoadRewiew();
            LoadPage();
            Book = book;
        }
        private void LoadRewiew()
        {
            RewiewList.ItemsSource=Core.GMEntities.Rewiew.Where(a =>a.BookID== Book.id).ToList();
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
                    Core.GMEntities.SaveChanges();
                    MessageBox.Show($"Жалоба отправлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadRewiew();
                }
            }
        }
        private void LoadPage()
        {
            if(IsReg())
            {
                if (Static.user.RoleID == 2)
            {
                Autor.IsReadOnly = false;
                BookName.IsReadOnly = false;
                AutorButton.Visibility= Visibility.Visible;
            }
            }

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (IsReg())
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
                        BookID = Book.id,
                        Rating = Rating
                    };
                    Core.GMEntities.Rewiew.Add(rep);
                    Core.GMEntities.SaveChanges();
                    MessageBox.Show($"Отзыв отправлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadRewiew();
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // изменить книгу для автора
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if(IsReg())
            {
                BookInList editlist = new BookInList
                {
                    BookID = Book.id,
                    UserID = Static.user.id,
                    TypeListID =1,
                    ListID =1
                };
               Core.GMEntities.BookInList.Add(editlist);
               Core.GMEntities.SaveChanges();
            }
        }

        private void ReportAuthor_Click(object sender, RoutedEventArgs e)
        {
            if (IsReg())
            {
                var orderWindow = new RewiewWindow();
                orderWindow.Owner = Window.GetWindow(this);
                bool? dialogResult = orderWindow.ShowDialog();
                if (dialogResult == true && orderWindow.IsConfirmed)
                {
                    string RewText = orderWindow.RewiewSting;  
                    Report rep = new Report()
                    {
                        UserID = Static.user.id,
                        Text = RewText,
                        User1 = Book.User,
                    };
                    Core.GMEntities.Report.Add(rep);
                    Core.GMEntities.SaveChanges();
                    MessageBox.Show($"Отзыв отправлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
