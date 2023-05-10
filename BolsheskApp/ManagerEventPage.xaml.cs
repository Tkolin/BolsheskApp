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
    /// Логика взаимодействия для ManagerEventPage.xaml
    /// </summary>
    public partial class ManagerEventPage : Page
    {
        public ManagerEventPage()
        {
            InitializeComponent();
        }
        public void Filter()
        {
            List<Event> events = BolsheskDBEntities.GetContext().Event.ToList();

            if (tBoxSearch.Text.Length > 0)
            {
                string src = tBoxSearch.Text.ToLower();
                events = events.Where(e => e.Name.ToLower().Contains(src) ||
                                              e.Description.ToString().ToLower().Contains(src) ||
                                              e.User.LastName.ToString().ToLower().Contains(src) ||
                                              e.TypeEvent.Name.ToString().ToLower().Contains(src) ||
                                              e.Place.Name.ToString().ToLower().Contains(src) ||
                                              e.Place.Adress.ToString().ToLower().Contains(src)
                                              ).ToList();
            }

            dataGrid.ItemsSource = events;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Filter();
        }



        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            tBoxSearch.Text = "";
        }

        private void tBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
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

            Event @event = dataGrid.SelectedItem as Event;
            try
            {
                BolsheskDBEntities.GetContext().Event.Remove(@event);
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

        private void btnEditQuast_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
