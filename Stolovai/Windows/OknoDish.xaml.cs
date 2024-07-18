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

namespace Stolovai.Windows
{
    /// <summary>
    /// Логика взаимодействия для OknoDish.xaml
    /// </summary>
    public partial class OknoDish : Window
    {
        Dish contextDish;
        public OknoDish(Dish dish)
        {
            InitializeComponent();
            contextDish = dish;
            DataContext = contextDish;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(contextDish.Name) || string.IsNullOrEmpty(contextDish.Name))
            {
                MessageBox.Show("Заполните поля!");
                return;
            }

            SaveDish();
        }

        private async void SaveDish()
        {
            if (contextDish.Id == 0)
                await NetManage.Set($"/api/dishes/{App.selectedSchool}/add/{contextDish.Name}/{contextDish.Count}/{contextDish.IsHereInt}");
            else
                await NetManage.Set($"/api/dishes/{App.selectedSchool}/set/{contextDish.Name}/{contextDish.Count}/{contextDish.IsHereInt}");
            DialogResult = true;
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите удалить?", "Оповещение", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                return;

            DelDish();
        }

        private async void DelDish()
        {
            await NetManage.Set($"/api/dishes/{App.selectedSchool}/del/{contextDish.Name}");
            DialogResult = true;
        }
    }
}
