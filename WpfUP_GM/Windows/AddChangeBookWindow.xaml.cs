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
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace WpfUP_GM.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddChangeBookWindow.xaml
    /// </summary>
    public partial class AddChangeBookWindow : Window
    {
        public bool IsConfirmed { get; private set; } = false;
        public Book ChangesBook { get; private set;}
        public ICollection<GenreBook> GenresBook { get; private set; }
        public AddChangeBookWindow(Book book=null)
        {
            InitializeComponent();
            ChangesBook=book;
            GenreComboBox.ItemsSource = Core.GMEntities.Genre.ToList();
            LoadData(); 
            DataContext=ChangesBook;
        }
        void LoadData()
        {
            if (ChangesBook!=null)
            {
                GenresBook = ChangesBook.GenreBook;
                GenresList.ItemsSource=GenresBook;
            }
        }
        void Save()
        {
            foreach (GenreBook g in GenresBook)
            {
                if (ChangesBook.GenreBook.Contains(g)) 
                {
                    
                }
                else
                {
                    
                }
            }
        }
        private void DeleteGenre_Click(object sender, RoutedEventArgs e)
        {
            if (GenresList.SelectedItem!=null)
            { 
               Genre genre = GenresList.SelectedItem as Genre;
               GenreBook genreBook = GenresBook.FirstOrDefault(a => a.BookID == ChangesBook.id && a.GenreID == genre.id);
                if (genreBook != null)
                {
                    GenresBook.Remove(genreBook);
                }
            }
        }

        private void AddGenre_Click(object sender, RoutedEventArgs e)
        {
            Genre genre = GenreComboBox.SelectedItem as Genre;
            GenreBook genreBook = GenresBook.FirstOrDefault(a => a.BookID == ChangesBook.id && a.GenreID == genre.id);
            if (genreBook == null)
            {
                GenreBook newgenreBook = new GenreBook()
                {
                    id = 0,
                    GenreID = genre.id,
                    BookID = ChangesBook.id
                };
                GenresBook.Add(newgenreBook);
            }
        }
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            Book changeBook = Core.GMEntities.Book.Find(ChangesBook.id);
            changeBook.Name=BookName.Text;
            changeBook.Text=BookText.Text;
            Core.GMEntities.SaveChanges();
            IsConfirmed = true;
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            IsConfirmed = false;
            Close();
        }
    }
}
