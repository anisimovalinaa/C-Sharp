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
using System.Windows.Shapes;

namespace TaskForExam
{
    /// <summary>
    /// Логика взаимодействия для Close.xaml
    /// </summary>
    public partial class Close : Window
    {
        public Close(System.ComponentModel.CancelEventArgs s)
        {
            InitializeComponent();
            this.s = s;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        System.ComponentModel.CancelEventArgs s;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            s.Cancel = true;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            s.Cancel = false;
            Close();
        }
    }
}
