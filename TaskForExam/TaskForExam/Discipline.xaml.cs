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
            ListInterface a = new ClassList();
            tableDiscipline.Items.Clear();
            a.ShowSemester(tableDiscipline, specComboBox, semester);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddDiscipline window = new AddDiscipline(tableDiscipline);
            window.ShowDialog();
            Show();
        }
    }
}
