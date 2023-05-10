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

namespace BolsheskApp
{
    /// <summary>
    /// Логика взаимодействия для ManagerUserPage.xaml
    /// </summary>
    public partial class ManagerUserPage : Page
    {
        public ManagerUserPage()
        {
            InitializeComponent();
        }
        public void Filter()
        {
            List<User> users = BolsheskDBEntities.GetContext().User.ToList();

            if (tBoxSearch.Text.Length > 0)
            {
                string src = tBoxSearch.Text.ToLower();
                users = users.Where(e => e.FirstName.ToLower().Contains(src) ||
                                         e.LastName.ToLower().Contains(src) ||
                                         e.Patronymic.ToLower().Contains(src) ||
                                         e.Post.Name.ToLower().Contains(src) ||
                                         e.Login.ToLower().Contains(src) ||
                                         e.Role.Название.ToLower().Contains(src)).ToList();
            }

            dataGrid.ItemsSource = users;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem == null)
                return;
        }

        private void btnDelet_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem == null)
                return;

            User user = dataGrid.SelectedItem as User;
            try
            {
                BolsheskDBEntities.GetContext().User.Remove(user);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Filter();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void tBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            tBoxSearch.Text = "";
        }
    }
}
