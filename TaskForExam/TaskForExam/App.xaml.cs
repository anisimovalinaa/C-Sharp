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
        /// <summary>
        /// Создает из DataGrid файл Exel
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static Excel.Workbook TableToExcel(DataGrid table)
        {
            Excel.Application excel = new Excel.Application();
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
        /// <summary>
        /// Сохраняет Exel файл
        /// </summary>
        /// <param name="workbook"></param>
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

    public class columnGroup
    {
        public string number { get; set; }
        public string spec { get; set; }
    }
    public interface Operations
    {
        /// <summary>
        /// Выводит таблицу студентов или преподавателей
        /// </summary>
        /// <param name="table"></param>
        void Show(DataGrid table);

        /// <summary>
        /// Выводит таблицу контактов студентов или преподавателей
        /// </summary>
        /// <param name="table"></param>
        void ShowPers(DataGrid table);
    }
    public interface StudentInterface
    {
        /// <summary>
        /// Добавляет студента
        /// </summary>
        /// <param name="series"></param>
        /// <param name="number"></param>
        /// <param name="sex"></param>
        /// <param name="city"></param>
        /// <param name="street"></param>
        /// <param name="numberH"></param>
        /// <param name="flat"></param>
        /// <param name="phone"></param>
        /// <param name="surname"></param>
        /// <param name="name"></param>
        /// <param name="middle_name"></param>
        /// <param name="group"></param>
        /// <param name="spec"></param>
        /// <param name="year"></param>
        /// <param name="table"></param>
        void Insert(TextBox series, TextBox number, string sex, TextBox city, TextBox street, TextBox numberH, TextBox flat, TextBox phone,
            TextBox surname, TextBox name, TextBox middle_name, TextBox group, ComboBox spec, TextBox year, DataGrid table);

        /// <summary>
        /// Выводит список студентов указанной группы
        /// </summary>
        /// <param name="table"></param>
        /// <param name="group"></param>
        void ShowGroup(DataGrid table, string group);

        /// <summary>
        /// Выводит таблицу групп
        /// </summary>
        /// <param name="table"></param>
        void ShowGroups(DataGrid table);

        /// <summary>
        /// Выводит таблицу контактов студентов указанной группы
        /// </summary>
        /// <param name="table"></param>
        /// <param name="group"></param>
        void ShowPersGroup(DataGrid table, string group);

        /// <summary>
        /// Выводит список групп указанной специальности
        /// </summary>
        /// <param name="table"></param>
        /// <param name="spec"></param>
        void ShowGroupSpec(DataGrid table, string spec);

        /// <summary>
        /// Добавляет группу
        /// </summary>
        /// <param name="number"></param>
        /// <param name="spec"></param>
        void InsertGroup(string number, string spec);

        /// <summary>
        /// Получает список студентов указанной группы
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        List<string> GetStudents(string group);

        /// <summary>
        /// Получает список групп
        /// </summary>
        /// <returns></returns>
        List<string> GetGroup();
    }
    public interface TeacherInterface
    {
        /// <summary>
        /// Добавляет преподавателя
        /// </summary>
        /// <param name="series"></param>
        /// <param name="number"></param>
        /// <param name="sex"></param>
        /// <param name="city"></param>
        /// <param name="street"></param>
        /// <param name="home"></param>
        /// <param name="flat"></param>
        /// <param name="phone"></param>
        /// <param name="surname"></param>
        /// <param name="name"></param>
        /// <param name="middle_name"></param>
        /// <param name="rank"></param>
        /// <param name="table"></param>
        void Insert(TextBox series, TextBox number, string sex, TextBox city, TextBox street, TextBox home, TextBox flat, TextBox phone, TextBox surname,
            TextBox name, TextBox middle_name, ComboBox rank);

        /// <summary>
        /// Выводит список преподавателей с указанием ученого звания
        /// </summary>
        /// <param name="table"></param>
        /// <param name="rank"></param>
        void ShowRank(DataGrid table, string rank);

        /// <summary>
        /// Выводит контакты преподавателей с указанием ученого звания
        /// </summary>
        /// <param name="table"></param>
        /// <param name="rank"></param>
        void ShowPersRank(DataGrid table, string rank);

        /// <summary>
        /// Получает список преподавателей
        /// </summary>
        /// <returns></returns>
        List<string> GetTeacher();
    }
    public interface ListInterface
    {
        /// <summary>
        /// Выводит список ведомостей в DataGrid
        /// </summary>
        /// <param name="table"></param>
        void Show(DataGrid table);

        /// <summary>
        /// Выводит список ведомостей в DataGrid с указанием групы и типа ведомости
        /// </summary>
        /// <param name="table"></param>
        /// <param name="type"></param>
        /// <param name="group"></param>
        void ShowGroup(DataGrid table, string type, string group);

        /// <summary>
        /// Выводит список ведомостей в DataGrid с указанием преподавателя и типа ведомости
        /// </summary>
        /// <param name="table"></param>
        /// <param name="type"></param>
        /// <param name="teacher"></param>
        void ShowTeacher(DataGrid table, string type, string teacher);

        /// <summary>
        /// Получает список дисциплин из таблицы ведомостей с указанием группы, типа ведомости и семестра
        /// </summary>
        /// <param name="group"></param>
        /// <param name="type"></param>
        /// <param name="semester"></param>
        List<string> GetDisciplineGroup(string group, string type, string semester);

        /// <summary>
        /// Получает список дисциплин по направлению с укзанием группы и семестра
        /// </summary>
        /// <param name="semester"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        List<string> GetDisciplineSpec(string semester, string group);

        /// <summary>
        /// Добавляет ведомость
        /// </summary>
        /// <param name="semester"></param>
        /// <param name="discipline"></param>
        /// <param name="group"></param>
        /// <param name="type"></param>
        /// <param name="teacher"></param>
        /// <param name="table"></param>
        void InsertList(string semester, string discipline, string group, string type, string teacher, DataGrid table);

        /// <summary>
        /// Выводит список дисциплин
        /// </summary>
        /// <param name="table"></param>
        void ShowDisciplines(DataGrid table);

        /// <summary>
        /// Выводит список дисциплин с указанием семестра и направления
        /// </summary>
        /// <param name="table"></param>
        /// <param name="speciality"></param>
        /// <param name="semester"></param>
        void ShowSemester(DataGrid table, string speciality, string semester);

        /// <summary>
        /// Выводит успеваемость студентов конкретной группы с указанием семестра, типа ведомости и дисциплины
        /// </summary>
        /// <param name="table"></param>
        /// <param name="group"></param>
        /// <param name="semester"></param>
        /// <param name="type"></param>
        /// <param name="disc"></param>
        void ShowMarkGroup(DataGrid table, string group, string semester, string type, string disc);

        /// <summary>
        /// Добавляет дисциплину
        /// </summary>
        /// <param name="table"></param>
        /// <param name="name"></param>
        /// <param name="hours"></param>
        /// <param name="semester"></param>
        /// <param name="speciality"></param>
        void AddDiscipline(string name, string hours, string semester, string speciality);

        /// <summary>
        /// Добаляет успеваемость студента по конкретной ведомости
        /// </summary>
        /// <param name="semester"></param>
        /// <param name="type"></param>
        /// <param name="group"></param>
        /// <param name="discipline"></param>
        /// <param name="student"></param>
        /// <param name="mark"></param>
        void AddMark(string semester, string type, string group, string discipline, string student, string mark);

        /// <summary>
        /// Выводит таблицу успеваемости студента
        /// </summary>
        /// <param name="table"></param>
        void ShowRecord(DataGrid table);
    }
    public class ClassList : Connection, ListInterface
    {
        public ClassList()
        {

        }
        /// <summary>
        /// Выводит список ведомостей в DataGrid
        /// </summary>
        /// <param name="table"></param>
        public void Show(DataGrid table)
        {
            string comStr = "SELECT b.name, b.semester, c.number, a.type, d.surname, d.name, d.middle_name " +
                "FROM `list` a " +
                "LEFT OUTER JOIN `discipline` b ON b.id = a.discipline " +
                "LEFT OUTER JOIN `group` c ON c.id = a.group " +
                "LEFT OUTER JOIN `teacher` d ON d.id = a.teacher";
            MySqlCommand com = new MySqlCommand(comStr, myConnection);
            MySqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
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

        /// <summary>
        /// Выводит список дисциплин
        /// </summary>
        /// <param name="table"></param>
        public void ShowDisciplines(DataGrid table)
        {
            string comStr = "SELECT d.name, d.hours, d.semester, s.name " +
                "FROM `discipline` d " +
                "LEFT OUTER JOIN `speciality` s ON s.id = d.speciality ";
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

        /// <summary>
        /// Получает список дисциплин по направлению с укзанием группы и семестра
        /// </summary>
        /// <param name="semester"></param>
        /// <param name="group"></param>
        /// <returns></returns>
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

            while (reader.Read())
            {
                disc.Add(reader[0].ToString());
            }
            reader.Close();

            return disc;
        }

        /// <summary>
        /// Получает список дисциплин из таблицы ведомостей с указанием группы, типа ведомости и семестра
        /// </summary>
        /// <param name="group"></param>
        /// <param name="type"></param>
        /// <param name="semester"></param>
        public List<string> GetDisciplineGroup(string group, string type, string semester)
        {
            List<string> disc = new List<string>();
            string comStr2 = "SELECT `name` FROM  `discipline` WHERE id = (SELECT `discipline` FROM `list` " +
                "WHERE `group` = (SELECT `id` FROM `group` WHERE `number` = " + group + ") AND `type` = '" + type + "') " +
                "AND `semester` = '" + semester + "'";
            MySqlCommand com2 = new MySqlCommand(comStr2, myConnection);
            MySqlDataReader reader = com2.ExecuteReader();

            while (reader.Read())
            {
                disc.Add(reader[0].ToString());
            }
            reader.Close();

            return disc;
        }

        /// <summary>
        /// Выводит успеваемость студентов конкретной группы с указанием семестра, типа ведомости и дисциплины
        /// </summary>
        /// <param name="table"></param>
        /// <param name="group"></param>
        /// <param name="semester"></param>
        /// <param name="type"></param>
        /// <param name="disc"></param>
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

        /// <summary>
        /// Добаляет успеваемость студента по конкретной ведомости
        /// </summary>
        /// <param name="semester"></param>
        /// <param name="type"></param>
        /// <param name="group"></param>
        /// <param name="discipline"></param>
        /// <param name="student"></param>
        /// <param name="mark"></param>
        public void AddMark(string semester, string type, string group, string discipline, string student, string mark)
        {
            string[] nameS = student.Split(' ');
            string nameSpec = "SELECT s.name " +
                "FROM `speciality` s " +
                "LEFT OUTER JOIN `group` g ON g.speciality = s.id " +
                "WHERE g.number = '" + group + "'";
            string idSpec = "SELECT `id` FROM `speciality` WHERE `name` = (" + nameSpec + ")";
            string idDisc = "SELECT `id` FROM `discipline` WHERE `name` = '" + discipline + "' AND `speciality` = (" + idSpec + ") " +
                "AND semester = '" + semester + "'";

            string idStudent = "SELECT `id` FROM `student` WHERE `surname` = '" + nameS[0] + "' AND `name` = '" + nameS[1] + "' AND `middle_name` = '" +
                nameS[2] + "' AND `group` = (SELECT `id` FROM `group` WHERE `number` = '" + group + "')";

            string idList = "SELECT `id` FROM `list` WHERE `type` = '" + type + "' AND `group` = " +
                "(SELECT `id` FROM `group` WHERE `number` = '" + group + "') AND `discipline` = (" + idDisc + ")";
            string comStr1 = "INSERT INTO `department`.`educational_performance` (`list`, `student`, `mark`)" +
                             "VALUES((" + idList + "), (" + idStudent + "), '" + mark + "')";
            MySqlCommand com1 = new MySqlCommand(comStr1, myConnection);
            com1.ExecuteNonQuery();
        }

        /// <summary>
        /// Выводит таблицу успеваемости студентов
        /// </summary>
        /// <param name="table"></param>
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

        /// <summary>
        /// Выводит список дисциплин с указанием семестра и направления
        /// </summary>
        /// <param name="table"></param>
        /// <param name="speciality"></param>
        /// <param name="semester"></param>
        public void ShowSemester(DataGrid table, string speciality, string semester)
        {
            string comStr = "SELECT d.name, d.hours, d.semester, s.name " +
                "FROM `discipline` d " +
                "LEFT OUTER JOIN `speciality` s ON s.id = d.speciality " +
                "WHERE (d.semester = " + semester + " AND s.name = '" + speciality + "')";
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

        /// <summary>
        /// Выводит список ведомостей в DataGrid с указанием преподавателя и типа ведомости
        /// </summary>
        /// <param name="table"></param>
        /// <param name="type"></param>
        /// <param name="teacher"></param>
        public void ShowTeacher(DataGrid table, string type, string teacher)
        {
            string[] nameT = teacher.Split(' ');

            string comStr = "SELECT b.name, c.number, a.type, d.surname, d.name, d.middle_name " +
                "FROM `list` a " +
                "LEFT OUTER JOIN `discipline` b ON b.id = a.discipline " +
                "LEFT OUTER JOIN `group` c ON c.id = a.group " +
                "LEFT OUTER JOIN `teacher` d ON d.id = a.teacher " +
                "WHERE a.type = '" + type + "' AND d.surname = '" + nameT[0] + "' AND d.name = '" + nameT[1] + "' AND d.middle_name = '" + nameT[2] + "'";
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
        /// <summary>
        /// Выводит список ведомостей в DataGrid с указанием групы и типа ведомости
        /// </summary>
        /// <param name="table"></param>
        /// <param name="type"></param>
        /// <param name="group"></param>
        public void ShowGroup(DataGrid table, string type, string group)
        {
            string comStr = "SELECT b.name, c.number, a.type, d.surname, d.name, d.middle_name " +
                "FROM `list` a " +
                "LEFT OUTER JOIN `discipline` b ON b.id = a.discipline " +
                "LEFT OUTER JOIN `group` c ON c.id = a.group " +
                "LEFT OUTER JOIN `teacher` d ON d.id = a.teacher " +
                "WHERE (a.type = '" + type + "' AND c.number = " + group + ")";
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

        /// <summary>
        /// Добавляет дисциплину
        /// </summary>
        /// <param name="table"></param>
        /// <param name="name"></param>
        /// <param name="hours"></param>
        /// <param name="semester"></param>
        /// <param name="speciality"></param>
        public void AddDiscipline(string name, string hours, string semester, string speciality)
        {
            string comstr1 = "SELECT * FROM `speciality` " +
                "WHERE name = '" + speciality + "'";
            MySqlCommand com1 = new MySqlCommand(comstr1, myConnection);
            MySqlDataReader reader1 = com1.ExecuteReader();

            string idS = "";
            while (reader1.Read())
            {
                idS = reader1[0].ToString();
            }
            reader1.Close();

            string comStr2 =
                "INSERT INTO `department`.`discipline` (`name` ,`hours` ,`semester` ,`speciality`)" +
                "VALUES('" + name + "', '" + hours + "', '" + semester + "', '" + idS + "')";
            MySqlCommand com2 = new MySqlCommand(comStr2, myConnection);
            com2.ExecuteNonQuery();
        }

        /// <summary>
        /// Добавляет ведомость
        /// </summary>
        /// <param name="semester"></param>
        /// <param name="discipline"></param>
        /// <param name="group"></param>
        /// <param name="type"></param>
        /// <param name="teacher"></param>
        /// <param name="table"></param>
        public void InsertList(string semester, string discipline, string group, string type, string teacher, DataGrid table)
        {
            string comstr1 = "SELECT * FROM `discipline` WHERE name = '" + discipline + "' AND `semester` = '" + semester + "'";
            MySqlCommand com1 = new MySqlCommand(comstr1, myConnection);
            MySqlDataReader reader1 = com1.ExecuteReader();

            string idD = "";
            while (reader1.Read())
            {
                idD = reader1[0].ToString();
            }
            reader1.Close();

            string comstr2 = "SELECT * FROM `group` WHERE number = '" + group + "'";
            MySqlCommand com2 = new MySqlCommand(comstr2, myConnection);
            MySqlDataReader reader2 = com2.ExecuteReader();

            string idG = "";
            while (reader2.Read())
            {
                idG = reader2[0].ToString();
            }
            reader2.Close();

            string[] nameT = teacher.Split(' ');
            string comstr3 = "SELECT * FROM `teacher` WHERE (surname = '" + nameT[0] + "' AND name = '" + nameT[1] + "' AND middle_name = '" + nameT[2] + "')";
            MySqlCommand com3 = new MySqlCommand(comstr3, myConnection);
            MySqlDataReader reader3 = com3.ExecuteReader();

            string idT = "";
            while (reader3.Read())
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
        ~ClassList()
        {

        }
    }
    public class ClassTeacher : Connection, Operations, TeacherInterface
    {
        public ClassTeacher()
        {

        }

        /// <summary>
        /// Выводит список преподавателей
        /// </summary>
        /// <param name="table"></param>
        public void Show(DataGrid table)
        {
            string comStr = "SELECT * FROM teacher ORDER BY `surname`, `name`, `middle_name`";
            MySqlCommand com = new MySqlCommand(comStr, myConnection);
            MySqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                table.Items.Add(new columnTeacher() { surname = reader[1].ToString(), name = reader[2].ToString(), middle_name = reader[3].ToString(), rank = reader[4].ToString() });
            }
            reader.Close();
        }

        /// <summary>
        /// Выводит контакты преподавателей
        /// </summary>
        /// <param name="table"></param>
        public void ShowPers(DataGrid table)
        {
            string comStr = "SELECT a.surname, a.name, a.middle_name, b.series, b.number, b.sex, b.city, b.street, b.home, b.flat, b.phone_number " +
                "FROM `teacher` a " +
                "LEFT OUTER JOIN `pers_teacher` b ON b.id = a.id " +
                "ORDER BY a.surname, a.name, a.middle_name";
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

        /// <summary>
        /// Получает список преподавателей
        /// </summary>
        /// <returns></returns>
        public List<string> GetTeacher()
        {
            string comstr = "SELECT `surname`, `name`, `middle_name` FROM `teacher` ORDER BY `surname`, `name`, `middle_name`";
            MySqlCommand com = new MySqlCommand(comstr, myConnection);
            MySqlDataReader reader = com.ExecuteReader();

            List<string> teachers = new List<string>();
            while (reader.Read())
            {
                teachers.Add(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString());
            }
            reader.Close();

            return teachers;
        }

        /// <summary>
        /// Добавляет преподавателя
        /// </summary>
        /// <param name="series"></param>
        /// <param name="number"></param>
        /// <param name="sex"></param>
        /// <param name="city"></param>
        /// <param name="street"></param>
        /// <param name="home"></param>
        /// <param name="flat"></param>
        /// <param name="phone"></param>
        /// <param name="surname"></param>
        /// <param name="name"></param>
        /// <param name="middle_name"></param>
        /// <param name="rank"></param>
        /// <param name="table"></param>
        public void Insert(TextBox series, TextBox number, string sex, TextBox city, TextBox street, TextBox home, TextBox flat, TextBox phone, TextBox surname,
            TextBox name, TextBox middle_name, ComboBox rank)
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
        }

        /// <summary>
        /// Выводит список преподавателей с указанием ученого звания
        /// </summary>
        /// <param name="table"></param>
        /// <param name="rank"></param>
        public void ShowRank(DataGrid table, string rank)
        {
            string comstr1 = "SELECT * FROM teacher WHERE academic_rank = '" + rank + "' ORDER BY `surname`, `name`, `middle_name`";
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

        /// <summary>
        /// Выводит контакты преподавателей с указанием ученого звания
        /// </summary>
        /// <param name="table"></param>
        /// <param name="rank"></param>
        public void ShowPersRank(DataGrid table, string rank)
        {
            string comStr = "SELECT a.surname, a.name, a.middle_name, b.series, b.number, b.sex, b.city, b.street, b.home, b.flat, b.phone_number " +
                "FROM `teacher` a " +
                "LEFT OUTER JOIN `pers_teacher` b ON b.id = a.id " +
                "WHERE a.academic_rank = '" + rank + "' " +
                "ORDER BY a.surname, a.name, a.middle_name";
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
        ~ClassTeacher()
        {

        }
    }
    public class ClassStudent : Connection, Operations, StudentInterface
    {
        public ClassStudent()
        {

        }
        /// <summary>
        /// Выводит контакты студентов
        /// </summary>
        /// <param name="table"></param>
        public void ShowPers(DataGrid table)
        {
            string comStr = "SELECT a.surname, a.name, a.middle_name, b.series, b.number, b.sex, b.city, b.street, b.home, b.flat, b.phone_number " +
                "FROM `student` a " +
                "LEFT OUTER JOIN `pers_student` b ON b.id = a.id " +
                "ORDER BY a.surname, a.name, a.middle_name";
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

        /// <summary>
        /// Выводит список групп указанной специальности
        /// </summary>
        /// <param name="table"></param>
        /// <param name="spec"></param>
        public void ShowGroupSpec(DataGrid table, string spec)
        {
            string comStr = "SELECT g.number, s.name " +
                "FROM `group` g " +
                "LEFT OUTER JOIN `speciality` s ON s.id = g.speciality " +
                "WHERE s.name = '" + spec + "' " +
                "ORDER BY g.number";
            MySqlCommand com = new MySqlCommand(comStr, myConnection);
            MySqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                table.Items.Add(new columnGroup
                {
                    number = reader[0].ToString(),
                    spec = reader[1].ToString()
                });
            }
            reader.Close();
        }

        /// <summary>
        /// Получает список студентов указанной группы
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public List<string> GetStudents(string group)
        {
            string comStr1 = "SELECT `surname`, `name`, `middle_name` FROM `student` " +
                "WHERE `group` = (SELECT `id` FROM `group` WHERE `number` = '" + group + "') " +
                "ORDER BY `surname`, `name`, `middle_name`";

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

        /// <summary>
        /// Получает список групп
        /// </summary>
        /// <returns></returns>
        public List<string> GetGroup()
        {
            string comstr = "SELECT `number` FROM `group` ORDER BY `number`";
            MySqlCommand com = new MySqlCommand(comstr, myConnection);
            MySqlDataReader reader = com.ExecuteReader();

            List<string> groups = new List<string>();
            while (reader.Read())
            {
                groups.Add(reader[0].ToString());
            }
            reader.Close();

            return groups;
        }

        /// <summary>
        /// Выводит список студентов
        /// </summary>
        /// <param name="table"></param>
        public void Show(DataGrid table)
        {
            string comStr = "SELECT a.surname, a.name, a.middle_name, b.number, a.year " +
                "FROM `student` a " +
                "LEFT OUTER JOIN `group` b ON b.id = a.group " +
                "ORDER BY a.surname, a.name, a.middle_name";
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

        /// <summary>
        /// Добавляет группу
        /// </summary>
        /// <param name="number"></param>
        /// <param name="spec"></param>
        public void InsertGroup(string number, string spec)
        {
            string comStr1 = "SELECT count(*) FROM `group` WHERE `number` = '" + number + "'";
            MySqlCommand com1 = new MySqlCommand(comStr1, myConnection);
            object count = com1.ExecuteScalar();
            if (Convert.ToInt32(count) == 0)
            {
                string comStr = "INSERT INTO `department`.`group`(`number`, `speciality`) " +
                    "VALUES('" + number + "', (SELECT `id` FROM `speciality` WHERE `name` = '" + spec + "'))";
                MySqlCommand com = new MySqlCommand(comStr, myConnection);
                com.ExecuteNonQuery();
            }
            else MessageBox.Show("Такая группа уже есть!");
        }

        /// <summary>
        /// Добавляет студента
        /// </summary>
        /// <param name="series"></param>
        /// <param name="number"></param>
        /// <param name="sex"></param>
        /// <param name="city"></param>
        /// <param name="street"></param>
        /// <param name="numberH"></param>
        /// <param name="flat"></param>
        /// <param name="phone"></param>
        /// <param name="surname"></param>
        /// <param name="name"></param>
        /// <param name="middle_name"></param>
        /// <param name="group"></param>
        /// <param name="spec"></param>
        /// <param name="year"></param>
        /// <param name="table"></param>
        public void Insert(TextBox series, TextBox number, string sex, TextBox city, TextBox street, TextBox numberH, TextBox flat, TextBox phone,
            TextBox surname, TextBox name, TextBox middle_name, TextBox group, ComboBox spec, TextBox year, DataGrid table)
        {
            string comStr1 =
                "INSERT INTO `department`.`pers_student` (`series` ,`number` ,`sex` ,`city` ,`street` ,`home`, `flat`, `phone_number`) " +
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

            table.Items.Add(new columnStudent()
            {
                surname = surname.Text,
                name = name.Text,
                middle_name = middle_name.Text,
                group = group.Text,
                year = year.Text
            });
        }

        /// <summary>
        /// Показывает список указанной группы
        /// </summary>
        /// <param name="table">Таблица, куда помещается список</param>
        /// <param name="group">Номер группы</param>
        public void ShowGroup(DataGrid table, string group)
        {
            string comstr1 = "SELECT * FROM `group`";
            MySqlCommand com1 = new MySqlCommand(comstr1, myConnection);
            MySqlDataReader reader1 = com1.ExecuteReader();

            string idG = "";
            while (reader1.Read())
            {
                if (reader1[1].ToString() == group) idG = reader1[0].ToString();
            }
            reader1.Close();

            string comStr2 = "SELECT a.surname, a.name, a.middle_name, b.number, a.year " +
                "FROM `student` a " +
                "LEFT OUTER JOIN `group` b ON b.id = a.group " +
                "WHERE a.group = '" + idG + "' " +
                "ORDER BY a.surname, a.name, a.middle_name";
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

        /// <summary>
        /// Выводит таблицу групп
        /// </summary>
        /// <param name="table"></param>
        public void ShowGroups(DataGrid table)
        {
            string comStr = "SELECT g.number, s.name " +
                "FROM `group` g " +
                "LEFT OUTER JOIN `speciality` s ON s.id = g.speciality " +
                "ORDER BY g.number";
            MySqlCommand com = new MySqlCommand(comStr, myConnection);
            MySqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                table.Items.Add(new columnGroup
                {
                    number = reader[0].ToString(),
                    spec = reader[1].ToString()
                });
            }
            reader.Close();
        }

        /// <summary>
        /// Выводит таблицу контактов студентов указанной группы
        /// </summary>
        /// <param name="table"></param>
        /// <param name="group"></param>
        public void ShowPersGroup(DataGrid table, string group)
        {
            string comstr1 = "SELECT * FROM `group`";
            MySqlCommand com1 = new MySqlCommand(comstr1, myConnection);
            MySqlDataReader reader1 = com1.ExecuteReader();

            string idG = "";
            while (reader1.Read())
            {
                if (reader1[1].ToString() == group) idG = reader1[0].ToString();
            }
            reader1.Close();

            string comStr = "SELECT a.surname, a.name, a.middle_name, b.series, b.number, b.sex, b.city, b.street, b.home, b.flat, b.phone_number " +
            "FROM `student` a " +
            "LEFT OUTER JOIN `pers_student` b ON b.id = a.id " +
            "WHERE a.group = '" + idG + "' " +
            "ORDER BY a.surname, a.name, a.middle_name";
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
        ~ClassStudent()
        {

        }
    }
}