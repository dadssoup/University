using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using University.Data;

namespace University.Views
{
    /// <summary>
    /// Логика взаимодействия для CatalogsPage.xaml
    /// </summary>
    public partial class CatalogsPage : Page
    {
        public ObservableCollection<string> Catalogs = new()
        {
            "Студенты",
            "Преподаватели",
            "Физические лица",
            "Нагрузка",
            "Ведомости", 
            "Учебные планы",
            "Записи учебного плана",
            "Группы", 
            "Факультеты",
            "Дипломы",
            "Диссертации"
        };
        public CatalogsPage()
        {
            InitializeComponent();
            CatalogsList.ItemsSource = Catalogs;
        }

        private void CatalogsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var CatalogsPage = new CatalogRowsPage(((System.Windows.Controls.Primitives.Selector)sender).SelectedItem as string);
            this.NavigationService.Navigate(CatalogsPage);
        }
    }
    
}
