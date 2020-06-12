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
        public AddList(DataGrid table)
        {
            InitializeComponent();
            this.table = table;
            ListInterface a = new ClassList();
            group.ItemsSource = a.GetGroup();
            teacher.ItemsSource = a.GetTeacher();
            string[] mas1 = { "1", "2", "3", "4", "5", "6", "7", "8" };
            semester.ItemsSource = mas1;
            string[] mas2 = { "Зачет", "Экзамен", "Дифференцированный зачет" };
            type.ItemsSource = mas2;
            string[] mas3 = { "..выберете семестр и группу" };
            disc.ItemsSource = mas3;
        }
        DataGrid table;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (semester.Text == "" || disc.Text == "" || group.Text == "" || type.Text == "" || teacher.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                ListInterface a = new ClassList();
                a.InsertList(semester.Text, disc.Text, group.Text, type.Text, teacher.Text, table);
            }
        }

        private void semester_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (group.Text != "")
            {
                disc.SelectedItem = null;
                ListInterface a = new ClassList();
                disc.ItemsSource = a.GetDisciplineSpec(semester.SelectedItem.ToString(), group.Text);
            }
        }

        private void group_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (semester.Text != "")
            {
                disc.SelectedItem = null;
                ListInterface a = new ClassList();
                disc.ItemsSource = a.GetDisciplineSpec(semester.Text, group.SelectedItem.ToString());
            }
        }
    }
}
