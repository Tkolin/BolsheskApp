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
    /// Логика взаимодействия для AddEditPlasePage.xaml
    /// </summary>
    public partial class AddEditPlasePage : Page
    {
        Place place;
        bool add;
        public AddEditPlasePage()
        {
            InitializeComponent();
            this.place = new Place();
            this.add = true;
        }
        public AddEditPlasePage(Place place)
        {
            InitializeComponent();
            this.place = place;
            this.add = false;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
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
