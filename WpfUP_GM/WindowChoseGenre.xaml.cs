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

namespace WpfUP_GM
{
    /// <summary>
    /// Логика взаимодействия для WindowChoseGenre.xaml
    /// </summary>
    public partial class WindowChoseGenre : Window
    {
        private Book BookGanre { get; set; }
        private List<GenreClass> Ganre { get; set; }
        public WindowChoseGenre(Book book)
        {
            InitializeComponent();
            BookGanre = book;   
        }
        public void LoadData()
        {
            foreach(GenreBook b in BookGanre.GenreBook)
            {
                
            }
        }
    }
}
