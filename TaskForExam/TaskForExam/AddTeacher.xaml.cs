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
    /// Логика взаимодействия для AddTeacher.xaml
    /// </summary>
    public partial class AddTeacher : Window
    {
        public AddTeacher(DataGrid table)
        {
            InitializeComponent();
            this.table = table;
        }
        DataGrid table;
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
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

        private void female_Checked(object sender, RoutedEventArgs e)
        {
            male.IsChecked = false;
        }

        private void male_Checked(object sender, RoutedEventArgs e)
        {
            female.IsChecked = false;
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


        private void Cleaning()
        {
            surname.Clear();
            name.Clear();
            middle_name.Clear();
            series.Clear();
            number.Clear();
            female.IsChecked = false;
            male.IsChecked = false;
            phone.Clear();
            city.Clear();
            street.Clear();
            home.Clear();
            flat.Clear();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (surname.Text == "" || name.Text == "" || middle_name.Text == "" || series.Text == "" || number.Text == "" || phone.Text == "" || rank.Text == ""
                || city.Text == "" || street.Text == "" || home.Text == "" || flat.Text == "" || (male.IsChecked == false && female.IsChecked == false))
            {
                MessageBox.Show("Необходимо заполнить все обязательные поля!", "ОШИБКА");
            }
            else
            {
                string sex = "";
                if (male.IsChecked == true) sex = male.Content.ToString();
                else sex = female.Content.ToString();
                TeacherInterface a = new ClassTeacher();
                a.Insert(series, number, sex, city, street, home, flat, phone, surname, name, middle_name, rank, table);
                Cleaning();
            }
        }

        private void phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where
                         (ch => (ch >= '0' && ch <= '9') || ch == '+').ToArray()
                    );
            }
        }
    }
}
