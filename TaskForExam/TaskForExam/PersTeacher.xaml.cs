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
    /// Логика взаимодействия для PersTeacher.xaml
    /// </summary>
    public partial class PersTeacher : Page
    {
        public PersTeacher()
        {
            InitializeComponent();
            Show();
        }

        private void ShowRank(string rank)
        {
            tablePersTeacher.Items.Clear();
            TeacherInterface a = new ClassTeacher();
            a.ShowPersRank(tablePersTeacher, rank);
        }

        private void Show()
        {
            tablePersTeacher.Items.Clear();
            Operations a = new ClassTeacher();
            a.ShowPers(tablePersTeacher);
        }

        delegate Excel.Workbook workbook(DataGrid table);
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            workbook wb = new workbook(Docs.TableToExcel);
            Docs.SaveDocs(wb(tablePersTeacher));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Show();
        }

        private void t1_Click(object sender, RoutedEventArgs e)
        {
            ShowRank("Профессор");
        }

        private void t2_Click(object sender, RoutedEventArgs e)
        {
            ShowRank("Доцент");
        }

        private void t3_Click(object sender, RoutedEventArgs e)
        {
            ShowRank("Старший научный сотрудник");
        }

        private void t4_Click(object sender, RoutedEventArgs e)
        {
            ShowRank("Младший научный сотрудник");
        }

        private void t5_Click(object sender, RoutedEventArgs e)
        {
            ShowRank("Ассистент");
        }
    }
}
