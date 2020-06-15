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
    /// Логика взаимодействия для List.xaml
    /// </summary>
    public partial class List : Page
    {
        public List()
        {
            InitializeComponent();
            Show();
            StudentInterface a = new ClassStudent();
            group.ItemsSource = a.GetGroup();
            TeacherInterface t = new ClassTeacher();
            teacher.ItemsSource = t.GetTeacher();
        }
        private void Show()
        {
            tableList.Items.Clear();
            ListInterface a = new ClassList();
            a.Show(tableList);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (type.Text == "")
            {
                a1.Visibility = Visibility.Visible;
                p.Visibility = Visibility.Visible;
                if (group.Text == "") a2.Visibility = Visibility.Visible;
            }
            else
            {
                if (group.Text == "")
                {
                    a2.Visibility = Visibility.Visible;
                    p.Visibility = Visibility.Visible;
                }
                else
                {
                    tableList.Items.Clear();
                    ListInterface a = new ClassList();
                    a.ShowGroup(tableList, type.Text, group.Text);
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (type1.Text == "" || teacher.Text == "") MessageBox.Show("Заполните все поля!");
            else
            {
                tableList.Items.Clear();
                ListInterface a = new ClassList();
                a.ShowTeacher(tableList, type1.Text, teacher.Text);
            }
        }

        delegate Excel.Workbook workbook(DataGrid table);
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            workbook wb = new workbook(Docs.TableToExcel);
            Docs.SaveDocs(wb(tableList));
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AddList window = new AddList(tableList);
            window.ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Show();
        }

        private void type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            a1.Visibility = Visibility.Hidden;
            if (group.Text != "") p.Visibility = Visibility.Hidden;
        }

        private void group_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            a2.Visibility = Visibility.Hidden;
            if (type.Text != "") p.Visibility = Visibility.Hidden;
        }
    }
}
