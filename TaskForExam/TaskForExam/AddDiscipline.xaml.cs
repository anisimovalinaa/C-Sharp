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
    /// Логика взаимодействия для AddDiscipline.xaml
    /// </summary>
    public partial class AddDiscipline : Window
    {
        public AddDiscipline(DataGrid table)
        {
            InitializeComponent();
            this.table = table;
        }
        DataGrid table;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text == "" || hours.Text == "" || semester.Text == "" || speciality.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                ListInterface a = new ClassList();
                a.AddDiscipline(name.Text, hours.Text, semester.Text, speciality.Text);
            }
        }
    }
}
