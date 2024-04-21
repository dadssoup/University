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
            "Строки учебного плана",
            "Группы", 
            "Факультеты"
        };
        public CatalogsPage()
        {
            InitializeComponent();
            CatalogsList.ItemsSource = Catalogs;
        }

        private void CatalogsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private CatalogRowsPage GetPage(string pageName)
        {
            dynamic? context = null;
            switch(pageName)
            {
                case "Студенты": context = nameof(ApplicationContext.Students); break;
                case "Преподаватели": context = nameof(ApplicationContext.Teachers); break;
                case "Физические лица": context = nameof(ApplicationContext.Persons); break;
                case "Нагрузка": context = nameof(ApplicationContext.Loads); break;
                case "Ведомости": context = nameof(ApplicationContext.Exams); break;
                case "Учебные планы": context = nameof(ApplicationContext.Curriculums); break;
                case "Строки учебного плана": context = nameof(ApplicationContext.CurriculumRows); break;
                case "Группы": context = nameof(ApplicationContext.Groups); break;
                case "Факультеты": context = nameof(ApplicationContext.Faculties); break;
            }
            return new(context);
        }
    }
    
}
