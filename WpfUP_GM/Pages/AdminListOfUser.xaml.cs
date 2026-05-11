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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfUP_GM.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminListOfUser.xaml
    /// </summary>
    public partial class AdminListOfUser : Page
    {
        public ObservableCollection<User> UsersList { get; set; }
        public List<Role> RolesList { get; set; }
        public AdminListOfUser()
        {
            InitializeComponent();
            LoadData();
            DataContext = this;
        }
        private void LoadData()
        {
            RolesList = Core.GMEntities.Role.ToList();
            UsersList = new ObservableCollection<User>(Core.GMEntities.User.Where(y => y.id != Static.user.id).ToList());
            UserDataGrid.ItemsSource = UsersList;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            UserDataGrid.CommitEdit();
            var result = MessageBox.Show("Сохранить все изменения?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    foreach (var user in UsersList)
                    {
                        if (user.id == 0)
                        {
                            var newProduct = new User
                            {
                                Name = user.Name,
                                login = user.login,
                                password = user.password,
                                IsActive = user.IsActive,
                                RoleID = user.ReturnRoleID()
                            };
                            Core.GMEntities.User.Add(newProduct);
                        }
                        else
                        {
                            var existingUser = Core.GMEntities.User.Find(user.id);
                            if (existingUser != null)
                            {
                                existingUser.Name = user.Name;
                                existingUser.login = user.login;
                                existingUser.password = user.password;
                                existingUser.IsActive = user.IsActive;
                                existingUser.RoleID = user.ReturnRoleID();
                            }
                        }
                    }
                    Core.GMEntities.SaveChanges();
                    LoadData();
                    MessageBox.Show("Сохранено успешно!", "Успех",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var newProduct = new User
            {
                id = 0,
                Name = "",
                login = "",
                password = "",
                email="",
                RoleID = RolesList.FirstOrDefault()?.id ?? 0,
                IsActive = true
            };

            UsersList.Add(newProduct);
            UserDataGrid.SelectedItem = newProduct;
            UserDataGrid.ScrollIntoView(newProduct);
        }

    }
}
