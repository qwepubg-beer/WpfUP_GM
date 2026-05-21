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
    /// Логика взаимодействия для ListOfBook.xaml
    /// </summary>
    public partial class ListOfBook : Page
    {
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
        int type = 0;
        private bool isDirty = false;
        // Источник данных для всех комбобоксов
        public List<TypeBookList> TypeBookList { get; set; }

        public ListOfBook(int a)
        {
            InitializeComponent();
            type = a;
            LoadTypeBookList();
            LoadData();
        }
        void LoadTypeBookList()
        {
            TypeBookList = Core.GMEntities.TypeBookList.ToList();
        }

        void LoadData()
        {
            ProductList.ItemsSource = Core.GMEntities.BookInList.Where(b => b.UserID == Static.user.id && b.TypeListID == type).ToList(); isDirty = false;
        }
        private void Read_Click(object sender, RoutedEventArgs e)
        {
            if (ProductList.SelectedItem is BookInList book)
            {
                Book book1 = Core.GMEntities.Book.Find(book.BookID);
                mainWindow.MainFrame.NavigationService.Navigate(new ReadBook(book1));
            }
        }

        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            isDirty = true;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Core.GMEntities.SaveChanges();
                LoadData(); // обновляет список и сбрасывает флаг isDirty
                MessageBox.Show("Изменения успешно сохранены.", "Сохранение",
                                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
