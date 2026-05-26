using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private MainWindow _mainWindow = Application.Current.MainWindow as MainWindow;
        private bool _isDirty = false;
        private TypeBookList _currentTypeList = null;
        public static readonly DependencyProperty AvailableTypesProperty = DependencyProperty.Register(nameof(AvailableTypes), typeof(List<TypeBookList>), typeof(ListOfBook), new PropertyMetadata(null));

        public List<TypeBookList> AvailableTypes
        {
            get { return (List<TypeBookList>)GetValue(AvailableTypesProperty); }
            set { SetValue(AvailableTypesProperty, value); }
        }

        public ListOfBook(TypeBookList typeList)
        {
            InitializeComponent();
            DataContext = this;
            _currentTypeList = typeList;

            LoadTypeBookList();
            LoadData();
        }

        private void LoadTypeBookList()
        {
            AvailableTypes = Core.GMEntities.TypeBookList.ToList();
        }

        private void LoadData()
        {
            ProductList.ItemsSource = Core.GMEntities.BookInList.Where(b => b.UserID == Static.user.id && b.TypeListID == _currentTypeList.id).ToList();
            _isDirty = false;
        }

        private void Read_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is BookInList bookInList)
            {
                var book = Core.GMEntities.Book.Find(bookInList.BookID);
                if (book != null)
                {
                    _mainWindow.MainFrame.NavigationService.Navigate(new ReadBook(book));
                }
            }
        }

        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _isDirty = true;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Core.GMEntities.SaveChanges();
                LoadData();
                MessageBox.Show("Изменения успешно сохранены.", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
