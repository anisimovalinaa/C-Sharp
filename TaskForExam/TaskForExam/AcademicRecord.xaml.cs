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
using Excel = Microsoft.Office.Interop.Excel;

namespace TaskForExam
{
    /// <summary>
    /// Логика взаимодействия для AcademicRecord.xaml
    /// </summary>
    public partial class AcademicRecord : Page
    {
        string[] mas3 = { "..выберете тип, семестр и группу" };
        public AcademicRecord()
        {
            InitializeComponent();
            Show();
            StudentInterface g = new ClassStudent();
            group.ItemsSource = g.GetGroup();
            string[] mas1 = { "1", "2", "3", "4", "5", "6", "7", "8" };
            semester.ItemsSource = mas1;
            string[] mas2 = { "Зачет", "Экзамен", "Дифференцированный зачет"};
            type.ItemsSource = mas2;
            disc.ItemsSource = mas3;
        }
        private void Show()
        {
            table.Items.Clear();
            ListInterface a = new ClassList();
            a.ShowRecord(table);
        }

        private void group_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(type.Text != "" && semester.Text!="")
            {
                disc.SelectedItem = null;
                ListInterface a = new ClassList();
                disc.ItemsSource = a.GetDisciplineGroup(group.SelectedItem.ToString(), type.Text, semester.Text);
            }
            a1.Visibility = Visibility.Hidden;
            if (semester.Text != "" && type.Text != "" && (disc.Text != "" || disc.Text != "..выберете тип, семестр и группу")) 
                p.Visibility = Visibility.Hidden;
        }

        private void semester_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (type.Text != "" && group.Text != "")
            {
                disc.SelectedItem = null;
                ListInterface a = new ClassList();
                disc.ItemsSource = a.GetDisciplineGroup(group.Text, type.Text, semester.SelectedItem.ToString());
            }
            a2.Visibility = Visibility.Hidden;
            if (group.Text != "" && type.Text != "" && (disc.Text != "" || disc.Text != "..выберете тип, семестр и группу")) 
                p.Visibility = Visibility.Hidden;
        }

        private void type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (group.Text != "" && semester.Text != "")
            {
                disc.SelectedItem = null;
                ListInterface a = new ClassList();
                disc.ItemsSource = a.GetDisciplineGroup(group.Text, type.SelectedItem.ToString(), semester.Text);
            }
            a3.Visibility = Visibility.Hidden;
            if (semester.Text != "" && group.Text != "" && (disc.Text != "" || disc.Text != "..выберете тип, семестр и группу")) 
                p.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (group.Text == "")
            {
                a1.Visibility = Visibility.Visible;
                p.Visibility = Visibility.Visible;
                if (semester.Text == "") a2.Visibility = Visibility.Visible;
                if (type.Text == "") a3.Visibility = Visibility.Visible;
                if (disc.Text == "" || disc.Text == "..выберете тип, семестр и группу") a4.Visibility = Visibility.Visible;
            }
            else
            {
                if (semester.Text == "")
                {
                    p.Visibility = Visibility.Visible;
                    a2.Visibility = Visibility.Visible;
                    if (type.Text == "") a3.Visibility = Visibility.Visible;
                    if (disc.Text == "" || disc.Text == "..выберете тип, семестр и группу") a4.Visibility = Visibility.Visible;
                }
                else
                {
                    if (type.Text == "")
                    {
                        p.Visibility = Visibility.Visible;
                        a3.Visibility = Visibility.Visible;
                        if (disc.Text == "" || disc.Text == "..выберете тип, семестр и группу") a4.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        if (disc.Text == "" || disc.Text == "..выберете тип, семестр и группу")
                        {
                            p.Visibility = Visibility.Visible;
                            a4.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            table.Items.Clear();
                            ListInterface a = new ClassList();
                            a.ShowMarkGroup(table, group.Text, semester.Text, type.Text, disc.Text);
                        }
                    }
                }
            }
        }

        delegate Excel.Workbook workbook(DataGrid table);
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            workbook wb = new workbook(Docs.TableToExcel);
            Docs.SaveDocs(wb(table));
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AddRating window = new AddRating();
            window.ShowDialog();
            Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            table.Items.Clear();
            Show();
        }

        private void disc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (disc.ItemsSource == mas3) disc.SelectedIndex = - 1;
            a4.Visibility = Visibility.Hidden;
            if (semester.Text != "" && type.Text != "" && group.Text != "") p.Visibility = Visibility.Hidden;
        }
    }
}
