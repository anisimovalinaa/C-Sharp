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
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        public AddStudent()
        {
            InitializeComponent();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where
                         (ch =>(ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void female_Checked(object sender, RoutedEventArgs e)
        {
            bool newVal = (male.IsChecked == true);
            if (newVal == true)
            {
                newVal = false;
                male.IsChecked = newVal;
            }
        }

        private void male_Checked(object sender, RoutedEventArgs e)
        {
            bool newVal = (female.IsChecked == true);
            if (newVal == true)
            {
                newVal = false;
                female.IsChecked = newVal;
            }
        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where
                         (ch => (ch >= '0' && ch <= '9') || ch=='+').ToArray()
                    );
            }
        }

        private void surname_TextChanged(object sender, TextChangedEventArgs e)
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
                         )
                         .ToArray()
                    );
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
                            || ch == 'ё' || ch == 'Ё'
                         )
                         .ToArray()
                    );
            }
        }

        private void middle_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where
                         (ch =>
                            (ch >= 'а' && ch <= 'я')
                            || (ch >= 'А' && ch <= 'Я')
                            || ch == 'ё' || ch == 'Ё'
                         )
                         .ToArray()
                    );
            }
        }

        private void city_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where
                         (ch =>
                            (ch >= 'а' && ch <= 'я')
                            || (ch >= 'А' && ch <= 'Я')
                            || ch == 'ё' || ch == 'Ё' || ch == '-' || ch == ' '
                         )
                         .ToArray()
                    );
            }
        }

        private void street_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where
                         (ch =>
                            (ch >= 'а' && ch <= 'я')
                            || (ch >= 'А' && ch <= 'Я')
                            || (ch >= '0' && ch <= '9')
                            || ch == 'ё' || ch == 'Ё' || ch == '-' || ch == ' '
                         )
                         .ToArray()
                    );
            }
        }

        private void home_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where
                         (ch =>
                            (ch >= 'а' && ch <= 'я')
                            || (ch >= 'А' && ch <= 'Я')
                            || ch == 'ё' || ch == 'Ё' || ch == '/'
                            || (ch >= '0' && ch <= '9')
                         )
                         .ToArray()
                    );
            }
        }

        private void flat_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where
                         (ch => (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void Cleanning()
        {
            surname.Clear();
            name.Clear();
            middle_name.Clear();
            series.Clear();
            number.Clear();
            phone.Clear();
            year.Clear();
            group.Clear();
            city.Clear();
            street.Clear();
            home.Clear();
            flat.Clear();
            male.IsChecked = false;
            female.IsChecked = false;
        }
        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (surname.Text == "" || name.Text == "" || middle_name.Text == "" || series.Text == "" || number.Text == "" || phone.Text == "" || spec.Text == "" || year.Text == ""
                || group.Text == "" || city.Text == "" || street.Text == "" || home.Text == "" || flat.Text == "" || (male.IsChecked == false && female.IsChecked == false))
            {
                MessageBox.Show("Необходимо заполнить все поля!", "ОШИБКА");
            }
            else
            {
                string sex = "";
                if (male.IsChecked == true) sex = male.Content.ToString();
                else sex = female.Content.ToString();
                StudentInterface a = new ClassStudent();
                a.Insert(series, number, sex, city, street, home, flat, phone, surname, name, middle_name, group, spec, year);
                Cleanning();
            }
        }

        private void spec_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where
                         (ch =>
                            (ch >= 'а' && ch <= 'я')
                            || (ch >= 'А' && ch <= 'Я')
                            || ch == 'ё' || ch == 'Ё' || ch == ' '
                         )
                         .ToArray()
                    );
            }
        }
    }
}
