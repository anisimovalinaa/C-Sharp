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

namespace TaskForExam
{
    /// <summary>
    /// Логика взаимодействия для AddRating.xaml
    /// </summary>
    public partial class AddRating : Window
    {
        public AddRating()
        {
            InitializeComponent();
            StudentInterface a = new ClassStudent();
            group.ItemsSource = a.GetGroup();
            string[] mas = { "...выберите тип" };
            mark.ItemsSource = mas;
            string[] mas1 = { "...выберите группу" };
            student.ItemsSource = mas1;
            string[] mas2 = { "...выберите группу, тип и семестр" };
            Discipline.ItemsSource = mas2;
            string[] mas3 = { "1", "2", "3", "4", "5", "6", "7", "8" };
            semester.ItemsSource = mas3;
        }

        private void type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (group.Text != "" && semester.Text != "")
            {
                Discipline.SelectedItem = null;
                ListInterface a = new ClassList();
                switch(type.SelectedIndex)
                {
                    case 0: Discipline.ItemsSource = a.GetDisciplineGroup(group.Text, "Зачет", semester.Text); break;
                    case 1: Discipline.ItemsSource = a.GetDisciplineGroup(group.Text, "Экзамен", semester.Text); break;
                    case 2: Discipline.ItemsSource = a.GetDisciplineGroup(group.Text, "Дифференцированный зачет", semester.Text); break;
                }
            }
            mark.SelectedItem = null;
            if (type.SelectedIndex == 0)
            {
                string[] mas = { "зачтено" };
                mark.ItemsSource = mas;
            }
            else
            {
                string[] mas = { "отлично", "хорошо", "удовлетворительно", "неудовлетворительно" };
                mark.ItemsSource = mas;
            }
        }

        private void group_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            student.SelectedItem = null;
            ListInterface a = new ClassList();
            student.ItemsSource = a.GetStudents(group.SelectedItem.ToString());
            if(type.Text != "" && semester.Text != "")
            {
                Discipline.SelectedItem = null;
                Discipline.ItemsSource = a.GetDisciplineGroup(group.SelectedItem.ToString(), type.Text, semester.Text);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (semester.Text == "" || group.Text == "" || Discipline.Text == "" || student.Text == "" || mark.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                ListInterface a = new ClassList();
                a.AddMark(semester, type, group, Discipline, student, mark);
            }
        }

        private void semester_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (type.Text != "" && group.Text != "")
            {
                ListInterface a = new ClassList();
                Discipline.SelectedItem = null;
                Discipline.ItemsSource = a.GetDisciplineGroup(group.Text, type.Text, semester.SelectedItem.ToString());
            }
        }
    }
}
