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
    /// Логика взаимодействия для ManagerPlasePage.xaml
    /// </summary>
    public partial class ManagerPlasePage : Page
    {
        public ManagerPlasePage()
        {
            InitializeComponent();
        }
        public void Filter()
        {
            List<Place> places = BolsheskDBEntities.GetContext().Place.ToList();

            if (tBoxSearch.Text.Length > 0)
            {
                string src = tBoxSearch.Text.ToLower();
                places = places.Where(e => e.Name.ToLower().Contains(src) ||
                                              e.TypePlace.Name.ToString().ToLower().Contains(src) ||
                                              e.Area.ToString().ToString().ToLower().Contains(src) ||
                                              e.Adress.ToLower().Contains(src) ||
                                              e.Capacity.ToString().ToLower().Contains(src)
                                              ).ToList();
            }

            dataGrid.ItemsSource = places;
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

        }

        private void btnDelet_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem == null)
                return;

            Place place = dataGrid.SelectedItem as Place;
            try
            {
                BolsheskDBEntities.GetContext().Place.Remove(place);
                BolsheskDBEntities.GetContext().SaveChanges();
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
