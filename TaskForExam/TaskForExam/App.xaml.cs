using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace TaskForExam
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
    }
    public class Docs
    {
        public static Excel.Workbook TableToExcel(DataGrid table)
        {
            Excel.Application excel = new Excel.Application();
            //excel.Visible = false;
            Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Excel.Worksheet sheet1 = (Excel.Worksheet)excel.Worksheets.get_Item(1);

            for (int j = 0; j < table.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                myRange.Value2 = table.Columns[j].Header;
            }
            for (int i = 0; i < table.Columns.Count; i++)
            {
                for (int j = 0; j < table.Items.Count; j++)
                {
                    TextBlock b = table.Columns[i].GetCellContent(table.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }
            return workbook;
        }
        public static void SaveDocs(Excel.Workbook workbook)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "xls files (*.xls)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == true)
            {
                string fileName = saveFileDialog1.FileName;
                workbook.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                //sheet1 = (Excel.Worksheet)workbook.Sheets.get_Item(1);
            }
        }
    }
    public class Connection
    {
        protected
            MySqlConnection myConnection;
        protected Connection()
        {
            string host = "127.0.0.1"; // Имя локального компьютера
            string database = "department"; // Имя базы данных
            string user = "root"; // Имя пользователя

            string Connect = "Database=" + database + ";Datasource=" + host + ";User=" + user;
            myConnection = new MySqlConnection(Connect);
            myConnection.Open();
        }
        ~Connection()
        {
            myConnection.Close();
        }
    }
    public class columnTeacher
    {
        public string surname { get; set; }
        public string name { get; set; }
        public string middle_name { get; set; }
        public string rank { get; set; }
    }
    public class columnStudent
    {
        public string surname { get; set; }
        public string name { get; set; }
        public string middle_name { get; set; }
        public string group { get; set; }
        public string year { get; set; }
    }
    public class columnPers
    {
        public string surname { get; set; }
        public string name { get; set; }
        public string middle_name { get; set; }
        public string series { get; set; }
        public string number { get; set; }
        public string sex { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string numberH { get; set; }
        public string flat { get; set; }
        public string phone_number { get; set; }
    }
    public class columnList
    {
        public string discipline { get; set; }
        public string group { get; set; }
        public string type { get; set; }
        public string teacher { get; set; }
    }
    public class columnDiscipline
    {
        public string discipline { get; set; }
        public string hours { get; set; }
        public string semester { get; set; }
        public string speciality { get; set; }
    }
    public class columnRecord
    {
        public string list { get; set; }
        public string student { get; set; }
        public string mark { get; set; }
    }
    public interface Operations
    {
        void Show(DataGrid table);
        void ShowPers(DataGrid table);
    }
    public interface StudentInterface
    {
        void Insert(TextBox series, TextBox number, string sex, TextBox city, TextBox street, TextBox numberH, TextBox flat, TextBox phone,
            TextBox surname, TextBox name, TextBox middle_name, TextBox group, ComboBox spec, TextBox year, DataGrid table);
        void ShowGroup(DataGrid table, TextBox group);
    }
    public interface TeacherInterface
    {
        void Insert(TextBox series, TextBox number, string sex, TextBox city, TextBox street, TextBox home, TextBox flat, TextBox phone, TextBox surname,
            TextBox name, TextBox middle_name, ComboBox rank, DataGrid table);
        void ShowRank(DataGrid table, ComboBox rank);
        void ShowPersRank(DataGrid table, ComboBox rank);
    }
    public interface ListInterface
    {
        void Show(DataGrid table);
        void ShowGroup(DataGrid table, ComboBox type, ComboBox group);
        void ShowTeacher(DataGrid table, ComboBox type, ComboBox teacher);
        string[] GetGroup();
        string[] GetTeacher();
        List<string> GetDisciplineGroup(string group, string type, string semester);
        List<string> GetDisciplineSpec(string semester, string group);
        List<string> GetStudents(string group);
        void InsertList(string semester, string discipline, string group, string type, string teacher, DataGrid table);
        void ShowDisciplines(DataGrid table);
        void ShowSemester(DataGrid table, ComboBox speciality, ComboBox semester);
        void ShowMarkGroup(DataGrid table, string group, string semester, string type, string disc);
        void AddDiscipline(DataGrid table, TextBox name, TextBox hours, ComboBox semester, ComboBox speciality);
        void AddMark(ComboBox semester, ComboBox type, ComboBox group, ComboBox discipline, ComboBox student, ComboBox mark);
        void ShowRecord(DataGrid table);
    }

    public class ClassList: Connection, ListInterface
    {
        public void Show(DataGrid table)
        {
            string comStr = "SELECT b.name, b.semester, c.number, a.type, d.surname, d.name, d.middle_name " +
                "FROM `list` a " +
                "LEFT OUTER JOIN `discipline` b ON b.id = a.discipline " +
                "LEFT OUTER JOIN `group` c ON c.id = a.group " +
                "LEFT OUTER JOIN `teacher` d ON d.id = a.teacher";
            MySqlCommand com = new MySqlCommand(comStr, myConnection);
            MySqlDataReader reader = com.ExecuteReader();

            while(reader.Read())
            {
                table.Items.Add(new columnList()
                {
                    discipline = reader[0].ToString() + ". Семестр " + reader[1].ToString(),
                    group = reader[2].ToString(),
                    type = reader[3].ToString(),
                    teacher = reader[4].ToString() + " " + reader[5].ToString() + " " + reader[6].ToString()
                });
            }
            reader.Close();
        }
        public void ShowDisciplines(DataGrid table)
        {
            string comStr = "SELECT d.name, d.hours, d.semester, s.name " +
                "FROM `discipline` d " +
                "LEFT OUTER JOIN `speciality` s ON s.id = d.speciality ";
            MySqlCommand com = new MySqlCommand(comStr, myConnection);
            MySqlDataReader reader = com.ExecuteReader();

            while(reader.Read())
            {
                table.Items.Add(new columnDiscipline()
                {
                    discipline = reader[0].ToString(),
                    hours = reader[1].ToString(),
                    semester = reader[2].ToString(),
                    speciality = reader[3].ToString()
                });
            }
            reader.Close();
        }
        public List<string> GetDisciplineSpec(string semester, string group)
        {
            List<string> disc = new List<string>();
            string nameSpec = "SELECT s.name " +
                "FROM `speciality` s " +
                "LEFT OUTER JOIN `group` g ON g.speciality = s.id " +
                "WHERE g.number = '" + group + "'";
            string idSpec = "SELECT `id` FROM `speciality` WHERE `name` = (" + nameSpec + ")";
            string comStr = "SELECT `name` FROM `discipline` WHERE `semester` = '" + semester + "' AND speciality = (" + idSpec + ")";
            MySqlCommand com = new MySqlCommand(comStr, myConnection);
            MySqlDataReader reader = com.ExecuteReader();

            while(reader.Read())
            {
                disc.Add(reader[0].ToString());
            }
            reader.Close();

            return disc;
        }
        public List<string> GetDisciplineGroup(string group, string type, string semester)
        {
            List<string> disc = new List<string>();
            string comStr2 = "SELECT `name` FROM  `discipline` WHERE id = (SELECT `discipline` FROM `list` " + 
                "WHERE `group` = (SELECT `id` FROM `group` WHERE `number` = " + group + ") AND `type` = '" + type + "') " +
                "AND `semester` = '" + semester + "'";
            MySqlCommand com2 = new MySqlCommand(comStr2, myConnection);
            MySqlDataReader reader = com2.ExecuteReader();

            while(reader.Read())
            {
                disc.Add(reader[0].ToString());
            }
            reader.Close();

            return disc;
        }
        public void ShowMarkGroup(DataGrid table, string group, string semester, string type, string disc)
        {
            string comStr = "SELECT l.type, d.semester, g.number, d.name, s.surname, s.name, s.middle_name, e.mark " +
                "FROM `educational_performance` e " +
                "LEFT OUTER JOIN `list` l ON l.id = e.list " +
                "LEFT OUTER JOIN `discipline` d ON d.id = l.discipline " +
                "LEFT OUTER JOIN `student` s ON s.id = e.student " +
                "LEFT OUTER JOIN `group` g ON g.id = l.group " +
                "WHERE g.number = '" + group + "' AND d.semester = '" + semester + "' AND l.type = '" + type + "' AND d.name = '" + disc + "'";

            MySqlCommand com1 = new MySqlCommand(comStr, myConnection);
            MySqlDataReader reader = com1.ExecuteReader();

            while (reader.Read())
            {
                table.Items.Add(new columnRecord()
                {
                    list = reader[0].ToString() + ". Семестр " + reader[1].ToString() + ". Группа " + reader[2].ToString() + ". " + reader[3].ToString(),
                    student = reader[4].ToString() + " " + reader[5].ToString() + " " + reader[6].ToString(),
                    mark = reader[7].ToString()
                });
            }
            reader.Close();
        }
        public void AddMark(ComboBox semester, ComboBox type, ComboBox group, ComboBox discipline, ComboBox student, ComboBox mark)
        {
            string[] nameS = student.Text.Split(' ');
            string nameSpec = "SELECT s.name " +
                "FROM `speciality` s " +
                "LEFT OUTER JOIN `group` g ON g.speciality = s.id " +
                "WHERE g.number = '" + group.Text + "'"; 
            string idSpec = "SELECT `id` FROM `speciality` WHERE `name` = (" + nameSpec + ")";
            string idDisc = "SELECT `id` FROM `discipline` WHERE `name` = '" + discipline.Text + "' AND `speciality` = (" + idSpec + ") " +
                "AND semester = '" + semester.Text + "'";

            string idStudent = "SELECT `id` FROM `student` WHERE `surname` = '" + nameS[0] + "' AND `name` = '" + nameS[1] + "' AND `middle_name` = '" +
                nameS[2] + "' AND `group` = (SELECT `id` FROM `group` WHERE `number` = '" + group.Text + "')";

            string idList = "SELECT `id` FROM `list` WHERE `type` = '" + type.Text + "' AND `group` = " +
                "(SELECT `id` FROM `group` WHERE `number` = '" + group.Text + "') AND `discipline` = (" + idDisc + ")";
            string comStr1 = "INSERT INTO `department`.`educational_performance` (`list`, `student`, `mark`)" +
                             "VALUES((" + idList + "), (" + idStudent + "), '" + mark.Text + "')";
            MySqlCommand com1 = new MySqlCommand(comStr1, myConnection);
            com1.ExecuteNonQuery();
        }
        public void ShowRecord(DataGrid table)
        {
            string comStr = "SELECT l.type, d.semester, g.number, d.name, s.surname, s.name, s.middle_name, e.mark " +
                "FROM `educational_performance` e " +
                "LEFT OUTER JOIN `list` l ON l.id = e.list " +
                "LEFT OUTER JOIN `discipline` d ON d.id = l.discipline " +
                "LEFT OUTER JOIN `student` s ON s.id = e.student " +
                "LEFT OUTER JOIN `group` g ON g.id = l.group ";

            MySqlCommand com1 = new MySqlCommand(comStr, myConnection);
            MySqlDataReader reader = com1.ExecuteReader();

            while(reader.Read())
            {
                table.Items.Add(new columnRecord()
                {
                    list = reader[0].ToString() + ". Семестр " + reader[1].ToString() + ". Группа " + reader[2].ToString() + ". " + reader[3].ToString(),
                    student = reader[4].ToString() + " " + reader[5].ToString() + " " + reader[6].ToString(),
                    mark = reader[7].ToString()
                });
            }
            reader.Close();
        }
        public void ShowSemester(DataGrid table, ComboBox speciality, ComboBox semester)
        {
            string comStr = "SELECT d.name, d.hours, d.semester, s.name " +
                "FROM `discipline` d " +
                "LEFT OUTER JOIN `speciality` s ON s.id = d.speciality " + 
                "WHERE (d.semester = " + semester.Text + " AND s.name = '" + speciality.Text + "')";
            MySqlCommand com = new MySqlCommand(comStr, myConnection);
            MySqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                table.Items.Add(new columnDiscipline()
                {
                    discipline = reader[0].ToString(),
                    hours = reader[1].ToString(),
                    semester = reader[2].ToString(),
                    speciality = reader[3].ToString()
                });
            }
            reader.Close();
        }
        public void ShowTeacher(DataGrid table, ComboBox type, ComboBox teacher)
        {
            string[] nameT = teacher.Text.Split(' ');

            string comStr = "SELECT b.name, c.number, a.type, d.surname, d.name, d.middle_name " +
                "FROM `list` a " +
                "LEFT OUTER JOIN `discipline` b ON b.id = a.discipline " +
                "LEFT OUTER JOIN `group` c ON c.id = a.group " +
                "LEFT OUTER JOIN `teacher` d ON d.id = a.teacher " +
                "WHERE a.type = '" + type.Text + "' AND d.surname = '" + nameT[0] + "' AND d.name = '" + nameT[1] + "' AND d.middle_name = '" + nameT[2] + "'";
            MySqlCommand com = new MySqlCommand(comStr, myConnection);
            MySqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                table.Items.Add(new columnList()
                {
                    discipline = reader[0].ToString(),
                    group = reader[1].ToString(),
                    type = reader[2].ToString(),
                    teacher = reader[3].ToString() + " " + reader[4].ToString() + " " + reader[5].ToString()
                });
            }
            reader.Close();
        }
        public void ShowGroup(DataGrid table, ComboBox type, ComboBox group)
        {
            string comStr = "SELECT b.name, c.number, a.type, d.surname, d.name, d.middle_name " +
                "FROM `list` a " +
                "LEFT OUTER JOIN `discipline` b ON b.id = a.discipline " +
                "LEFT OUTER JOIN `group` c ON c.id = a.group " +
                "LEFT OUTER JOIN `teacher` d ON d.id = a.teacher " +
                "WHERE (a.type = '" + type.Text + "' AND c.number = " + group.Text + ")";
            MySqlCommand com = new MySqlCommand(comStr, myConnection);
            MySqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                table.Items.Add(new columnList()
                {
                    discipline = reader[0].ToString(),
                    group = reader[1].ToString(),
                    type = reader[2].ToString(),
                    teacher = reader[3].ToString() + " " + reader[4].ToString() + " " + reader[5].ToString()
                });
            }
            reader.Close();
        }

        public List<string> GetStudents(string group)
        {
            string comStr1 = "SELECT `surname`, `name`, `middle_name` FROM `student` " +
                "WHERE `group` = (SELECT `id` FROM `group` WHERE `number` = '" + group + "')";

            MySqlCommand com1 = new MySqlCommand(comStr1, myConnection);
            MySqlDataReader reader1 = com1.ExecuteReader();

            List<string> list = new List<string>();

            while (reader1.Read())
            {
                list.Add(reader1[0].ToString() + " " +
                    reader1[1].ToString() + " " + reader1[2].ToString());
            }
            reader1.Close();
            return list;
        }

        public void AddDiscipline(DataGrid table, TextBox name, TextBox hours, ComboBox semester, ComboBox speciality)
        {
            string comstr1 = "SELECT * FROM `speciality` " + 
                "WHERE name = '" + speciality.Text + "'";
            MySqlCommand com1 = new MySqlCommand(comstr1, myConnection);
            MySqlDataReader reader1 = com1.ExecuteReader();

            string idS = "";
            while(reader1.Read())
            {
                idS = reader1[0].ToString();
            }
            reader1.Close();

            string comStr2 =
                "INSERT INTO `department`.`discipline` (`name` ,`hours` ,`semester` ,`speciality`)" +
                "VALUES('" + name.Text + "', '" + hours.Text + "', '" + semester.Text + "', '" + idS + "')";
            MySqlCommand com2 = new MySqlCommand(comStr2, myConnection);
            com2.ExecuteNonQuery();
        }
        public string[] GetGroup()
        {
            string comStr1 = "SELECT count(*) FROM `group`";
            MySqlCommand com1 = new MySqlCommand(comStr1, myConnection);
            MySqlDataReader reader = com1.ExecuteReader();
            string count = "";
            while (reader.Read())
            {
                count = reader[0].ToString();
            }
            reader.Close();

            string comstr2 = "SELECT * FROM `group`";
            MySqlCommand com2 = new MySqlCommand(comstr2, myConnection);
            MySqlDataReader reader1 = com2.ExecuteReader();

            string[] groups = new string[int.Parse(count)];
            int i = 0;
            while (reader1.Read())
            {
                groups[i] = reader1[1].ToString();
                i++;
            }
            reader1.Close();

            return groups;
        }
        public string[] GetTeacher()
        {
            string comStr1 = "SELECT count(*) FROM `teacher`";
            MySqlCommand com1 = new MySqlCommand(comStr1, myConnection);
            MySqlDataReader reader = com1.ExecuteReader();
            string count = "";
            while (reader.Read())
            {
                count = reader[0].ToString();
            }
            reader.Close();

            string comstr2 = "SELECT * FROM `teacher`";
            MySqlCommand com2 = new MySqlCommand(comstr2, myConnection);
            MySqlDataReader reader1 = com2.ExecuteReader();

            string[] teachers = new string[int.Parse(count)];
            int i = 0;
            while (reader1.Read())
            {
                teachers[i] = reader1[1].ToString() + " " + reader1[2].ToString() + " " + reader1[3].ToString() + " ";
                i++;
            }
            reader1.Close();

            return teachers;
        }
        public void InsertList(string semester, string discipline, string group, string type, string teacher, DataGrid table)
        {
            string comstr1 = "SELECT * FROM `discipline` WHERE name = '" + discipline + "' AND `semester` = '" + semester + "'";
            MySqlCommand com1 = new MySqlCommand(comstr1, myConnection);
            MySqlDataReader reader1 = com1.ExecuteReader();

            string idD = "";
            while(reader1.Read())
            {
                idD = reader1[0].ToString();
            }
            reader1.Close();

            string comstr2 = "SELECT * FROM `group` WHERE number = '" + group + "'";
            MySqlCommand com2 = new MySqlCommand(comstr2, myConnection);
            MySqlDataReader reader2 = com2.ExecuteReader();

            string idG = "";
            while(reader2.Read())
            {
                idG = reader2[0].ToString();
            }
            reader2.Close();

            string[] nameT = teacher.Split(' ');
            string comstr3 = "SELECT * FROM `teacher` WHERE (surname = '" + nameT[0] + "' AND name = '" + nameT[1] + "' AND middle_name = '" + nameT[2] + "')";
            MySqlCommand com3 = new MySqlCommand(comstr3, myConnection);
            MySqlDataReader reader3 = com3.ExecuteReader();

            string idT = "";
            while(reader3.Read())
            {
                idT = reader3[0].ToString();
            }
            reader3.Close();

            string comStr4 =
                "INSERT INTO `department`.`list` (`discipline` ,`group` ,`type` ,`teacher`)" +
                "VALUES('" + idD + "', '" + idG + "', '" + type + "', '" + idT + "')";
            MySqlCommand com4 = new MySqlCommand(comStr4, myConnection);
            com4.ExecuteNonQuery();

            table.Items.Add(new columnList()
            {
                discipline = discipline + ". Семестр " + semester,
                group = group,
                type = type,
                teacher = teacher
            });
        }
    }
    public class ClassTeacher : Connection, Operations, TeacherInterface
    {
        //private static
        //Connection connection = new Connection();
        public void Show(DataGrid table)
        {
            string comStr = "SELECT * FROM teacher";
            MySqlCommand com = new MySqlCommand(comStr, myConnection);
            MySqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                table.Items.Add(new columnTeacher() { surname = reader[1].ToString(), name = reader[2].ToString(), middle_name = reader[3].ToString(), rank = reader[4].ToString() });
            }
            reader.Close();
        }
        public void ShowPers(DataGrid table)
        {
            string comStr = "SELECT a.surname, a.name, a.middle_name, b.series, b.number, b.sex, b.city, b.street, b.home, b.flat, b.phone_number " +
                "FROM `teacher` a " +
                "LEFT OUTER JOIN `pers_teacher` b ON b.id = a.id";
            MySqlCommand com = new MySqlCommand(comStr, myConnection);
            MySqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                table.Items.Add(new columnPers()
                {
                    surname = reader[0].ToString(),
                    name = reader[1].ToString(),
                    middle_name = reader[2].ToString(),
                    series = reader[3].ToString(),
                    number = reader[4].ToString(),
                    sex = reader[5].ToString(),
                    city = reader[6].ToString(),
                    street = reader[7].ToString(),
                    numberH = reader[8].ToString(),
                    flat = reader[9].ToString(),
                    phone_number = reader[10].ToString()
                });
            }
            reader.Close();
        }
        public void Insert(TextBox series, TextBox number, string sex, TextBox city, TextBox street, TextBox home, TextBox flat, TextBox phone, TextBox surname,
            TextBox name, TextBox middle_name, ComboBox rank, DataGrid table)
        {
            string comStr1 =
                "INSERT INTO `department`.`pers_teacher` (`series` ,`number` ,`sex` ,`city` ,`street` ,`home`, `flat`, `phone_number`)" +
                "VALUES('" + series.Text + "', '" + number.Text + "', '" + sex + "', '" + city.Text + "', '" + street.Text +
                "', '" + home.Text + "', '" + flat.Text + "', '" + phone.Text + "')";
            MySqlCommand com1 = new MySqlCommand(comStr1, myConnection);
            com1.ExecuteNonQuery();

            string comstr2 = "SELECT * FROM pers_teacher";
            MySqlCommand com2 = new MySqlCommand(comstr2, myConnection);
            MySqlDataReader reader1 = com2.ExecuteReader();

            string id = "";
            while (reader1.Read())
            {
                id = reader1[0].ToString();
            }
            reader1.Close();

            string comStr3 =
                "INSERT INTO `department`.`teacher` (`id`, `surname` ,`name` ,`middle_name` ,`academic_rank`)" +
                "VALUES('" + id + "', '" + surname.Text + "', '" + name.Text + "', '" + middle_name.Text + "', '" + rank.Text + "')";
            MySqlCommand com3 = new MySqlCommand(comStr3, myConnection);
            com3.ExecuteNonQuery();

            table.Items.Add(new columnTeacher()
            {
                surname = surname.Text,
                name = name.Text,
                middle_name = middle_name.Text,
                rank = rank.Text
            });
        }
        public void ShowRank(DataGrid table, ComboBox rank)
        {
            string comstr1 = "SELECT * FROM teacher WHERE academic_rank = '" + rank.Text + "'";
            MySqlCommand com1 = new MySqlCommand(comstr1, myConnection);
            MySqlDataReader reader = com1.ExecuteReader();

            while (reader.Read())
            {
                table.Items.Add(new columnTeacher()
                {
                    surname = reader[1].ToString(),
                    name = reader[2].ToString(),
                    middle_name = reader[3].ToString(),
                    rank = reader[4].ToString()
                });
            }
            reader.Close();
        }
        public void ShowPersRank(DataGrid table, ComboBox rank)
        {
            string comStr = "SELECT a.surname, a.name, a.middle_name, b.series, b.number, b.sex, b.city, b.street, b.home, b.flat, b.phone_number " +
                "FROM `teacher` a " +
                "LEFT OUTER JOIN `pers_teacher` b ON b.id = a.id " +
                "WHERE a.academic_rank = '" + rank.Text + "'";
            MySqlCommand com = new MySqlCommand(comStr, myConnection);
            MySqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                table.Items.Add(new columnPers()
                {
                    surname = reader[0].ToString(),
                    name = reader[1].ToString(),
                    middle_name = reader[2].ToString(),
                    series = reader[3].ToString(),
                    number = reader[4].ToString(),
                    sex = reader[5].ToString(),
                    city = reader[6].ToString(),
                    street = reader[7].ToString(),
                    numberH = reader[8].ToString(),
                    flat = reader[9].ToString(),
                    phone_number = reader[10].ToString()
                });
            }
            reader.Close();
        }
    }
    public class ClassStudent : Connection, Operations, StudentInterface
    {
        public void ShowPers(DataGrid table)
        {
            string comStr = "SELECT a.surname, a.name, a.middle_name, b.series, b.number, b.sex, b.city, b.street, b.home, b.flat, b.phone_number " +
                "FROM `student` a " +
                "LEFT OUTER JOIN `pers_student` b ON b.id = a.id";
            MySqlCommand com = new MySqlCommand(comStr, myConnection);
            MySqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                table.Items.Add(new columnPers()
                {
                    surname = reader[0].ToString(),
                    name = reader[1].ToString(),
                    middle_name = reader[2].ToString(),
                    series = reader[3].ToString(),
                    number = reader[4].ToString(),
                    sex = reader[5].ToString(),
                    city = reader[6].ToString(),
                    street = reader[7].ToString(),
                    numberH = reader[8].ToString(),
                    flat = reader[9].ToString(),
                    phone_number = reader[10].ToString()
                });
            }
            reader.Close();
        }
        public void Show(DataGrid table)
        {
            string comStr = "SELECT a.surname, a.name, a.middle_name, b.number, a.year " +
                "FROM `student` a " +
                "LEFT OUTER JOIN `group` b ON b.id = a.group";
            MySqlCommand com = new MySqlCommand(comStr, myConnection);
            MySqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                table.Items.Add(new columnStudent()
                {
                    surname = reader[0].ToString(),
                    name = reader[1].ToString(),
                    middle_name = reader[2].ToString(),
                    group = reader[3].ToString(),
                    year = reader[4].ToString()
                });
            }
            reader.Close();
        }
        public void Insert(TextBox series, TextBox number, string sex, TextBox city, TextBox street, TextBox numberH, TextBox flat, TextBox phone,
            TextBox surname, TextBox name, TextBox middle_name, TextBox group, ComboBox spec, TextBox year, DataGrid table)
        {
            string comStr1 =
                "INSERT INTO `department`.`pers_student` (`series` ,`number` ,`sex` ,`city` ,`street` ,`home`, `flat`, `phone_number`)" +
                "VALUES('" + series.Text + "', '" + number.Text + "', '" + sex + "', '" + city.Text + "', '" + street.Text +
                "', '" + numberH.Text + "', '" + flat.Text + "', '" + phone.Text + "')";
            MySqlCommand com1 = new MySqlCommand(comStr1, myConnection);
            com1.ExecuteNonQuery();

            string comstr2 = "SELECT * FROM pers_student";
            MySqlCommand com2 = new MySqlCommand(comstr2, myConnection);
            MySqlDataReader reader1 = com2.ExecuteReader();

            string id = "";
            while (reader1.Read())
            {
                id = reader1[0].ToString();
            }
            reader1.Close();

            string comstr3 = "SELECT * FROM `group`";
            MySqlCommand com3 = new MySqlCommand(comstr3, myConnection);
            MySqlDataReader reader2 = com3.ExecuteReader();

            string idG = "";
            while (reader2.Read())
            {
                if (reader2[1].ToString() == group.Text) idG = reader2[0].ToString();
            }
            reader2.Close();

            if (idG == "")
            {
                string comstr4 = "SELECT * FROM speciality";
                MySqlCommand com4 = new MySqlCommand(comstr4, myConnection);
                MySqlDataReader reader3 = com4.ExecuteReader();

                string idS = "";
                while (reader3.Read())
                {
                    if (reader3[1].ToString() == spec.Text) idS = reader3[0].ToString();
                }
                reader3.Close();

                string comStr5 = "INSERT INTO `department`.`group` (`number` ,`speciality`)" +
                "VALUES('" + group.Text + "', '" + idS + "')";
                MySqlCommand com5 = new MySqlCommand(comStr5, myConnection);
                com5.ExecuteNonQuery();

                string comstr6 = "SELECT * FROM pers_student";
                MySqlCommand com6 = new MySqlCommand(comstr6, myConnection);
                MySqlDataReader reader4 = com6.ExecuteReader();

                while (reader4.Read())
                {
                    idG = reader4[0].ToString();
                }
                reader4.Close();
            }

            string comStr7 =
                "INSERT INTO `department`.`student` (`id`, `surname` ,`name` ,`middle_name` ,`group` ,`year`)" +
                "VALUES('" + id + "', '" + surname.Text + "', '" + name.Text + "', '" + middle_name.Text + "', '" + idG + "', '" + year.Text + "')";
            MySqlCommand com7 = new MySqlCommand(comStr7, myConnection);
            com7.ExecuteNonQuery();

            //string comStr8 = "SELECT * FROM student WHERE id = " + id;
            //MySqlCommand com8 = new MySqlCommand(comStr8, myConnection);
            //MySqlDataReader reader5 = com8.ExecuteReader();
            table.Items.Add(new columnStudent()
            {
                surname = surname.Text,
                name = name.Text,
                middle_name = middle_name.Text,
                group = group.Text,
                year = year.Text
            });
        }
        public void ShowGroup(DataGrid table, TextBox group)
        {
            string comstr1 = "SELECT * FROM `group`";
            MySqlCommand com1 = new MySqlCommand(comstr1, myConnection);
            MySqlDataReader reader1 = com1.ExecuteReader();

            string idG = "";
            while (reader1.Read())
            {
                if (reader1[1].ToString() == group.Text) idG = reader1[0].ToString();
            }
            reader1.Close();

            if (idG == "")
            {
                MessageBox.Show("Такой группы нет!", "ОШИБКА");
            }
            else
            {
                string comStr2 = "SELECT a.surname, a.name, a.middle_name, b.number, a.year " +
                    "FROM `student` a " +
                    "LEFT OUTER JOIN `group` b ON b.id = a.group " +
                    "WHERE a.group = " + idG;
                MySqlCommand com2 = new MySqlCommand(comStr2, myConnection);
                MySqlDataReader reader2 = com2.ExecuteReader();

                while (reader2.Read())
                {
                    table.Items.Add(new columnStudent()
                    {
                        surname = reader2[0].ToString(),
                        name = reader2[1].ToString(),
                        middle_name = reader2[2].ToString(),
                        group = reader2[3].ToString(),
                        year = reader2[4].ToString()
                    });
                }
            }
        }
        public void ShowPersGroup(DataGrid table, TextBox group)
        {
            string comstr1 = "SELECT * FROM `group`";
            MySqlCommand com1 = new MySqlCommand(comstr1, myConnection);
            MySqlDataReader reader1 = com1.ExecuteReader();

            string idG = "";
            while (reader1.Read())
            {
                if (reader1[1].ToString() == group.Text) idG = reader1[0].ToString();
            }
            reader1.Close();

            if (idG == "")
            {
                MessageBox.Show("Такой группы нет!", "ОШИБКА");
            }
            else
            {
                string comStr = "SELECT a.surname, a.name, a.middle_name, b.series, b.number, b.sex, b.city, b.street, b.home, b.flat, b.phone_number " +
                "FROM `student` a " +
                "LEFT OUTER JOIN `pers_student` b ON b.id = a.id " +
                "WHERE a.group = " + idG;
                MySqlCommand com = new MySqlCommand(comStr, myConnection);
                MySqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    table.Items.Add(new columnPers()
                    {
                        surname = reader[0].ToString(),
                        name = reader[1].ToString(),
                        middle_name = reader[2].ToString(),
                        series = reader[3].ToString(),
                        number = reader[4].ToString(),
                        sex = reader[5].ToString(),
                        city = reader[6].ToString(),
                        street = reader[7].ToString(),
                        numberH = reader[8].ToString(),
                        flat = reader[9].ToString(),
                        phone_number = reader[10].ToString()
                    });
                }
                reader.Close();
            }
        }
    }
}