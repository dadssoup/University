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
using University.Data;

namespace University.Views
{
    /// <summary>
    /// Логика взаимодействия для StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {
        public Student currentStudent;
        public Person? PersonToBind;
        public StudentPage()
        {
            InitializeComponent();
            currentStudent = new();
        }
        public StudentPage(Student student)
        {
            currentStudent = student;
            PersonToBind = student.Person;
        }

        private void ChoosePerson_Click(object sender, RoutedEventArgs e)
        {
            var CatalogsPage = new ChooseWindow(ref PersonToBind);
            this.NavigationService.Navigate(CatalogsPage);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(PersonToBind == null)
            {
                MessageBox.Show("Ошибка! Студент не привязан к физическому лицу.");
                return;
            }
            currentStudent.State = State.Text;
            currentStudent.DeletionMark = DeletionMark.IsChecked ?? false;
            currentStudent.Person = PersonToBind;
            currentStudent.PersonId = PersonToBind.Id;
            _ = SaveStudent();
            //var result = SaveStudent();
            //if(!result)
            //{
            //    return;
            //}
        }
        private bool SaveStudent()
        {
            try
            {
                var instance = ApplicationContext.GetInstance();
                instance.Students.Add(currentStudent);
                Task.Run(() => instance.SaveChangesAsync());
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

        }
    }
}
