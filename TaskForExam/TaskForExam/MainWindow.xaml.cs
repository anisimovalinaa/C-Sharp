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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClick(Button button)
        {
            teacher.Background = Brushes.LightGray;
            list.Background = Brushes.LightGray;
            student.Background = Brushes.LightGray;
            student_pers.Background = Brushes.LightGray;
            teacher_pers.Background = Brushes.LightGray;
            discipline.Background = Brushes.LightGray;
            record.Background = Brushes.LightGray;
            
            button.Background = Brushes.SteelBlue;
        }

        private void teacher_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(teacher);
            frame.Navigate(new Teacher());
        }

        private void student_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(student);
            frame.Navigate(new Student());
        }

        private void student_pers_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(student_pers);
            frame.Navigate(new PersStudent());
        }

        private void teacher_pers_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(teacher_pers);
            frame.Navigate(new PersTeacher());
        }

        private void list_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(list);
            frame.Navigate(new List());
        }

        private void discipline_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(discipline);
            frame.Navigate(new Discipline());
        }

        private void record_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(record);
            frame.Navigate(new AcademicRecord());
        }
    }
}
