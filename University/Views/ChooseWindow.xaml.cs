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
using University.Data;

namespace University.Views
{
    /// <summary>
    /// Логика взаимодействия для ChooseWindow.xaml
    /// </summary>
    public partial class ChooseWindow : Window
    {
        public event EventHandler<dynamic>? ValueSelected;
        dynamic SourceCollection;

        //dynamic FilteredCollection;
        //bool isFiltered = false;
        public ChooseWindow(string searchKey)
        {
            InitializeComponent();
            
            SourceCollection = ApplicationContext.GetTable(searchKey);
            //FilteredCollection = SourceCollection;
            SearchList.ItemsSource = SourceCollection;
        }

        private void SearchList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ValueSelected?.Invoke(this, ((ListView)sender).SelectedValue);
            Close();
        }
    }
}
