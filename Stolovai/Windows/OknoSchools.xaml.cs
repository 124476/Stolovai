using Stolovai.Models;
using Stolovai.Servies;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Stolovai.Windows
{
    /// <summary>
    /// Логика взаимодействия для OknoSchools.xaml
    /// </summary>
    public partial class OknoSchools : Window
    {
        School contextSchool;
        public OknoSchools()
        {
            InitializeComponent();
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(3);
            dispatcherTimer.Tick += GetSchools;
            dispatcherTimer.Start();

            Resresh();
            contextSchool = new School();
            DataContext = contextSchool;
        }

        private void GetSchools(object sender, EventArgs e)
        {
            Resresh();
        }

        private async void Resresh()
        {
            ListSchools.ItemsSource = (await NetManage.Get<List<School>>("/api/schools")).ToList();
        }

        private void DelBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите удалить?", "Оповещение", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                return;

            var school = (sender as TextBlock).DataContext as School;
            if (school == null)
                return;

            DelSchool(school);
        }

        private async void DelSchool(School school)
        {
            await NetManage.Set($"/api/schools/del/{school.Id}");
            Resresh();
        }

        private void SetBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            contextSchool = (sender as TextBlock).DataContext as School;
            DataContext = null;
            DataContext = contextSchool;
            SetText.Text = "*редактировать";
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(contextSchool.Name))
                return;

            AddSchool();
        }

        private async void AddSchool()
        {
            if (contextSchool.Id == 0)
                await NetManage.Set($"/api/schools/add/{contextSchool.Name}/{contextSchool.Password}");
            else
                await NetManage.Set($"/api/schools/set/{contextSchool.Id}/{contextSchool.Name}/{contextSchool.Password}");
            SetText.Text = "*новая школа";
            contextSchool = new School();
            DataContext = null;
            DataContext = contextSchool;
            Resresh();
        }
    }
}
