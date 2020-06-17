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
        public AddTeacher()
        {
            InitializeComponent();
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
                series.Text != "" && number.Text != "" && rank.Text != "" && phone.Text != "" && city.Text != "" &&
                street.Text != "" && home.Text != "")
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
                series.Text != "" && number.Text != "" && rank.Text != "" && phone.Text != "" && city.Text != "" &&
                street.Text != "" && home.Text != "")
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
                series.Text != "" && number.Text != "" && rank.Text != "" && phone.Text != "" && city.Text != "" &&
                street.Text != "" && home.Text != "")
                p.Visibility = Visibility.Hidden;
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
            a6.Visibility = Visibility.Hidden;
            if (surname.Text != "" && middle_name.Text != "" && (male.IsChecked != false || female.IsChecked != false) &&
                name.Text != "" && number.Text != "" && rank.Text != "" && phone.Text != "" && city.Text != "" &&
                street.Text != "" && home.Text != "")
                p.Visibility = Visibility.Hidden;
        }

        private void female_Checked(object sender, RoutedEventArgs e)
        {
            male.IsChecked = false;
            a4.Visibility = Visibility.Hidden;
            if (surname.Text != "" && middle_name.Text != "" && name.Text != "" &&
                series.Text != "" && number.Text != "" && rank.Text != "" && phone.Text != "" && city.Text != "" &&
                street.Text != "" && home.Text != "")
                p.Visibility = Visibility.Hidden;
        }

        private void male_Checked(object sender, RoutedEventArgs e)
        {
            female.IsChecked = false;
            a4.Visibility = Visibility.Hidden;
            if (surname.Text != "" && middle_name.Text != "" && name.Text != "" &&
                series.Text != "" && number.Text != "" && rank.Text != "" && phone.Text != "" && city.Text != "" &&
                street.Text != "" && home.Text != "")
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
            a9.Visibility = Visibility.Hidden;
            if (surname.Text != "" && middle_name.Text != "" && (male.IsChecked != false || female.IsChecked != false) &&
                series.Text != "" && name.Text != "" && rank.Text != "" && phone.Text != "" && number.Text != "" &&
                street.Text != "" && home.Text != "")
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
            a10.Visibility = Visibility.Hidden;
            if (surname.Text != "" && middle_name.Text != "" && (male.IsChecked != false || female.IsChecked != false) &&
                series.Text != "" && name.Text != "" && rank.Text != "" && phone.Text != "" && city.Text != "" &&
                number.Text != "" && home.Text != "")
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
            a11.Visibility = Visibility.Hidden;
            if (surname.Text != "" && middle_name.Text != "" && (male.IsChecked != false || female.IsChecked != false) &&
                series.Text != "" && name.Text != "" && rank.Text != "" && phone.Text != "" && city.Text != "" &&
                street.Text != "" && number.Text != "")
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


        private void Cleaning()
        {
            surname.Clear();
            name.Clear();
            middle_name.Clear();
            series.Clear();
            number.Clear();
            rank.SelectedIndex = -1;
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
            if (surname.Text == "")
            {
                a1.Visibility = Visibility.Visible;
                p.Visibility = Visibility.Visible;
                if (name.Text == "") a2.Visibility = Visibility.Visible;
                if (middle_name.Text == "") a3.Visibility = Visibility.Visible;
                if (series.Text == "") a6.Visibility = Visibility.Visible;
                if (number.Text == "") a5.Visibility = Visibility.Visible;
                if (phone.Text == "") a8.Visibility = Visibility.Visible;
                if (rank.Text == "") a7.Visibility = Visibility.Visible;
                if (city.Text == "") a9.Visibility = Visibility.Visible;
                if (street.Text == "") a10.Visibility = Visibility.Visible;
                if (home.Text == "") a11.Visibility = Visibility.Visible;
                if (male.IsChecked == false && female.IsChecked == false) a4.Visibility = Visibility.Visible;
            }
            else
            {
                if (name.Text == "")
                {
                    a2.Visibility = Visibility.Visible;
                    p.Visibility = Visibility.Visible;
                    if (middle_name.Text == "") a3.Visibility = Visibility.Visible;
                    if (series.Text == "") a6.Visibility = Visibility.Visible;
                    if (number.Text == "") a5.Visibility = Visibility.Visible;
                    if (phone.Text == "") a8.Visibility = Visibility.Visible;
                    if (rank.Text == "") a7.Visibility = Visibility.Visible;
                    if (city.Text == "") a9.Visibility = Visibility.Visible;
                    if (street.Text == "") a10.Visibility = Visibility.Visible;
                    if (home.Text == "") a11.Visibility = Visibility.Visible;
                    if (male.IsChecked == false && female.IsChecked == false) a4.Visibility = Visibility.Visible;
                }
                else
                {
                    if (middle_name.Text == "")
                    {
                        a3.Visibility = Visibility.Visible;
                        p.Visibility = Visibility.Visible;
                        if (series.Text == "") a6.Visibility = Visibility.Visible;
                        if (number.Text == "") a5.Visibility = Visibility.Visible;
                        if (phone.Text == "") a8.Visibility = Visibility.Visible;
                        if (rank.Text == "") a7.Visibility = Visibility.Visible;
                        if (city.Text == "") a9.Visibility = Visibility.Visible;
                        if (street.Text == "") a10.Visibility = Visibility.Visible;
                        if (home.Text == "") a11.Visibility = Visibility.Visible;
                        if (male.IsChecked == false && female.IsChecked == false) a4.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        if (series.Text == "")
                        {
                            a6.Visibility = Visibility.Visible;
                            p.Visibility = Visibility.Visible;
                            if (number.Text == "") a5.Visibility = Visibility.Visible;
                            if (phone.Text == "") a8.Visibility = Visibility.Visible;
                            if (rank.Text == "") a7.Visibility = Visibility.Visible;
                            if (city.Text == "") a9.Visibility = Visibility.Visible;
                            if (street.Text == "") a10.Visibility = Visibility.Visible;
                            if (home.Text == "") a11.Visibility = Visibility.Visible;
                            if (male.IsChecked == false && female.IsChecked == false) a4.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            if (number.Text == "")
                            {
                                a5.Visibility = Visibility.Visible;
                                p.Visibility = Visibility.Visible;
                                if (phone.Text == "") a8.Visibility = Visibility.Visible;
                                if (rank.Text == "") a7.Visibility = Visibility.Visible;
                                if (city.Text == "") a9.Visibility = Visibility.Visible;
                                if (street.Text == "") a10.Visibility = Visibility.Visible;
                                if (home.Text == "") a11.Visibility = Visibility.Visible;
                                if (male.IsChecked == false && female.IsChecked == false) a4.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                if (rank.Text == "")
                                {
                                    a7.Visibility = Visibility.Visible;
                                    p.Visibility = Visibility.Visible;
                                    if (phone.Text == "") a8.Visibility = Visibility.Visible;
                                    if (city.Text == "") a9.Visibility = Visibility.Visible;
                                    if (street.Text == "") a10.Visibility = Visibility.Visible;
                                    if (home.Text == "") a11.Visibility = Visibility.Visible;
                                    if (male.IsChecked == false && female.IsChecked == false) a4.Visibility = Visibility.Visible;
                                }
                                else
                                {
                                    if (phone.Text == "")
                                    {
                                        a8.Visibility = Visibility.Visible;
                                        p.Visibility = Visibility.Visible;
                                        if (city.Text == "") a9.Visibility = Visibility.Visible;
                                        if (street.Text == "") a10.Visibility = Visibility.Visible;
                                        if (home.Text == "") a11.Visibility = Visibility.Visible;
                                        if (male.IsChecked == false && female.IsChecked == false) a4.Visibility = Visibility.Visible;
                                    }
                                    else
                                    {
                                        if (city.Text == "")
                                        {
                                            a9.Visibility = Visibility.Visible;
                                            p.Visibility = Visibility.Visible;
                                            if (street.Text == "") a10.Visibility = Visibility.Visible;
                                            if (home.Text == "") a11.Visibility = Visibility.Visible;
                                            if (male.IsChecked == false && female.IsChecked == false) a4.Visibility = Visibility.Visible;
                                        }
                                        else
                                        {
                                            if (street.Text == "")
                                            {
                                                a10.Visibility = Visibility.Visible;
                                                p.Visibility = Visibility.Visible;
                                                if (home.Text == "") a11.Visibility = Visibility.Visible;
                                                if (male.IsChecked == false && female.IsChecked == false) a4.Visibility = Visibility.Visible;
                                            }
                                            else
                                            {
                                                if (home.Text == "")
                                                {
                                                    a11.Visibility = Visibility.Visible;
                                                    p.Visibility = Visibility.Visible;
                                                    if (male.IsChecked == false && female.IsChecked == false) a4.Visibility = Visibility.Visible;
                                                }
                                                else
                                                {
                                                    if (male.IsChecked == false && female.IsChecked == false)
                                                    {
                                                        a4.Visibility = Visibility.Visible;
                                                        p.Visibility = Visibility.Visible;
                                                    }
                                                    else
                                                    {
                                                        string sex = "";
                                                        if (male.IsChecked == true) sex = male.Content.ToString();
                                                        else sex = female.Content.ToString();
                                                        TeacherInterface a = new ClassTeacher();
                                                        a.Insert(series, number, sex, city, street, home, flat, phone, surname, name, middle_name, rank);
                                                        Cleaning();
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
            a8.Visibility = Visibility.Hidden;
            if (surname.Text != "" && middle_name.Text != "" && (male.IsChecked != false || female.IsChecked != false) &&
                series.Text != "" && name.Text != "" && rank.Text != "" && number.Text != "" && city.Text != "" &&
                street.Text != "" && home.Text != "")
                p.Visibility = Visibility.Hidden;
        }

        private void number_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where
                         (ch => (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
            a5.Visibility = Visibility.Hidden;
            if (surname.Text != "" && middle_name.Text != "" && (male.IsChecked != false || female.IsChecked != false) &&
                series.Text != "" && name.Text != "" && rank.Text != "" && phone.Text != "" && city.Text != "" &&
                street.Text != "" && home.Text != "")
                p.Visibility = Visibility.Hidden;
        }

        private void rank_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            a7.Visibility = Visibility.Hidden;
            if (surname.Text != "" && middle_name.Text != "" && (male.IsChecked != false || female.IsChecked != false) &&
                series.Text != "" && name.Text != "" && number.Text != "" && phone.Text != "" && city.Text != "" &&
                street.Text != "" && home.Text != "")
                p.Visibility = Visibility.Hidden;
        }
    }
}
