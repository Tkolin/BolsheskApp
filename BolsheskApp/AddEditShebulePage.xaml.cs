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
    /// Логика взаимодействия для AddEditShebulePage.xaml
    /// </summary>
    public partial class AddEditShebulePage : Page
    {
        Schedule schedule;
        bool add;
        public AddEditShebulePage()
        {
            InitializeComponent();
            this.schedule = new Schedule();
            this.add = true;
        }
        public AddEditShebulePage(Schedule schedule)
        {
            InitializeComponent();
            this.schedule = schedule;
            this.add = false;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnSaveQuas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddQuast_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
