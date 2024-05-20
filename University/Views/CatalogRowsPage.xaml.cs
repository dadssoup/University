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
    /// Логика взаимодействия для CatalogRowsPage.xaml
    /// </summary>
    public partial class CatalogRowsPage : Page
    {
        
        public CatalogRowsPage()
        {
            InitializeComponent();
        }
        public CatalogRowsPage(string dbName)
        {
            InitializeComponent();
            var collection = ((DbSet<Student>)ApplicationContext.GetTable(dbName));
            collection.Load();
            RowsList.ItemsSource = collection.Local.ToObservableCollection();
            
            
        }

        private void RowsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            return;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var studentPage = new StudentPage();
            NavigationService.Navigate(studentPage);
        }
    }
}
