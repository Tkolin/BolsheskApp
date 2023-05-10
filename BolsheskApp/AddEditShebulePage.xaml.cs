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
        Event @event;
        public AddEditShebulePage()
        {
            InitializeComponent();
            this.schedule = new Schedule();
            Event @event = null;
            this.add = true;
        }
        public AddEditShebulePage(Schedule schedule)
        {
            InitializeComponent();
            this.schedule = schedule;
            this.@event = schedule.Event;
            this.add = false;
        }

        public AddEditShebulePage(Event @event)
        {
            InitializeComponent();
            this.@event = @event;
            this.schedule = new Schedule();
            this.add = true;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            tb3.ItemsSource = BolsheskDBEntities.GetContext().Status.ToList();
            tb3.DisplayMemberPath = "Name";

            tb5.ItemsSource = BolsheskDBEntities.GetContext().User.ToList();
            tb5.DisplayMemberPath = "LastName";



            tm2.ItemsSource = BolsheskDBEntities.GetContext().Schedule.ToList();
            tm2.DisplayMemberPath = "LastName";

            if (!add)
            {
                tb1.Text = schedule.Name;
                tb2.Text = schedule.Description;
                tb3.SelectedItem = schedule.Status;
                tb4.SelectedDate = schedule.Date;
                tb5.SelectedItem = schedule.User;

                tm1.SelectedItem = schedule.Event;
            }
        }
        private void tm1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(tm1.SelectedItem == null)
                return;

            @event = tm1.SelectedItem as Event;

            tm1.ItemsSource = BolsheskDBEntities.GetContext().Schedule
                .Where(g => g.Event.ID == @event.ID).ToList();
        }
        private void tm2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tm2.SelectedItem == null)
                return;

            schedule = tm2.SelectedItem as Schedule;

            tb1.Text = schedule.Name;
            tb2.Text = schedule.Description;
            tb3.SelectedItem = schedule.Status;
            tb4.SelectedDate = schedule.Date;
            tb5.SelectedItem = schedule.User;

            add = false;
        }
        private void btnAddQuast_Click(object sender, RoutedEventArgs e)
        {
            tb1.Text = "";
            tb2.Text = "";
            tb3.SelectedItem = null;
            tb4.SelectedDate = null;
            tb5.SelectedItem = null;

            schedule = new Schedule();
            add = true;

        }
        private void btnSaveQuas_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                schedule.Name = tb1.Text;
                schedule.Description = tb2.Text;
                schedule.Status = tb3.SelectedItem as Status;
                schedule.Date = tb4.SelectedDate;
                schedule.User = tb5.SelectedItem as User;
                schedule.Event = tm1.SelectedItem as Event;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проверьте введёные данные!", ex.Message);
                return;
            }
            try
            {
                if (add)
                    BolsheskDBEntities.GetContext().Schedule.Add(schedule);
                BolsheskDBEntities.GetContext().SaveChanges();

                btnAddQuast_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!", ex.Message);

            }
        }



        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (tm2.SelectedItem == null)
                return;


            try
            {
           
                BolsheskDBEntities.GetContext().Schedule.Remove(tm2.SelectedItem as Schedule);
                BolsheskDBEntities.GetContext().SaveChanges();

                btnAddQuast_Click(sender, e);
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
