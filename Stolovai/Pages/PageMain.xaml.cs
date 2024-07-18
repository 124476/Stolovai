using Stolovai.Models;
using Stolovai.Servies;
using Stolovai.Windows;
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
using System.Windows.Threading;

namespace Stolovai.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        public PageMain()
        {
            InitializeComponent();
            App.selectedSchool = 1;

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(3);
            dispatcherTimer.Tick += RefreshTimer;
            dispatcherTimer.Start();

            GetSchools();
        }

        private async void GetSchools()
        {
            ComboSchools.ItemsSource = (await NetManage.Get<List<School>>("/api/schools")).ToList();
            while (ComboSchools.Items.Count == 0)
                continue;

            ComboSchools.SelectedIndex = 0;
        }

        private void RefreshTimer(object sender, EventArgs e)
        {
            Refresh();
        }

        private async void Refresh()
        {
            if (ComboSchools.Items.Count == 0)
                return;
            ListDishes.ItemsSource = (await NetManage.Get<List<Dish>>($"/api/dishes/{App.selectedSchool}")).ToList();
            ListDishesNow.ItemsSource = (await NetManage.Get<List<Dish>>($"/api/dishes/{App.selectedSchool}/now")).ToList();
        }

        private void ListDishes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dish = ListDishes.SelectedItem as Dish;
            if (dish == null)
                return;
            var dialog = new OknoDish(dish);
            if (dialog.ShowDialog().GetValueOrDefault())
                Refresh();
        }

        private void NewDish_Click(object sender, RoutedEventArgs e)
        {
            var dish = new Dish();
            dish.Id = 0;
            dish.IsHere = false;
            var dialog = new OknoDish(dish);
            if (dialog.ShowDialog().GetValueOrDefault())
                Refresh();
        }

        private void ComboSchools_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var school = ComboSchools.SelectedItem as School;
            if (school == null)
                return;

            App.selectedSchool = school.Id;
            Refresh();
        }

        private void SetSchools_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OknoSchools();
            dialog.ShowDialog();
            GetSchools();
        }
    }
}
