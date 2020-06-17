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
            StudentInterface a = new ClassStudent();
            group.ItemsSource = a.GetGroup();
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
            a4.Visibility = Visibility.Hidden;
            if (surname.Text != "" && middle_name.Text != "" && (male.IsChecked != false || female.IsChecked != false) &&
                name.Text != "" && number.Text != "" && group.Text != "" && year.Text != "" && phone.Text != "" &&
                city.Text != "" && street.Text != "" && home.Text != "")
                p.Visibility = Visibility.Hidden;
        }

        private void female_Checked(object sender, RoutedEventArgs e)
        {
            bool newVal = (male.IsChecked == true);
            if (newVal == true)
            {
                newVal = false;
                male.IsChecked = newVal;
            }
            a14.Visibility = Visibility.Hidden;
            if (name.Text != "" && middle_name.Text != "" && series.Text != "" && number.Text != "" && 
                group.Text != "" && year.Text != "" && phone.Text != "" &&
                city.Text != "" && street.Text != "" && home.Text != "")
                p.Visibility = Visibility.Hidden;
        }

        private void male_Checked(object sender, RoutedEventArgs e)
        {
            bool newVal = (female.IsChecked == true);
            if (newVal == true)
            {
                newVal = false;
                female.IsChecked = newVal;
            }
            a14.Visibility = Visibility.Hidden;
            if (name.Text != "" && middle_name.Text != "" && series.Text != "" && number.Text != "" && 
                group.Text != "" && year.Text != "" && phone.Text != "" &&
                city.Text != "" && street.Text != "" && home.Text != "")
                p.Visibility = Visibility.Hidden;
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
            a9.Visibility = Visibility.Hidden;
            if (name.Text != "" && middle_name.Text != "" && (male.IsChecked != false || female.IsChecked != false) &&
                series.Text != "" && number.Text != "" && group.Text != "" && year.Text != "" && surname.Text != "" &&
                city.Text != "" && street.Text != "" && home.Text != "")
                p.Visibility = Visibility.Hidden;
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
            a1.Visibility = Visibility.Hidden;
            if (name.Text != "" && middle_name.Text != "" && (male.IsChecked != false || female.IsChecked != false) &&
                series.Text != "" && number.Text != "" && group.Text != "" && year.Text != "" && phone.Text != "" && 
                city.Text != "" && street.Text != "" && home.Text != "")
                p.Visibility = Visibility.Hidden;
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
            a2.Visibility = Visibility.Hidden;
            if (surname.Text != "" && middle_name.Text != "" && (male.IsChecked != false || female.IsChecked != false) &&
                series.Text != "" && number.Text != "" && group.Text != "" && year.Text != "" && phone.Text != "" &&
                city.Text != "" && street.Text != "" && home.Text != "")
                p.Visibility = Visibility.Hidden;
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
            a3.Visibility = Visibility.Hidden;
            if (surname.Text != "" && name.Text != "" && (male.IsChecked != false || female.IsChecked != false) &&
                series.Text != "" && number.Text != "" && group.Text != "" && year.Text != "" && phone.Text != "" &&
                city.Text != "" && street.Text != "" && home.Text != "")
                p.Visibility = Visibility.Hidden;
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
            a10.Visibility = Visibility.Hidden;
            if (name.Text != "" && middle_name.Text != "" && (male.IsChecked != false || female.IsChecked != false) &&
                series.Text != "" && number.Text != "" && group.Text != "" && year.Text != "" && phone.Text != "" &&
                surname.Text != "" && street.Text != "" && home.Text != "")
                p.Visibility = Visibility.Hidden;
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
            a11.Visibility = Visibility.Hidden;
            if (name.Text != "" && middle_name.Text != "" && (male.IsChecked != false || female.IsChecked != false) &&
                series.Text != "" && number.Text != "" && group.Text != "" && year.Text != "" && phone.Text != "" &&
                city.Text != "" && surname.Text != "" && home.Text != "")
                p.Visibility = Visibility.Hidden;
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
            a12.Visibility = Visibility.Hidden;
            if (name.Text != "" && middle_name.Text != "" && (male.IsChecked != false || female.IsChecked != false) &&
                series.Text != "" && number.Text != "" && group.Text != "" && year.Text != "" && phone.Text != "" &&
                city.Text != "" && street.Text != "" && surname.Text != "")
                p.Visibility = Visibility.Hidden;
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
            group.SelectedIndex = -1;
            city.Clear();
            street.Clear();
            home.Clear();
            flat.Clear();
            male.IsChecked = false;
            female.IsChecked = false;
        }
        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (surname.Text == "")
            {
                a1.Visibility = Visibility.Visible;
                p.Visibility = Visibility.Visible;
                if (name.Text == "") a2.Visibility = Visibility.Visible;
                if (middle_name.Text == "") a3.Visibility = Visibility.Visible;
                if (series.Text == "") a4.Visibility = Visibility.Visible;
                if (number.Text == "") a5.Visibility = Visibility.Visible;
                if (group.Text == "") a6.Visibility = Visibility.Visible;
                if (phone.Text == "") a8.Visibility = Visibility.Visible;
                if (year.Text == "") a9.Visibility = Visibility.Visible;
                if (city.Text == "") a10.Visibility = Visibility.Visible;
                if (street.Text == "") a11.Visibility = Visibility.Visible;
                if (home.Text == "") a12.Visibility = Visibility.Visible;
                if (male.IsChecked == false && female.IsChecked == false) a14.Visibility = Visibility.Visible;
            }
            else
            {
                if (name.Text == "")
                {
                    a2.Visibility = Visibility.Visible;
                    p.Visibility = Visibility.Visible;
                    if (middle_name.Text == "") a3.Visibility = Visibility.Visible;
                    if (series.Text == "") a4.Visibility = Visibility.Visible;
                    if (number.Text == "") a5.Visibility = Visibility.Visible;
                    if (group.Text == "") a6.Visibility = Visibility.Visible;
                    if (phone.Text == "") a8.Visibility = Visibility.Visible;
                    if (year.Text == "") a9.Visibility = Visibility.Visible;
                    if (city.Text == "") a10.Visibility = Visibility.Visible;
                    if (street.Text == "") a11.Visibility = Visibility.Visible;
                    if (home.Text == "") a12.Visibility = Visibility.Visible;
                    if (male.IsChecked == false && female.IsChecked == false) a14.Visibility = Visibility.Visible;
                }
                else
                {
                    if (middle_name.Text == "")
                    {
                        a3.Visibility = Visibility.Visible;
                        p.Visibility = Visibility.Visible;
                        if (series.Text == "") a4.Visibility = Visibility.Visible;
                        if (number.Text == "") a5.Visibility = Visibility.Visible;
                        if (group.Text == "") a6.Visibility = Visibility.Visible;
                        if (phone.Text == "") a8.Visibility = Visibility.Visible;
                        if (year.Text == "") a9.Visibility = Visibility.Visible;
                        if (city.Text == "") a10.Visibility = Visibility.Visible;
                        if (street.Text == "") a11.Visibility = Visibility.Visible;
                        if (home.Text == "") a12.Visibility = Visibility.Visible;
                        if (male.IsChecked == false && female.IsChecked == false) a14.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        if (series.Text == "")
                        {
                            a4.Visibility = Visibility.Visible;
                            p.Visibility = Visibility.Visible;
                            if (number.Text == "") a5.Visibility = Visibility.Visible;
                            if (group.Text == "") a6.Visibility = Visibility.Visible;
                            if (phone.Text == "") a8.Visibility = Visibility.Visible;
                            if (year.Text == "") a9.Visibility = Visibility.Visible;
                            if (city.Text == "") a10.Visibility = Visibility.Visible;
                            if (street.Text == "") a11.Visibility = Visibility.Visible;
                            if (home.Text == "") a12.Visibility = Visibility.Visible;
                            if (male.IsChecked == false && female.IsChecked == false) a14.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            if (number.Text == "")
                            {
                                a5.Visibility = Visibility.Visible;
                                p.Visibility = Visibility.Visible;
                                if (group.Text == "") a6.Visibility = Visibility.Visible;
                                if (phone.Text == "") a8.Visibility = Visibility.Visible;
                                if (year.Text == "") a9.Visibility = Visibility.Visible;
                                if (city.Text == "") a10.Visibility = Visibility.Visible;
                                if (street.Text == "") a11.Visibility = Visibility.Visible;
                                if (home.Text == "") a12.Visibility = Visibility.Visible;
                                if (male.IsChecked == false && female.IsChecked == false) a14.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                if (group.Text == "")
                                {
                                    a6.Visibility = Visibility.Visible;
                                    p.Visibility = Visibility.Visible;
                                    if (phone.Text == "") a8.Visibility = Visibility.Visible;
                                    if (year.Text == "") a9.Visibility = Visibility.Visible;
                                    if (city.Text == "") a10.Visibility = Visibility.Visible;
                                    if (street.Text == "") a11.Visibility = Visibility.Visible;
                                    if (home.Text == "") a12.Visibility = Visibility.Visible;
                                    if (male.IsChecked == false && female.IsChecked == false) a14.Visibility = Visibility.Visible;
                                }
                                else
                                {

                                    if (phone.Text == "")
                                    {
                                        a8.Visibility = Visibility.Visible;
                                        p.Visibility = Visibility.Visible;
                                        if (year.Text == "") a9.Visibility = Visibility.Visible;
                                        if (city.Text == "") a10.Visibility = Visibility.Visible;
                                        if (street.Text == "") a11.Visibility = Visibility.Visible;
                                        if (home.Text == "") a12.Visibility = Visibility.Visible;
                                        if (male.IsChecked == false && female.IsChecked == false) a14.Visibility = Visibility.Visible;
                                    }
                                    else
                                    {
                                        if (year.Text == "")
                                        {
                                            a9.Visibility = Visibility.Visible;
                                            p.Visibility = Visibility.Visible;
                                            if (city.Text == "") a10.Visibility = Visibility.Visible;
                                            if (street.Text == "") a11.Visibility = Visibility.Visible;
                                            if (home.Text == "") a12.Visibility = Visibility.Visible;
                                            if (male.IsChecked == false && female.IsChecked == false) a14.Visibility = Visibility.Visible;
                                        }
                                        else
                                        {
                                            if (city.Text == "")
                                            {
                                                a10.Visibility = Visibility.Visible;
                                                p.Visibility = Visibility.Visible;
                                                if (street.Text == "") a11.Visibility = Visibility.Visible;
                                                if (home.Text == "") a12.Visibility = Visibility.Visible;
                                                if (male.IsChecked == false && female.IsChecked == false) a14.Visibility = Visibility.Visible;
                                            }
                                            else
                                            {
                                                if (street.Text == "")
                                                {
                                                    a11.Visibility = Visibility.Visible;
                                                    p.Visibility = Visibility.Visible;
                                                    if (home.Text == "") a12.Visibility = Visibility.Visible;
                                                    if (male.IsChecked == false && female.IsChecked == false) a14.Visibility = Visibility.Visible;
                                                }
                                                else
                                                {
                                                    if (home.Text == "")
                                                    {
                                                        a12.Visibility = Visibility.Visible;
                                                        p.Visibility = Visibility.Visible;
                                                        if (male.IsChecked == false && female.IsChecked == false) a14.Visibility = Visibility.Visible;
                                                    }
                                                    else
                                                    {
                                                        if (male.IsChecked == false && female.IsChecked == false)
                                                        {
                                                            a14.Visibility = Visibility.Visible;
                                                            p.Visibility = Visibility.Visible;
                                                        }
                                                        else
                                                        {
                                                            string sex = "";
                                                            if (male.IsChecked == true) sex = male.Content.ToString();
                                                            else sex = female.Content.ToString();
                                                            StudentInterface a = new ClassStudent();
                                                            a.Insert(series, number, sex, city, street, home, flat, phone, surname, name, middle_name, group, year);
                                                            Cleanning();
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void number_TextChanged(object sender, TextChangedEventArgs e)
        {
            a5.Visibility = Visibility.Hidden;
            if (surname.Text != "" && middle_name.Text != "" && (male.IsChecked != false || female.IsChecked != false) &&
                series.Text != "" && name.Text != "" && group.Text != "" && year.Text != "" && phone.Text != "" &&
                city.Text != "" && street.Text != "" && home.Text != "")
                p.Visibility = Visibility.Hidden;

            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where
                         (ch => (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void group_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            a6.Visibility = Visibility.Hidden;
            if (surname.Text != "" && middle_name.Text != "" && (male.IsChecked != false || female.IsChecked != false) &&
                series.Text != "" && name.Text != "" && number.Text != "" && year.Text != "" && phone.Text != "" &&
                city.Text != "" && street.Text != "" && home.Text != "")
                p.Visibility = Visibility.Hidden;
        }

        private void year_TextChanged(object sender, TextChangedEventArgs e)
        {
            a8.Visibility = Visibility.Hidden;
            if (surname.Text != "" && middle_name.Text != "" && (male.IsChecked != false || female.IsChecked != false) &&
                series.Text != "" && name.Text != "" && number.Text != "" && group.Text != "" && phone.Text != "" &&
                city.Text != "" && street.Text != "" && home.Text != "")
                p.Visibility = Visibility.Hidden;
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where
                         (ch => (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }
    }
}
