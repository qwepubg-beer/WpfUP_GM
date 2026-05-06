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
    /// Логика взаимодействия для AddRewiew.xaml
    /// </summary>
    public partial class AddRewiew : Window
    {
        public bool IsConfirmed { get; private set; } = false;
        public string RewiewSting { get; private set; }
        public double RatingFilm { get; private set; }
        public AddRewiew()
        {
            InitializeComponent(); DataContext = this; RatingText.Text ="Рейтинг: ";
        }
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            RewiewSting = Text.Text;
            IsConfirmed = true;
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            IsConfirmed = false;
            Close();
        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            RatingFilm=Rating.Value;
            RatingText.Text =$"Рейтинг:{RatingFilm}";
        }
    }
}
