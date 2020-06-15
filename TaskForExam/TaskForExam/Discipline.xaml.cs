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
    /// Логика взаимодействия для Discipline.xaml
    /// </summary>
    public partial class Discipline : Page
    {
        public Discipline()
        {
            InitializeComponent();
            Show();
        }
        private void Show()
        {
            tableDiscipline.Items.Clear();
            ListInterface a = new ClassList();
            a.ShowDisciplines(tableDiscipline);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (specComboBox.Text == "" || semester.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                ListInterface a = new ClassList();
                tableDiscipline.Items.Clear();
                a.ShowSemester(tableDiscipline, specComboBox.Text, semester.Text);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddDiscipline window = new AddDiscipline(tableDiscipline);
            window.ShowDialog();
            Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AddDiscipline window = new AddDiscipline(tableDiscipline);
            window.ShowDialog();
            Show();
        }

        delegate Excel.Workbook workbook(DataGrid table);
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            workbook wb = new workbook(Docs.TableToExcel);
            Docs.SaveDocs(wb(tableDiscipline));
        }
    }
}
