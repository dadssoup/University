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
        dynamic tableRow;
        public ChooseWindow(ref Person? tableRow)
        {
            InitializeComponent();
            
            this.tableRow = tableRow;
            SearchList.ItemsSource = ApplicationContext.GetTable("People");
        }
        public ChooseWindow(ref Student? tableRow)
        {
            InitializeComponent();

            this.tableRow = tableRow;
            SearchList.ItemsSource = ApplicationContext.GetTable("Students");
        }
        public ChooseWindow(ref Teacher? tableRow)
        {
            InitializeComponent();

            this.tableRow = tableRow;
            SearchList.ItemsSource = ApplicationContext.GetTable("Teachers");
        }
        public ChooseWindow(ref Curriculum? tableRow)
        {
            InitializeComponent();

            this.tableRow = tableRow;
            SearchList.ItemsSource = ApplicationContext.GetTable("Curriculums");
        }
        public ChooseWindow(ref CurriculumRow? tableRow)
        {
            InitializeComponent();

            this.tableRow = tableRow;
            SearchList.ItemsSource = ApplicationContext.GetTable("CurriculumRows");
        }
        public ChooseWindow(ref Load? tableRow)
        {
            InitializeComponent();

            this.tableRow = tableRow;
            SearchList.ItemsSource = ApplicationContext.GetTable("Loads");
        }
        public ChooseWindow(ref Exam? tableRow)
        {
            InitializeComponent();

            this.tableRow = tableRow;
            SearchList.ItemsSource = ApplicationContext.GetTable("Exams");
        }
        public ChooseWindow(ref Group? tableRow)
        {
            InitializeComponent();

            this.tableRow = tableRow;
            SearchList.ItemsSource = ApplicationContext.GetTable("Groups");
        }
        public ChooseWindow(ref Faculty? tableRow)
        {
            InitializeComponent();

            this.tableRow = tableRow;
            SearchList.ItemsSource = ApplicationContext.GetTable("Faculties");
        }

        private void SearchList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tableRow = ((ListView)sender).SelectedValue;
            Close();
        }
    }
}
