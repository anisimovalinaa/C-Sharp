﻿using System;
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
    /// Логика взаимодействия для Student.xaml
    /// </summary>
    public partial class Student : Page
    {
        public Student()
        {
            InitializeComponent();
            Show();
            StudentInterface a = new ClassStudent();
            group.ItemsSource = a.GetGroup();
        }

        private void Show()
        {
            tableStudent.Items.Clear();
            Operations a = new ClassStudent();
            a.Show(tableStudent);

        }

        delegate Excel.Workbook workbook(DataGrid table);
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            workbook wb = new workbook(Docs.TableToExcel);
            Docs.SaveDocs(wb(tableStudent));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (group.Text == "")
            {
                a1.Visibility = Visibility.Visible;
                p.Visibility = Visibility.Visible;
            }
            else
            {
                tableStudent.Items.Clear();
                StudentInterface a = new ClassStudent();
                a.ShowGroup(tableStudent, group.Text);
                group.SelectedIndex = -1;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            AddStudent window = new AddStudent();
            window.ShowDialog();
            Show();
        }

        private void group_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            a1.Visibility = Visibility.Hidden;
            p.Visibility = Visibility.Hidden;
        }
    }
}
