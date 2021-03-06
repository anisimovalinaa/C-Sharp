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
            group.Background = Brushes.LightGray;
            teacher.Foreground = Brushes.Black;
            list.Foreground = Brushes.Black;
            student.Foreground = Brushes.Black;
            discipline.Foreground = Brushes.Black;
            record.Foreground = Brushes.Black;
            teacher_pers.Foreground = Brushes.Black;
            student_pers.Foreground = Brushes.Black;
            group.Foreground = Brushes.Black;

            button.Background = Brushes.SteelBlue;
            button.Foreground = Brushes.White;
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Close window = new Close(e);
            window.ShowDialog();
        }

        private void group_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(group);
            frame.Navigate(new Groups());
        }

        private void MenuItem_MouseEnter(object sender, MouseEventArgs e)
        {
            pop1.IsOpen = true;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key == Key.F1)
            {
                ButtonClick(teacher);
                frame.Navigate(new Teacher());
            }
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key == Key.F2)
            {
                ButtonClick(teacher_pers);
                frame.Navigate(new PersTeacher());
            }
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key == Key.F3)
            {
                ButtonClick(student);
                frame.Navigate(new Student());
            }
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key == Key.F4)
            {
                ButtonClick(student_pers);
                frame.Navigate(new PersStudent());
            }
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key == Key.F5)
            {
                ButtonClick(list);
                frame.Navigate(new List());
            }
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key == Key.F6)
            {
                ButtonClick(discipline);
                frame.Navigate(new Discipline());
            }
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key == Key.F7)
            {
                ButtonClick(record);
                frame.Navigate(new AcademicRecord());
            }
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key == Key.F8)
            {
                ButtonClick(group);
                frame.Navigate(new Groups());
            }
        }

        private void MenuItem_MouseEnter_1(object sender, MouseEventArgs e)
        {
            pop2.IsOpen = true;
        }
    }
}
