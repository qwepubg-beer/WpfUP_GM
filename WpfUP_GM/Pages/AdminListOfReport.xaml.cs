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
    /// Логика взаимодействия для AdminListOfReport.xaml
    /// </summary>
    public partial class AdminListOfReport : Page
    {
        public AdminListOfReport(bool a)
        {
            InitializeComponent();
            if (a)
            {
                ReportList.ItemsSource = Core.GMEntities.Report.ToList();
            }
            else
            {
                ReportList.ItemsSource = Core.GMEntities.Report.Where(b=> b.User1==Static.user || b.Book.User== Static.user).ToList();
            }
            
        }
    }
}
