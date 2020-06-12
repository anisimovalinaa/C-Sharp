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
    /// Логика взаимодействия для Teacher.xaml
    /// </summary>
    public partial class Teacher : Page
    {
        public Teacher()
        {
            InitializeComponent();
            Show();
        }

        private void Show()
        {
            tableTeacher.Items.Clear();
            Operations a = new ClassTeacher();
            a.Show(tableTeacher);
        }

        delegate Excel.Workbook workbook(DataGrid table);
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            workbook wb = new workbook(Docs.TableToExcel);
            Docs.SaveDocs(wb(tableTeacher));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddTeacher window = new AddTeacher(tableTeacher);
            window.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tableTeacher.Items.Clear();
            TeacherInterface a = new ClassTeacher();
            a.ShowRank(tableTeacher, rank);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Show();
        }
    }
}