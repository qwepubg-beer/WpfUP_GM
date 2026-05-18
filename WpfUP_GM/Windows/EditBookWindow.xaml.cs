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

namespace WpfUP_GM.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditBookWindow.xaml
    /// </summary>
    public partial class EditBookWindow : Window
    {
        public bool IsConfirmed { get; private set; } = false;
        Book Book { get; set; }
        int paramentr { get; set; } 
        public EditBookWindow(int par,Book book)
        {
            InitializeComponent();
            DataContext = book;
            paramentr = par;
            if(paramentr == 0)
            {
                MainButton.Content = "изменить";
            }
            else
            {
                MainButton.Content = "добавить";
            }
        }
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (paramentr == 0)
            {
                Book editbook = Core.GMEntities.Book.Find(Book.id);
                editbook.Text = Text.Text;
                editbook.Name = NameBook.Text;
                Core.GMEntities.SaveChanges();
                //+жанры
            }
            else
            {
                //добавлене
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
