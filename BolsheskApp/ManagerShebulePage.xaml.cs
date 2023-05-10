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
    /// Логика взаимодействия для ManagerShebulePage.xaml
    /// </summary>
    public partial class ManagerShebulePage : Page
    {
        public ManagerShebulePage()
        {
            InitializeComponent();
        }
        public void Filter()
        {
            List<Schedule> shedules = BolsheskDBEntities.GetContext().Schedule.ToList();

            if (tBoxSearch.Text.Length > 0)
            {
                string src = tBoxSearch.Text.ToLower();
                shedules = shedules.Where(e => e.Name.ToLower().Contains(src) ||
                                              (e.Event!= null &&
                                              e.Event.Name.ToLower().Contains(src)) ||
                                              e.Description.ToString().ToString().ToLower().Contains(src) ||
                                              (e.User!= null &&
                                              e.User.LastName.ToLower().Contains(src)) ||
                                              (e.Status!= null &&
                                              e.Status.Name.ToLower().Contains(src))
                                              ).ToList();
            }

            dataGrid.ItemsSource = shedules;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditShebulePage());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem == null)
                return;

            NavigationService.Navigate(new AddEditShebulePage(dataGrid.SelectedItem as Schedule));
        }

        private void btnDelet_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem == null)
                return;

            Schedule schedule = dataGrid.SelectedItem as Schedule;
            try
            {
                BolsheskDBEntities.GetContext().Schedule.Remove(schedule);
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
