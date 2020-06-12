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
    /// Логика взаимодействия для AcademicRecord.xaml
    /// </summary>
    public partial class AcademicRecord : Page
    {
        public AcademicRecord()
        {
            InitializeComponent();
            Show();
            ListInterface a = new ClassList();
            group.ItemsSource = a.GetGroup();
            string[] mas1 = { "1", "2", "3", "4", "5", "6", "7", "8" };
            semester.ItemsSource = mas1;
            string[] mas2 = { "Зачет", "Экзамен", "Дифференцированный зачет"};
            type.ItemsSource = mas2;
        }
        private void Show()
        {
            table.Items.Clear();
            ListInterface a = new ClassList();
            a.ShowRecord(table);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddRating window = new AddRating();
            window.ShowDialog();
            Show();
        }

        private void group_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(type.Text != "" && semester.Text!="")
            {
                disc.SelectedItem = null;
                ListInterface a = new ClassList();
                disc.ItemsSource = a.GetDisciplineGroup(group.SelectedItem.ToString(), type.Text, semester.Text);
            }
        }

        private void semester_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (type.Text != "" && group.Text != "")
            {
                disc.SelectedItem = null;
                ListInterface a = new ClassList();
                disc.ItemsSource = a.GetDisciplineGroup(group.Text, type.Text, semester.SelectedItem.ToString());
            }
        }

        private void type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (group.Text != "" && semester.Text != "")
            {
                disc.SelectedItem = null;
                ListInterface a = new ClassList();
                disc.ItemsSource = a.GetDisciplineGroup(group.Text, type.SelectedItem.ToString(), semester.Text);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            table.Items.Clear();
            ListInterface a = new ClassList();
            a.ShowMarkGroup(table, group.Text, semester.Text, type.Text, disc.Text);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            table.Items.Clear();
            Show();
        }
    }
}
