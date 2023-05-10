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
            tb2.ItemsSource = BolsheskDBEntities.GetContext().TypePlace.ToList();
            tb2.DisplayMemberPath = "Name";



            if (!add)
            {
                tb1.Text = place.Name;
                tb2.SelectedItem = place.TypePlace;
                tb3.Text = place.Area.ToString();
                tb4.Text = place.Adress;
                tb5.Text = place.Capacity.ToString();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                place.Name = tb1.Text;
                place.TypePlace = tb2.SelectedItem as TypePlace ;
                place.Area = Convert.ToInt32( tb3.Text);
                place.Adress = tb4.Text;
                place.Capacity = Convert.ToInt32( tb5.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проверьте введёные данные!", ex.Message);
                return;
            }
            try
            {
                if (add)
                    BolsheskDBEntities.GetContext().Place.Add(place);
                BolsheskDBEntities.GetContext().SaveChanges();
                NavigationService.GoBack    ();
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
