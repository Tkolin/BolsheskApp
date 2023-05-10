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
    /// Логика взаимодействия для AddEditEventPage.xaml
    /// </summary>
    public partial class AddEditEventPage : Page
    {
        Event @event;
        bool add;
        public AddEditEventPage()
        {
            InitializeComponent();
            this.@event = new Event();
            add = true;
        }
        public AddEditEventPage(Event @event)
        {
            InitializeComponent();
            this.@event = @event;
            add = false;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            tb5.ItemsSource = BolsheskDBEntities.GetContext().TypeEvent.ToList();
            tb5.DisplayMemberPath = "Name";

            tb6.ItemsSource = BolsheskDBEntities.GetContext().User.ToList();
            tb6.DisplayMemberPath = "Login";

            tb7.ItemsSource = BolsheskDBEntities.GetContext().Place.ToList();
            tb7.DisplayMemberPath = "Name";


            if (!add)
            {
                tb1.Text = @event.Name;
                tb2.Text = @event.Description;
                tb3.SelectedDate = @event.DateStart;
                tb4.SelectedDate = @event.DateEnd;
                tb5.SelectedItem = @event.TypeEvent;
                tb6.SelectedItem = @event.User;
                tb7.SelectedItem = @event.Place;
                tb8.Text = @event.Quantity.ToString();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                @event.Name = tb1.Text;
                @event.Description = tb2.Text;
                @event.DateStart = tb3.SelectedDate;
                @event.DateEnd = tb4.SelectedDate;
                @event.TypeEvent = tb5.SelectedItem as TypeEvent;
                @event.User = tb6.SelectedItem as User;
                @event.Place = tb7.SelectedItem as Place;
                @event.Quantity = Convert.ToInt32(tb8.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проверьте введёные данные!", ex.Message);
                return;
            }
            try
            {
                if (add)
                    BolsheskDBEntities.GetContext().Event.Add(@event);
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
