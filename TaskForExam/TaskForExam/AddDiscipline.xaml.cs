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
    /// Логика взаимодействия для AddDiscipline.xaml
    /// </summary>
    public partial class AddDiscipline : Window
    {
        public AddDiscipline(DataGrid table)
        {
            InitializeComponent();
            this.table = table;
        }
        DataGrid table;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text == "")
            {
                a1.Visibility = Visibility.Visible;
                p.Visibility = Visibility.Visible;
                if (hours.Text == "") a2.Visibility = Visibility.Visible;
                if (semester.Text == "") a3.Visibility = Visibility.Visible;
                if (speciality.Text == "") a4.Visibility = Visibility.Visible;
            }
            else
            {
                if (hours.Text == "")
                {
                    a2.Visibility = Visibility.Visible;
                    p.Visibility = Visibility.Visible;
                    if (semester.Text == "") a3.Visibility = Visibility.Visible;
                    if (speciality.Text == "") a4.Visibility = Visibility.Visible;
                }
                else
                {
                    if (semester.Text == "")
                    {
                        a3.Visibility = Visibility.Visible;
                        p.Visibility = Visibility.Visible;
                        if (speciality.Text == "") a4.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        if (speciality.Text == "")
                        {
                            a4.Visibility = Visibility.Visible;
                            p.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            ListInterface a = new ClassList();
                            a.AddDiscipline(name.Text, hours.Text, semester.Text, speciality.Text);
                            name.Clear();
                            hours.Clear();
                            semester.SelectedIndex = -1;
                            speciality.SelectedIndex = -1;
                        }
                    }
                }
            }
        }

        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where
                         (ch =>
                            (ch >= 'а' && ch <= 'я')
                            || (ch >= 'А' && ch <= 'Я')
                            || ch == 'ё' || ch == 'Ё' || ch == '-'
                            || (ch >='a' && ch<= 'z')
                            || (ch >='A' && ch<='Z') || ch == ' '
                         )
                         .ToArray()
                    );
            }
            a1.Visibility = Visibility.Hidden;
            if (hours.Text != "" && semester.Text != "" && speciality.Text != "")
                p.Visibility = Visibility.Hidden;
        }

        private void hours_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where
                         (ch => (ch >= '0' && ch <= '9') || ch == '+').ToArray()
                    );
            }
            a2.Visibility = Visibility.Hidden;
            if (name.Text != "" && semester.Text != "" && speciality.Text != "")
                p.Visibility = Visibility.Hidden;
        }

        private void semester_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            a3.Visibility = Visibility.Hidden;
            if (hours.Text != "" && name.Text != "" && speciality.Text != "")
                p.Visibility = Visibility.Hidden;
        }

        private void speciality_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            a4.Visibility = Visibility.Hidden;
            if (hours.Text != "" && semester.Text != "" && name.Text != "")
                p.Visibility = Visibility.Hidden;
        }
    }
}
