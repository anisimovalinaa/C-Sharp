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
    /// Логика взаимодействия для List.xaml
    /// </summary>
    public partial class List : Page
    {
        public List()
        {
            InitializeComponent();
            Show();
            ListInterface a = new ClassList();
            group.ItemsSource = a.GetGroup();
            teacher.ItemsSource = a.GetTeacher();
        }
        private void Show()
        {
            tableList.Items.Clear();
            ListInterface a = new ClassList();
            a.Show(tableList);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tableList.Items.Clear();
            ListInterface a = new ClassList();
            a.ShowGroup(tableList, type, group);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddList window = new AddList(tableList);
            window.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            tableList.Items.Clear();
            ListInterface a = new ClassList();
            a.ShowTeacher(tableList, type1, teacher);

        }
    }
}
