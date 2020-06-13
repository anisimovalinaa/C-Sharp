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

namespace TaskForExam
{
    /// <summary>
    /// Логика взаимодействия для Groups.xaml
    /// </summary>
    public partial class Groups : Page
    {
        public Groups()
        {
            InitializeComponent();
            Show();
        }
        private void Show()
        {
            table.Items.Clear();
            StudentInterface a = new ClassStudent();
            a.ShowGroups(table);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (spec.Text == "") MessageBox.Show("Выберите специальность.");
            else
            {
                table.Items.Clear();
                StudentInterface a = new ClassStudent();
                a.ShowGroupSpec(table, spec.Text);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (number.Text == "" || spec1.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                StudentInterface a = new ClassStudent();
                a.InsertGroup(number.Text, spec1.Text);
                table.Items.Clear();
                Show();
            }
        }
    }
}
