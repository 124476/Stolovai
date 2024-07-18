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
            ComboSchools.ItemsSource = new string[] { "Лицей имени Лобачевского" };
            ComboSchools.SelectedIndex = 0;
            App.selectedSchool = 1;

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(3);
            dispatcherTimer.Tick += RefreshTimer;
            dispatcherTimer.Start();
        }

        private void RefreshTimer(object sender, EventArgs e)
        {
            Refresh();
        }

        private async void Refresh()
        {
            ListDishes.ItemsSource = (await NetManage.Get<List<Dish>>("/api/dishes/1")).ToList();
            ListDishesNow.ItemsSource = (await NetManage.Get<List<Dish>>("/api/dishes/1/now")).ToList();
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
            App.selectedSchool = 1;
        }
    }
}
