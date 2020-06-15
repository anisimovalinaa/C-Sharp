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
    /// Логика взаимодействия для PersStudent.xaml
    /// </summary>
    public partial class PersStudent : Page
    {
        public PersStudent()
        {
            InitializeComponent();
            Show();
            StudentInterface a = new ClassStudent();
            group.ItemsSource = a.GetGroup();
        }

        private void Show()
        {
            tablePersStudent.Items.Clear();
            Operations a = new ClassStudent();
            a.ShowPers(tablePersStudent);
        }

        delegate Excel.Workbook workbook(DataGrid table);
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            workbook wb = new workbook(Docs.TableToExcel);
            Docs.SaveDocs(wb(tablePersStudent));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (group.Text == "")
                MessageBox.Show("Такой группы нет!", "ОШИБКА");
            else
            {
                tablePersStudent.Items.Clear();
                StudentInterface a = new ClassStudent();
                a.ShowPersGroup(tablePersStudent, group.Text);
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Show();
        }
    }
}
