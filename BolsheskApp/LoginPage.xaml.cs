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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (GetRole(tb1.Text, tb2.Text) == null)
                MessageBox.Show("Проверьте введёные данные!");
            else
                NavigationService.Navigate(new NavigationPage(GetRole(tb1.Text, tb2.Text)));

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
           //выход
        }
        private User GetRole(string login, string pass)
        {
            return BolsheskDBEntities.GetContext().User.Where(u => u.Login == login && u.Password == pass).First();
        }
    }
}
