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
        string[] mas = { "...выберите тип" };
        string[] mas1 = { "...выберите группу" };
        string[] mas2 = { "...выберите группу, тип и семестр" };
        public AddRating()
        {
            InitializeComponent();
            StudentInterface a = new ClassStudent();
            group.ItemsSource = a.GetGroup();
            mark.ItemsSource = mas;
            student.ItemsSource = mas1;
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
                string[] mas = { "зачтено", "не зачтено" };
                mark.ItemsSource = mas;
            }
            else
            {
                string[] mas = { "отлично", "хорошо", "удовлетворительно", "неудовлетворительно" };
                mark.ItemsSource = mas;
            }
            a2.Visibility = Visibility.Hidden;
            if (semester.Text != "" && group.Text != "" && Discipline.Text != "" && student.Text != "" && mark.Text != "")
                p.Visibility = Visibility.Hidden;
        }

        private void group_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            student.SelectedItem = null;
            StudentInterface s = new ClassStudent();
            ListInterface d = new ClassList();
            student.ItemsSource = s.GetStudents(group.SelectedItem.ToString());
            if(type.Text != "" && semester.Text != "")
            {
                Discipline.SelectedItem = null;
                Discipline.ItemsSource = d.GetDisciplineGroup(group.SelectedItem.ToString(), type.Text, semester.Text);
            }
            a3.Visibility = Visibility.Hidden;
            if (type.Text != "" && semester.Text != "" && Discipline.Text != "" && student.Text != "" && mark.Text != "")
                p.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (semester.Text == "")
            {
                a1.Visibility = Visibility.Visible;
                p.Visibility = Visibility.Visible;
                if (type.Text == "") a2.Visibility = Visibility.Visible;
                if (group.Text == "") a3.Visibility = Visibility.Visible;
                if (Discipline.Text == "") a4.Visibility = Visibility.Visible;
                if (student.Text == "") a5.Visibility = Visibility.Visible;
                if (mark.Text == "") a6.Visibility = Visibility.Visible;
            }
            else
            {
                if (type.Text == "")
                {
                    a2.Visibility = Visibility.Visible;
                    p.Visibility = Visibility.Visible;
                    if (group.Text == "") a3.Visibility = Visibility.Visible;
                    if (Discipline.Text == "") a4.Visibility = Visibility.Visible;
                    if (student.Text == "") a5.Visibility = Visibility.Visible;
                    if (mark.Text == "") a6.Visibility = Visibility.Visible;
                }
                else
                {
                    if (group.Text == "")
                    {
                        a3.Visibility = Visibility.Visible;
                        p.Visibility = Visibility.Visible;
                        if (Discipline.Text == "") a4.Visibility = Visibility.Visible;
                        if (student.Text == "") a5.Visibility = Visibility.Visible;
                        if (mark.Text == "") a6.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        if (Discipline.Text == "")
                        {
                            a4.Visibility = Visibility.Visible;
                            p.Visibility = Visibility.Visible;
                            if (student.Text == "") a5.Visibility = Visibility.Visible;
                            if (mark.Text == "") a6.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            if (student.Text == "")
                            {
                                a5.Visibility = Visibility.Visible;
                                p.Visibility = Visibility.Visible;
                                if (mark.Text == "") a6.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                if (mark.Text == "")
                                {
                                    a6.Visibility = Visibility.Visible;
                                    p.Visibility = Visibility.Visible;
                                }
                                else
                                {
                                    ListInterface a = new ClassList();
                                    a.AddMark(semester.Text, type.Text, group.Text, Discipline.Text, student.Text, mark.Text);
                                    mark.SelectedIndex = -1;
                                    student.SelectedIndex = -1;
                                }
                            }
                        }
                    }
                }
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
            a1.Visibility = Visibility.Hidden;
            if (type.Text != "" && group.Text != "" && Discipline.Text != "" && student.Text != "" && mark.Text != "")
                p.Visibility = Visibility.Hidden;
        }

        private void Discipline_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Discipline.ItemsSource == mas2) Discipline.SelectedIndex = -1;
            a4.Visibility = Visibility.Hidden;
            if (type.Text != "" && group.Text != "" && semester.Text != "" && student.Text != "" && mark.Text != "")
                p.Visibility = Visibility.Hidden;
        }

        private void student_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (student.ItemsSource == mas1) student.SelectedIndex = -1;
            a5.Visibility = Visibility.Hidden;
            if (type.Text != "" && group.Text != "" && Discipline.Text != "" && semester.Text != "" && mark.Text != "")
                p.Visibility = Visibility.Hidden;
        }

        private void mark_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (mark.ItemsSource == mas) mark.SelectedIndex = -1;
            a6.Visibility = Visibility.Hidden;
            if (type.Text != "" && group.Text != "" && Discipline.Text != "" && student.Text != "" && semester.Text != "")
                p.Visibility = Visibility.Hidden;
        }
    }
}
