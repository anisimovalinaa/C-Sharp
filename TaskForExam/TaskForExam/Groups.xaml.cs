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

        private void ShowSpec(string speciality)
        {
            table.Items.Clear();
            StudentInterface a = new ClassStudent();
            a.ShowGroupSpec(table, speciality);
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        { 
            Show();
        }

        delegate Excel.Workbook workbook(DataGrid table);
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            workbook wb = new workbook(Docs.TableToExcel);
            Docs.SaveDocs(wb(table));
        }

        private void s1_Click(object sender, RoutedEventArgs e)
        {
            ShowSpec(s1.Header.ToString());
        }

        private void s2_Click(object sender, RoutedEventArgs e)
        {
            ShowSpec(s2.Header.ToString());
        }

        private void s3_Click(object sender, RoutedEventArgs e)
        {
            ShowSpec(s3.Header.ToString());
        }

        private void s4_Click(object sender, RoutedEventArgs e)
        {
            ShowSpec(s4.Header.ToString());
        }

        private void number_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where
                         (ch => (ch >= '0' && ch <= '9') || ch == '+').ToArray()
                    );
            }
        }
    }
}
