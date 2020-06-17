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
using System.Collections.ObjectModel;

namespace TaskForExam
{
    /// <summary>
    /// Логика взаимодействия для AddList.xaml
    /// </summary>
    public partial class AddList : Window
    {
        string[] mas3 = { "..выберете семестр и группу" };
        public AddList()
        {
            InitializeComponent();
            StudentInterface g = new ClassStudent();
            group.ItemsSource = g.GetGroup();
            TeacherInterface t = new ClassTeacher();
            teacher.ItemsSource = t.GetTeacher();
            string[] mas1 = { "1", "2", "3", "4", "5", "6", "7", "8" };
            semester.ItemsSource = mas1;
            string[] mas2 = { "Зачет", "Экзамен", "Дифференцированный зачет" };
            type.ItemsSource = mas2;
            disc.ItemsSource = mas3;
        }
        private void Cleanning()
        {
            semester.SelectedIndex = -1;
            type.SelectedIndex = -1;
            group.SelectedIndex = -1;
            disc.ItemsSource = mas3;
            teacher.SelectedIndex = -1;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (semester.Text == "")
            {
                a1.Visibility = Visibility.Visible;
                p.Visibility = Visibility.Visible;
                if (type.Text == "") a2.Visibility = Visibility.Visible;
                if (group.Text == "") a3.Visibility = Visibility.Visible;
                if (disc.Text == "") a4.Visibility = Visibility.Visible;
                if (teacher.Text == "") a5.Visibility = Visibility.Visible;
            }
            else
            {
                if (type.Text == "")
                {
                    a2.Visibility = Visibility.Visible;
                    p.Visibility = Visibility.Visible;
                    if (group.Text == "") a3.Visibility = Visibility.Visible;
                    if (disc.Text == "") a4.Visibility = Visibility.Visible;
                    if (teacher.Text == "") a5.Visibility = Visibility.Visible;
                }
                else
                {
                    if (group.Text == "")
                    {
                        a3.Visibility = Visibility.Visible;
                        p.Visibility = Visibility.Visible;
                        if (disc.Text == "") a4.Visibility = Visibility.Visible;
                        if (teacher.Text == "") a5.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        if (disc.Text == "")
                        {
                            a4.Visibility = Visibility.Visible;
                            p.Visibility = Visibility.Visible;
                            if (teacher.Text == "") a5.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            if (teacher.Text == "")
                            {
                                a5.Visibility = Visibility.Visible;
                                p.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                ListInterface a = new ClassList();
                                a.InsertList(semester.Text, disc.Text, group.Text, type.Text, teacher.Text);
                                Cleanning();
                            }
                        }
                    }
                }
            }
        }

        private void semester_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (group.Text != "" && semester.SelectedIndex != -1)
            {
                disc.SelectedItem = null;
                ListInterface a = new ClassList();
                disc.ItemsSource = a.GetDisciplineSpec(semester.SelectedItem.ToString(), group.Text);
            }
            a1.Visibility = Visibility.Hidden;
            if (group.Text != "" && type.Text != "" && disc.Text != "" && teacher.Text != "")
                p.Visibility = Visibility.Hidden;
        }

        private void group_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (semester.Text != "")
            {
                disc.SelectedItem = null;
                ListInterface a = new ClassList();
                disc.ItemsSource = a.GetDisciplineSpec(semester.Text, group.SelectedItem.ToString());
            }
            a3.Visibility = Visibility.Hidden;
            if (semester.Text != "" && type.Text != "" && disc.Text != "" && teacher.Text != "")
                p.Visibility = Visibility.Hidden;
        }

        private void type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            a2.Visibility = Visibility.Hidden;
            if (group.Text != "" && semester.Text != "" && disc.Text != "" && teacher.Text != "")
                p.Visibility = Visibility.Hidden;
        }

        private void disc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (disc.ItemsSource == mas3) disc.SelectedIndex = -1;
            a4.Visibility = Visibility.Hidden;
            if (group.Text != "" && type.Text != "" && semester.Text != "" && teacher.Text != "")
                p.Visibility = Visibility.Hidden;
        }

        private void teacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            a5.Visibility = Visibility.Hidden;
            if (group.Text != "" && type.Text != "" && disc.Text != "" && semester.Text != "")
                p.Visibility = Visibility.Hidden;
        }
    }
}
