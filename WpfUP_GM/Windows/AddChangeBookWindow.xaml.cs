using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
namespace WpfUP_GM.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddChangeBookWindow.xaml
    /// </summary>
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq;
    using System.Windows;

    public partial class AddChangeBookWindow : Window
    {
        public bool IsConfirmed { get; private set; } = false;
        public Book ChangesBook { get; private set; }
        public ObservableCollection<GenreBook> GenresBook { get; private set; }
        private int _authorId;
        public AddChangeBookWindow(Book book = null, int authorId = 0)
        {
            InitializeComponent();

            _authorId = authorId;

            if (book == null)
            {
                ChangesBook = new Book
                {
                    id = 0,               
                    Author = authorId,    
                    IsActive = true,      
                    Rating = 0
                };
                GenresBook = new ObservableCollection<GenreBook>();
            }
            else
            {
                ChangesBook = book;
                var existingGenres = Core.GMEntities.GenreBook.Where(gb => gb.BookID == book.id).ToList();
                GenresBook = new ObservableCollection<GenreBook>(existingGenres);
            }

            DataContext = ChangesBook;
            GenreComboBox.ItemsSource = Core.GMEntities.Genre.ToList();
            GenresList.ItemsSource = GenresBook;
        }

        private void DeleteGenre_Click(object sender, RoutedEventArgs e)
        {
            if (GenresList.SelectedItem is GenreBook selectedGenreBook)
            {
                GenresBook.Remove(selectedGenreBook);
            }
        }

        private void AddGenre_Click(object sender, RoutedEventArgs e)
        {
            if (GenreComboBox.SelectedItem is Genre selectedGenre)
            {
                bool alreadyExists = GenresBook.Any(gb => gb.GenreID == selectedGenre.id);
                if (!alreadyExists)
                {
                    var newGenreBook = new GenreBook
                    {
                        BookID = ChangesBook.id,
                        GenreID = selectedGenre.id
                    };
                    GenresBook.Add(newGenreBook);
                }
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (ChangesBook.id == 0)
            {
                var newBook = new Book
                {
                    Name = BookName.Text,
                    Text = BookText.Text,
                    Cover = BookCover.Text,
                    Author = _authorId,
                    Description = BookDescription.Text,
                    IsActive = true,
                    Rating = 0
                };
                foreach (var gb in GenresBook)
                {
                    newBook.GenreBook.Add(new GenreBook
                    {
                        GenreID = gb.GenreID
                    });
                }

                Core.GMEntities.Book.Add(newBook);
                Core.GMEntities.SaveChanges();
                ChangesBook = newBook;
            }
            else
            {
                var bookFromDb = Core.GMEntities.Book
                                    .Include(b => b.GenreBook)
                                    .FirstOrDefault(b => b.id == ChangesBook.id);

                if (bookFromDb == null)
                {
                    MessageBox.Show("Книга не найдена в базе данных.");
                    return;
                }

                bookFromDb.Name = BookName.Text;
                bookFromDb.Text = BookText.Text;
                bookFromDb.Cover = BookCover.Text;
                bookFromDb.Description = BookDescription.Text;
                bookFromDb.GenreBook.Clear();
                foreach (var gb in GenresBook)
                {
                    bookFromDb.GenreBook.Add(new GenreBook
                    {
                        BookID = bookFromDb.id,
                        GenreID = gb.GenreID
                    });
                }

                Core.GMEntities.SaveChanges();
            }
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
