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
    /// Логика взаимодействия для NavigationPage.xaml
    /// </summary>
    public partial class NavigationPage : Page
    {
        User user;
        public NavigationPage()
        {
            InitializeComponent();
        }
        public NavigationPage(User user)
        {
            InitializeComponent();
            this.user = user;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if(user.RoleID == 2)
            {
                btn2.Visibility = Visibility.Collapsed;
                btn3.Visibility = Visibility.Collapsed;
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManagerEventPage());
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManagerUserPage());
        }

        private void btn33_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManagerShebulePage());
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManagerPlasePage());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
