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
                    GenreBook newgenreBook = new GenreBook()
                    {
                        GenreID = GenresList.SelectedIndex,
                        BookID = ChangesBook.id
                    };
                    Core.GMEntities.GenreBook.Add(genreBook);
                    Core.GMEntities.SaveChanges();
                    LoadData();
                }
                else
                {
                    GenreBook genreBook = Core.GMEntities.GenreBook.FirstOrDefault(a => a.BookID == ChangesBook.id && a.GenreID == genre.id);
                    if (genreBook != null)
                    {
                        Core.GMEntities.GenreBook.Remove(genreBook);
                        Core.GMEntities.SaveChanges();
                    }
                }
            }
        }
        private void DeleteGenre_Click(object sender, RoutedEventArgs e)
        {
            if (GenresList.SelectedItem!=null)
            { 
               Genre genre= GenresList.SelectedItem as Genre;
               GenresBook.Remove(genre);
               GenreBook genreBook = Core.GMEntities.GenreBook.FirstOrDefault(a => a.BookID==ChangesBook.id && a.GenreID==genre.id);
                if (genreBook!=null) 
                {
                    Core.GMEntities.GenreBook.Remove(genreBook);
                    Core.GMEntities.SaveChanges();
                }
                LoadData();
            }
        }

        private void AddGenre_Click(object sender, RoutedEventArgs e)
        {
            GenresBook.Add(GenreComboBox.SelectedItem as Genre);
            GenreBook genreBook = new GenreBook()
            {
                GenreID=GenresList.SelectedIndex,
                BookID=ChangesBook.id
            };
            Core.GMEntities.GenreBook.Add(genreBook);
            Core.GMEntities.SaveChanges();
            LoadData();
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
