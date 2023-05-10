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
    /// Логика взаимодействия для AddEditUserPage.xaml
    /// </summary>
    public partial class AddEditUserPage : Page
    {
        User user;
        bool add;
        public AddEditUserPage()
        {
            InitializeComponent();
            this.user = new User();
            this.add = true;
        }
        public AddEditUserPage(User user)
        {
            InitializeComponent();
            this.user = user;
            this.add = false;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            tb6.ItemsSource = BolsheskDBEntities.GetContext().Role.ToList();
            tb6.DisplayMemberPath = "Название";

            tb7.ItemsSource = BolsheskDBEntities.GetContext().Post.ToList();
            tb7.DisplayMemberPath = "Name";


            if (!add)
            {
                tb1.Text = user.FirstName;
                tb2.Text = user.LastName;
                tb3.Text = user.Patronymic;
                tb4.Text = user.Login;
                tb5.Text = user.Password;
                tb6.SelectedItem = user.Role;
                tb7.SelectedItem = user.Post;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                user.FirstName = tb1.Text;
                user.LastName = tb2.Text;
                user.Patronymic = tb3.Text;
                user.Login = tb4.Text;
                user.Password = tb5.Text;
                user.Role = tb6.SelectedItem as Role;
                user.Post = tb7.SelectedItem as Post;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Проверьте введёные данные!", ex.Message);
                return;
            }
            try
            {
                if (add)
                    BolsheskDBEntities.GetContext().User.Add(user);
                BolsheskDBEntities.GetContext().SaveChanges();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!", ex.Message);

            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
