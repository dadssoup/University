using Microsoft.EntityFrameworkCore;
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

            
        }

        private void RowsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
