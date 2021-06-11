using Microsoft.Office.Interop.Word;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalWork_Demin
{
    public partial class AddLessonsForm : Form
    {
        public AddLessonsForm()
        {
            InitializeComponent();
            LoadDataIntoAddLessonsForm();

        }
        private void CountHours()
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT номер_занятия, дисциплина_план_id FROM занятия WHERE дисциплина_план_id = @dpid", db.getConnection());
            command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = IndexidcomboBox2.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            int minutes = 0;
            while (reader.Read())
            {
                minutes += 90;
            }
            db.closeConnection();
            int hours = minutes / 60;
            FinalHourstextBox.Text = hours.ToString();
            if (Convert.ToInt16(FinalHourstextBox.Text) == NeedHoursnumericUpDown.Value)
            {
                CheckHourslabel.Text = "Правильно";
                CheckHourslabel.ForeColor = System.Drawing.Color.Green;
            }
            if (hours > NeedHoursnumericUpDown.Value)
            {
                CheckHourslabel.Text = "Много";
                CheckHourslabel.ForeColor = System.Drawing.Color.Red;
            }
            if (hours < NeedHoursnumericUpDown.Value)
            {
                CheckHourslabel.Text = "Мало";
                CheckHourslabel.ForeColor = System.Drawing.Color.Pink;
            }
        }
            private void LoadDataIntoAddLessonsForm()
        {
            DisciplineComboBox.Items.Clear();
            GroupcomboBox.Items.Clear();
            DisciplinescomboBox.Items.Clear();
            LecturerscomboBox.Items.Clear();
            DisciplineidcomboBox.Items.Clear();
            LectureridcomboBox.Items.Clear();
            IndexcomboBox1.Items.Clear();
            IndexidcomboBox1.Items.Clear();
            IndexcomboBox2.Items.Clear();
            IndexidcomboBox2.Items.Clear();
            LecturerscomboBox.Items.Clear();
            LectureridcomboBox.Items.Clear();
            if (DataCheck.TypeOfUser != "Админ")
            {
                NavigationLabel.Enabled = false;
                NavigationLabel.Visible = false;
            }
            else
            {
                NavigationLabel.Enabled = true;
                NavigationLabel.Visible = true;
            }
            DayofweekcomboBox.SelectedIndex = 0;
            FormcomboBox.SelectedIndex = 0;
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `группы`", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GroupcomboBox.Items.Add(reader.GetString("имя_группы"));
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT * FROM `дисциплины`", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                DisciplineComboBox.Items.Add(reader.GetString("наименование"));
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT индекс, наименование, дисциплина_план_id FROM `учебныйплан` INNER JOIN дисциплины ON дисциплины.дисциплина_id = учебныйплан.дисциплина_id", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                IndexcomboBox1.Items.Add(reader.GetString("индекс"));
                IndexidcomboBox1.Items.Add(reader.GetString("дисциплина_план_id"));
                IndexcomboBox2.Items.Add(reader.GetString("индекс") + "/" + reader.GetString("наименование"));
                IndexidcomboBox2.Items.Add(reader.GetString("дисциплина_план_id"));
                DisciplinescomboBox.Items.Add(reader.GetString("индекс") + "/" + reader.GetString("наименование"));
                DisciplineidcomboBox.Items.Add(reader.GetString("дисциплина_план_id"));
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT * from `пользователи` WHERE статус_пользователя = 'Преподаватель'", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                LecturerscomboBox.Items.Add(reader.GetString("фамилия")+" "+ reader.GetString("имя") + " "+ reader.GetString("отчество"));
                LectureridcomboBox.Items.Add(reader.GetString("зачетная/табельный"));
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT группы.имя_группы, группы.группа_id FROM группы INNER JOIN учебныйплан ON учебныйплан.группа_id = группы.группа_id GROUP BY группы.группа_id", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                GroupPrintComboBox.Items.Add(reader.GetString("имя_группы"));
                GroupPrintidcomboBox.Items.Add(reader.GetString("группа_id"));
            }
            db.closeConnection();
            WeeknumcomboBox.SelectedIndex = 0;
            TypeoflectioncomboBox.SelectedIndex = 0;
            TimeoflectioncomboBox.SelectedIndex = 0;
            SemestrcomboBox.SelectedIndex = 0;
        }
        private void IndexcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            IndexidcomboBox1.SelectedIndex = IndexcomboBox1.SelectedIndex;
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT `учебныйплан`.`дисциплина_план_id`,`группы`.`имя_группы`, `группы`.`группа_id`, `дисциплины`.`наименование` FROM `учебныйплан` INNER JOIN `группы` ON `группы`.`группа_id`=`учебныйплан`.`группа_id` INNER JOIN `дисциплины` ON `дисциплины`.`дисциплина_id`=`учебныйплан`.`дисциплина_id`  WHERE `учебныйплан`.`дисциплина_план_id` = @dpid", db.getConnection());
            command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = IndexidcomboBox1.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TypeDatacheckBox1.Checked = true;
                TypeDatacheckBox1.Enabled = true;
                Deletebutton1.Visible = true;
                InsertUpddatebutton1.Text = "Обновить";
                CheckBoxTextlabel1.Text = "В базе данных как " + reader.GetString("дисциплина_план_id");
                int index = GroupcomboBox.Items.IndexOf(reader.GetString("имя_группы"));
                GroupcomboBox.SelectedIndex = index;
                index = DisciplineComboBox.Items.IndexOf(reader.GetString("наименование"));
                DisciplineComboBox.SelectedIndex = index;
            }
            db.closeConnection();
        }
        private void InsertUpddatebutton1_Click(object sender, EventArgs e)
        {
            if (InsertUpddatebutton1.Text == "Записать")  // проверка на запись или обновление
            {
                int iddiscipline = 0;
                int idgroup = 0;
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT `группа_id` FROM `группы` WHERE `имя_группы` = @nog;", db.getConnection());
                command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox.Text;
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    idgroup = reader.GetInt16("группа_id");
                }
                db.closeConnection();
                command = new MySqlCommand("SELECT `дисциплина_id` FROM `дисциплины` WHERE `наименование` = @nod", db.getConnection());
                command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplineComboBox.Text;
                db.openConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    iddiscipline = reader.GetInt16("дисциплина_id");
                }
                db.closeConnection();
                command = new MySqlCommand("INSERT INTO `учебныйплан` (`дисциплина_план_id`, `группа_id`, `индекс`, `дисциплина_id`) VALUES (NULL, @gid, @ind, @did);", db.getConnection());
                command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = idgroup;
                command.Parameters.Add("@ind", MySqlDbType.VarChar).Value = IndexcomboBox1.Text;
                command.Parameters.Add("@did", MySqlDbType.VarChar).Value = iddiscipline;
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();// Закрывать из-за нагрузки на базу данных
                LoadDataIntoAddLessonsForm();
            }
            else
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT `группа_id` FROM `группы` WHERE `имя_группы` = @nog;", db.getConnection());
                command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox.Text;
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                int idgroup = 0;
                while (reader.Read())
                {
                    idgroup = reader.GetInt32("группа_id");
                }
                db.closeConnection();
                command = new MySqlCommand("SELECT `дисциплина_id` FROM `дисциплины` WHERE `наименование` = @nod;", db.getConnection());
                command.Parameters.Add("@d", MySqlDbType.VarChar).Value = DisciplineComboBox.Text;
                db.openConnection();
                reader = command.ExecuteReader();
                int iddiscipline = 0;
                while (reader.Read())
                {
                    iddiscipline = reader.GetInt32("дисциплина_id");
                }
                db.closeConnection();
                command = new MySqlCommand("UPDATE `учебныйплан` SET `группа_id` = @gid, `индекс` = @ind, `дисциплина_id` = @did WHERE `специальность_id` = @sid", db.getConnection());
                command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = idgroup;
                command.Parameters.Add("@ind", MySqlDbType.VarChar).Value = IndexcomboBox1.Text;
                command.Parameters.Add("@did", MySqlDbType.VarChar).Value = iddiscipline;
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();// Закрывать из-за нагрузки на базу данных
                LoadDataIntoAddLessonsForm();
            }
        }
        private void Deletebutton1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("DELETE FROM `учебныйплан` WHERE `дисциплина_план_id` = @dpid", db.getConnection());
            command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = IndexidcomboBox1.Text;
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();// Закрывать из-за нагрузки на базу данных
            LoadDataIntoAddLessonsForm();
            Deletebutton1.Visible = true;
            IndexcomboBox1.Text = "";
            TypeDatacheckBox1.Checked = false;
            TypeDatacheckBox1.Enabled = false;
            LoadDataIntoAddLessonsForm();
        }
        private void TypeDatacheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (TypeDatacheckBox1.Checked == false)
            {
                TypeDatacheckBox1.Enabled = false;
                Deletebutton1.Visible = false;
                InsertUpddatebutton1.Text = "Записать";
                CheckBoxTextlabel1.Text = "Нет в базе";
            }
        }
        private void IndexcomboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            IndexidcomboBox2.SelectedIndex = IndexcomboBox2.SelectedIndex;
            CountHours();
        }
        private void NeedHoursnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            CountHours();
        }
        private void UpdateFormOfExam(string formofcontrol)
        {
            string formofcontolSet = "";
            switch (formofcontrol) // проверка на форму контроля 
            {
                case "экзамен":
                    formofcontolSet = "форма контроля-экзамен";
                    break;
                case "зачет":
                    formofcontolSet = "`форма контроля-зачет`";
                    break;
                case "зачет с оценкой":
                    formofcontolSet = "`форма контроля-зачет с оценкой`";
                    break;
                default:
                    MessageBox.Show("Ошибка");
                    return;
            }
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT дисциплина_план_id FROM аттестация WHERE форма_контроля = @foc GROUP BY дисциплина_план_id", db.getConnection());
            command.Parameters.Add("@foc", MySqlDbType.VarChar).Value = formofcontrol;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            List<int> ListDisciplinesPlan = new List<int>();
            List<int> ListSemesters = new List<int>();
            while (reader.Read())
            {
                ListDisciplinesPlan.Add(reader.GetInt32("дисциплина_план_id")); //запись листа дисциплин
            }
            db.closeConnection();
            for (int i = 0; i < ListDisciplinesPlan.Count; i++) // цикл для записи семестров в столбцы формы контроля в таблицу учебныйплан для
            {
                command = new MySqlCommand("SELECT семестр FROM аттестация WHERE форма_контроля = @foc AND дисциплина_план_id = @dpid GROUP BY семестр", db.getConnection());
                command.Parameters.Add("@foc", MySqlDbType.VarChar).Value = formofcontrol;
                command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = ListDisciplinesPlan[i];
                db.openConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ListSemesters.Add(reader.GetInt32("семестр"));
                }
                db.closeConnection();
                var semesters = String.Join("", ListSemesters.ToArray());
                if (formofcontrol == "экзамен")
                    command = new MySqlCommand("UPDATE учебныйплан SET `форма контроля-экзамен` = @fe WHERE дисциплина_план_id = @dpid", db.getConnection());
                if (formofcontrol == "зачет")
                    command = new MySqlCommand("UPDATE учебныйплан SET `форма контроля-зачет` = @fe WHERE дисциплина_план_id = @dpid", db.getConnection());
                if (formofcontrol == "зачет с оценкой")
                    command = new MySqlCommand("UPDATE учебныйплан SET `форма контроля-зачет с оценкой` = @fe WHERE дисциплина_план_id = @dpid", db.getConnection());
                command.Parameters.Add("@fe", MySqlDbType.VarChar).Value = semesters;
                command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = ListDisciplinesPlan[i];
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();// Закрывать из-за нагрузки на базу данных
                ListSemesters.Clear();
            }
            ListDisciplinesPlan.Clear();
            ListSemesters.Clear();
            command = new MySqlCommand("SELECT дисциплина_план_id FROM аттестация WHERE курсовая_работа = 1 GROUP BY дисциплина_план_id", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListDisciplinesPlan.Add(reader.GetInt32("дисциплина_план_id"));
            }
            db.closeConnection();
            for (int i = 0; i < ListDisciplinesPlan.Count; i++) // в данном цикле проиходит проверка и запись семестров в столбец форма контроля-КР
            {
                command = new MySqlCommand("SELECT семестр FROM аттестация WHERE дисциплина_план_id = @dpid AND курсовая_работа = 1 GROUP BY семестр", db.getConnection());
                command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = ListDisciplinesPlan[i];
                db.openConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ListSemesters.Add(reader.GetInt32("семестр"));
                }
                db.closeConnection();
                var semesters = String.Join("", ListSemesters.ToArray());
                command = new MySqlCommand("UPDATE учебныйплан SET `форма контроля-КР` = @fe WHERE дисциплина_план_id = @dpid", db.getConnection());
                command.Parameters.Add("@fe", MySqlDbType.VarChar).Value = semesters;
                command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = ListDisciplinesPlan[i];
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();// Закрывать из-за нагрузки на базу данных
                ListSemesters.Clear();
            }

            ListDisciplinesPlan.Clear();
            ListSemesters.Clear();
            command = new MySqlCommand("SELECT дисциплина_план_id FROM занятия GROUP BY дисциплина_план_id", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListDisciplinesPlan.Add(reader.GetInt32("дисциплина_план_id"));
            }
            db.closeConnection();
            for (int i = 0; i < ListDisciplinesPlan.Count; i++) // в данном цикле просчитывется итоговое кол-во часов за все семестры по данной дисциплине
            {
                command = new MySqlCommand("SELECT номер_занятия, дисциплина_план_id FROM занятия WHERE дисциплина_план_id = @dpid", db.getConnection());
                command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = ListDisciplinesPlan[i];
                db.openConnection();
                reader = command.ExecuteReader();
                int minutes = 0;
                while (reader.Read())
                {
                    minutes += 90;
                }
                db.closeConnection();
                int hours = minutes / 60;
                command = new MySqlCommand("UPDATE учебныйплан SET `итого часов-по плану` = @hp WHERE дисциплина_план_id = @dpid", db.getConnection());
                command.Parameters.Add("@hp", MySqlDbType.VarChar).Value = hours;
                command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = ListDisciplinesPlan[i];
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
            }
        }
        private void UpdateFormOfExamSemestrs() // данная функция взаимодействует с столбцами из таблицы учебный план: сем.1-курс 1-лек, сем.1-курс 1-пр, сем.2-курс 1-лек, сем.2-курс 1-пр, сем.3-курс 2-лек, сем.3-курс 2-пр, сем.4-курс 2-лек, сем.4-курс 2-пр, сем.5-курс 3-лек, сем.5-курс 3-пр, сем.6-курс 3-лек, сем.6-курс 3-пр, сем.7-курс 4-лек, сем.7-курс 4-пр, сем.8-курс 4-лек, сем.8-курс 4-пр, сем.9-курс 5-лек, сем.9-курс 5-пр
        {
            List<int> ListDisciplinesPlan = new List<int>();
            List<int> ListSemesters = new List<int>();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT дисциплина_план_id FROM занятия GROUP BY дисциплина_план_id", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListDisciplinesPlan.Add(reader.GetInt32("дисциплина_план_id")); // запись всех дисциплин по учебному планукоторые существуют в таблице занятия
            }
            db.closeConnection();
            for (int i = 0; i < ListDisciplinesPlan.Count; i++) // данный цикл проходит все существующие дисциплины с помощью листа
            {
                command = new MySqlCommand("SELECT семестр FROM занятия WHERE дисциплина_план_id = @dpid GROUP BY семестр", db.getConnection());
                command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = ListDisciplinesPlan[i];
                db.openConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ListSemesters.Add(reader.GetInt32("семестр"));
                }
                db.closeConnection();
                command = new MySqlCommand("SELECT семестр FROM занятия WHERE дисциплина_план_id = @dpid GROUP BY семестр", db.getConnection());
                command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = ListDisciplinesPlan[i];
                db.openConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ListSemesters.Add(reader.GetInt32("семестр"));
                }
                db.closeConnection();
                for (int i1 = 0; i1 < ListSemesters.Count; i1++) // цикл проходит все семестры у дисциплины из таблицы занятия
                {
                    int minutesLect = 0;
                    int minutesPractice = 0;
                    switch (ListSemesters[i1].ToString())
                    {
                        case "1":
                            command = new MySqlCommand("SELECT форма_занятия FROM занятия WHERE дисциплина_план_id = @dpid AND семестр = 1", db.getConnection());
                            break;
                        case "2":
                            command = new MySqlCommand("SELECT форма_занятия FROM занятия WHERE дисциплина_план_id = @dpid AND семестр = 2", db.getConnection());
                            break;
                        case "3":
                            command = new MySqlCommand("SELECT форма_занятия FROM занятия WHERE дисциплина_план_id = @dpid AND семестр = 3", db.getConnection());
                            break;
                        case "4":
                            command = new MySqlCommand("SELECT форма_занятия FROM занятия WHERE дисциплина_план_id = @dpid AND семестр = 4", db.getConnection());
                            break;
                        case "5":
                            command = new MySqlCommand("SELECT форма_занятия FROM занятия WHERE дисциплина_план_id = @dpid AND семестр = 5", db.getConnection());
                            break;
                        case "6":
                            command = new MySqlCommand("SELECT форма_занятия FROM занятия WHERE дисциплина_план_id = @dpid AND семестр = 6", db.getConnection());
                            break;
                        case "7":
                            command = new MySqlCommand("SELECT форма_занятия FROM занятия WHERE дисциплина_план_id = @dpid AND семестр = 7", db.getConnection());
                            break;
                        case "8":
                            command = new MySqlCommand("SELECT форма_занятия FROM занятия WHERE дисциплина_план_id = @dpid AND семестр = 8", db.getConnection());
                            break;
                        case "9":
                            command = new MySqlCommand("SELECT форма_занятия FROM занятия WHERE дисциплина_план_id = @dpid AND семестр = 9", db.getConnection());
                            break;
                        default:
                            MessageBox.Show("Ошибка");
                            return;
                    }
                    command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = ListDisciplinesPlan[i];
                    db.openConnection();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetString("форма_занятия") == "Лекция")
                            minutesLect += 90;
                        if (reader.GetString("форма_занятия") == "Семинар")
                            minutesPractice += 90;
                    }
                    db.closeConnection();
                    minutesLect = minutesLect / 60;
                    minutesPractice = minutesPractice / 60;
                    switch (ListSemesters[i1].ToString())
                    {
                        case "1":
                            command = new MySqlCommand("UPDATE учебныйплан SET `сем.1-курс 1-лек` = @sl WHERE дисциплина_план_id = @dpid", db.getConnection());
                            break;
                        case "2":
                            command = new MySqlCommand("UPDATE учебныйплан SET `сем.2-курс 1-лек` = @sl WHERE дисциплина_план_id = @dpid", db.getConnection());
                            break;
                        case "3":
                            command = new MySqlCommand("UPDATE учебныйплан SET `сем.3-курс 2-лек` = @sl WHERE дисциплина_план_id = @dpid", db.getConnection());
                            break;
                        case "4":
                            command = new MySqlCommand("UPDATE учебныйплан SET `сем.4-курс 2-лек` = @sl WHERE дисциплина_план_id = @dpid", db.getConnection());
                            break;
                        case "5":
                            command = new MySqlCommand("UPDATE учебныйплан SET `сем.5-курс 3-лек` = @sl WHERE дисциплина_план_id = @dpid", db.getConnection());
                            break;
                        case "6":
                            command = new MySqlCommand("UPDATE учебныйплан SET `сем.6-курс 3-лек` = @sl WHERE дисциплина_план_id = @dpid", db.getConnection());
                            break;
                        case "7":
                            command = new MySqlCommand("UPDATE учебныйплан SET `сем.7-курс 4-лек` = @sl WHERE дисциплина_план_id = @dpid", db.getConnection());
                            break;
                        case "8":
                            command = new MySqlCommand("UPDATE учебныйплан SET `сем.8-курс 4-лек` = @sl WHERE дисциплина_план_id = @dpid", db.getConnection());
                            break;
                        case "9":
                            command = new MySqlCommand("UPDATE учебныйплан SET `сем.9-курс 5-лек` = @sl WHERE дисциплина_план_id = @dpid", db.getConnection());
                            break;
                        default:
                            MessageBox.Show("Ошибка");
                            return;
                    }
                    if (minutesLect == 0)
                        command.Parameters.Add("@sl", MySqlDbType.VarChar).IsNullable = true;
                    else
                        command.Parameters.Add("@sl", MySqlDbType.VarChar).Value = minutesLect;
                    command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = ListDisciplinesPlan[i];
                    db.openConnection();
                    command.ExecuteNonQuery();
                    db.closeConnection();

                    switch (ListSemesters[i1].ToString())
                    {
                        case "1":
                            command = new MySqlCommand("UPDATE учебныйплан SET `сем.1-курс 1-пр` = @sp WHERE дисциплина_план_id = @dpid", db.getConnection());
                            break;
                        case "2":
                            command = new MySqlCommand("UPDATE учебныйплан SET `сем.2-курс 1-пр` = @sp WHERE дисциплина_план_id = @dpid", db.getConnection());
                            break;
                        case "3":
                            command = new MySqlCommand("UPDATE учебныйплан SET `сем.3-курс 2-пр` = @sp WHERE дисциплина_план_id = @dpid", db.getConnection());
                            break;
                        case "4":
                            command = new MySqlCommand("UPDATE учебныйплан SET `сем.4-курс 2-пр` = @sp WHERE дисциплина_план_id = @dpid", db.getConnection());
                            break;
                        case "5":
                            command = new MySqlCommand("UPDATE учебныйплан SET `сем.5-курс 3-пр` = @sp WHERE дисциплина_план_id = @dpid", db.getConnection());
                            break;
                        case "6":
                            command = new MySqlCommand("UPDATE учебныйплан SET `сем.6-курс 3-пр` = @sp WHERE дисциплина_план_id = @dpid", db.getConnection());
                            break;
                        case "7":
                            command = new MySqlCommand("UPDATE учебныйплан SET `сем.7-курс 4-пр` = @sp WHERE дисциплина_план_id = @dpid", db.getConnection());
                            break;
                        case "8":
                            command = new MySqlCommand("UPDATE учебныйплан SET `сем.8-курс 4-пр` = @sp WHERE дисциплина_план_id = @dpid", db.getConnection());
                            break;
                        case "9":
                            command = new MySqlCommand("UPDATE учебныйплан SET `сем.9-курс 5-пр` = @sp WHERE дисциплина_план_id = @dpid", db.getConnection());
                            break;
                        default:
                            MessageBox.Show("Ошибка");
                            return;
                    }
                    if (minutesPractice == 0)
                        command.Parameters.Add("@sp", MySqlDbType.VarChar).IsNullable = true;
                    else
                        command.Parameters.Add("@sp", MySqlDbType.VarChar).Value = minutesPractice;
                    command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = ListDisciplinesPlan[i];
                    db.openConnection();
                    command.ExecuteNonQuery();
                    db.closeConnection();
                    command = new MySqlCommand("UPDATE учебныйплан SET `форма контроля-экзамен` = null, `форма контроля-зачет` = null, `форма контроля-зачет с оценкой` = null, `форма контроля-КР` = null, `итого часов-по плану` = null, `сем.1-курс 1-лек` = null, `сем.1-курс 1-пр` = null, `сем.2-курс 1-лек` = null, `сем.2-курс 1-пр` = null, `сем.3-курс 2-лек` = null, `сем.3-курс 2-пр` = null, `сем.4-курс 2-лек` = null, `сем.4-курс 2-пр` = null, `сем.5-курс 3-лек` = null, `сем.5-курс 3-пр`= null, `сем.6-курс 3-лек` = null, `сем.6-курс 3-пр`= null, `сем.7-курс 4-лек` = null, `сем.7-курс 4-пр` = null, `сем.8-курс 4-лек` = null, `сем.8-курс 4-пр` = null, `сем.9-курс 5-лек` = null, `сем.9-курс 5-пр`= null WHERE `форма контроля-экзамен` = 0 AND `форма контроля-зачет` = 0 AND `форма контроля-зачет с оценкой` = 0 AND `форма контроля-КР` = 0 AND `итого часов-по плану` = 0 AND `сем.1-курс 1-лек` = 0 AND `сем.1-курс 1-пр` = 0 AND `сем.2-курс 1-лек` = 0 AND `сем.2-курс 1-пр` = 0 AND `сем.3-курс 2-лек` = 0 AND `сем.3-курс 2-пр` = 0 AND `сем.4-курс 2-лек` = 0 AND `сем.4-курс 2-пр` = 0 AND `сем.5-курс 3-лек` = 0 AND `сем.5-курс 3-пр`= 0 AND `сем.6-курс 3-лек` = 0 AND `сем.6-курс 3-пр`= 0 AND `сем.7-курс 4-лек` = 0 AND `сем.7-курс 4-пр` = 0 AND `сем.8-курс 4-лек` = 0 AND `сем.8-курс 4-пр` = 0 AND `сем.9-курс 5-лек` = 0 AND `сем.9-курс 5-пр`= 0", db.getConnection());
                    db.openConnection();
                    command.ExecuteNonQuery();
                    db.closeConnection();
                }

                ListSemesters.Clear();
            }
        }
        private void Updatebutton_Click(object sender, EventArgs e)
        {
            UpdateFormOfExam("экзамен");
            UpdateFormOfExam("зачет");
            UpdateFormOfExam("зачет с оценкой");
            UpdateFormOfExamSemestrs();
        }

        private void Numoflectionlabel_Click(object sender, EventArgs e)
        {

        }

        private void CourseWorkcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CourseWorkcheckBox.Checked == true)
            {
                Courseworklabel.Enabled = true;
                Courseworklabel.Visible = true;
                CourseworkdateTimePicker.Enabled = true;
                CourseworkdateTimePicker.Visible = true;
            }
            else 
            {
                Courseworklabel.Enabled = false;
                Courseworklabel.Visible = false;
                CourseworkdateTimePicker.Enabled = false;
                CourseworkdateTimePicker.Visible = false;
            }
        }

        private void InsertDataButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT группа_id FROM `учебныйплан` WHERE дисциплина_план_id = @dpid", db.getConnection());
            command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = IndexidcomboBox2.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            int idgroup = 0;
            while (reader.Read())
            {
                idgroup = reader.GetInt16("группа_id"); // заранее записываем id группы
            }
            db.closeConnection();
            command = new MySqlCommand("SET lc_time_names = 'ru_RU'; call pr1(@ds, @de, @sd, @gid, @dpid, @s,@tow,@typeofl,@timeofl,@toa, @doa, @cw, @doc); SET lc_time_names = 'en_US';", db.getConnection()); // используем хранимую процедуру где записываются входные переменные
            command.Parameters.AddWithValue("@ds", Convert.ToDateTime(DateofStartdateTimePicker.Value));
            command.Parameters.AddWithValue("@de", Convert.ToDateTime(DateOfEnddateTimePicker.Value));
            switch (DayofweekcomboBox.Text)
            {
                case "пн":
                    command.Parameters.Add("@sd", MySqlDbType.VarChar).Value = "Понедельник";
                    break;
                case "вт":
                    command.Parameters.Add("@sd", MySqlDbType.VarChar).Value = "Вторник";
                    break;
                case "ср":
                    command.Parameters.Add("@sd", MySqlDbType.VarChar).Value = "Среда";
                    break;
                case "чт":
                    command.Parameters.Add("@sd", MySqlDbType.VarChar).Value = "Четверг";
                    break;
                case "пт":
                    command.Parameters.Add("@sd", MySqlDbType.VarChar).Value = "Пятница";
                    break;
                case "сб":
                    command.Parameters.Add("@sd", MySqlDbType.VarChar).Value = "Суббота";
                    break;
                case "вс":
                    command.Parameters.Add("@sd", MySqlDbType.VarChar).Value = "Воскресенье";
                    break;
                default:
                    Console.WriteLine("unkonwn");
                    break;
            }
            command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = idgroup;
            command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = IndexidcomboBox2.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrcomboBox.Text;
            command.Parameters.AddWithValue("@tow", Convert.ToString(WeeknumcomboBox.Text));
            command.Parameters.Add("@typeofl", MySqlDbType.VarChar).Value = TypeoflectioncomboBox.Text;
            command.Parameters.Add("@timeofl", MySqlDbType.VarChar).Value = TimeoflectioncomboBox.Text;
            command.Parameters.Add("@toa", MySqlDbType.VarChar).Value = FormcomboBox.Text;
            command.Parameters.AddWithValue("@doa", Convert.ToDateTime(ExamCreditTimePicker.Value));
            if(CourseWorkcheckBox.Checked == true)
                command.Parameters.Add("@cw", MySqlDbType.VarChar).Value = 1;
            else
                command.Parameters.Add("@cw", MySqlDbType.VarChar).Value = 0;
            command.Parameters.AddWithValue("@doc", Convert.ToDateTime(CourseworkdateTimePicker.Value));
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();// Закрывать из-за нагрузки на базу данных
            CountHours(); // подсчет часов после записи в таблицу занятия
        }
        private void DisciplinescomboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DisciplineidcomboBox.SelectedIndex = DisciplinescomboBox.SelectedIndex;
        }

        private void LecturerscomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LectureridcomboBox.SelectedIndex = LecturerscomboBox.SelectedIndex;
        }

        private void InsertUpdatebutton_Click(object sender, EventArgs e) // За
        {
            DisciplineslistBox.Items.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO преподавательидисциплина( `зачетная/табельный`, дисциплина_план_id ) VALUES( @zt, @dpid );", db.getConnection());
            command.Parameters.Add("@zt", MySqlDbType.VarChar).Value = LectureridcomboBox.Text;
            command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = DisciplineidcomboBox.Text;
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();// Закрывать из-за нагрузки на базу данных
            command = new MySqlCommand("SELECT дисциплины.наименование, учебныйплан.индекс, преподавательидисциплина.дисциплина_план_id FROM `преподавательидисциплина` INNER JOIN учебныйплан ON учебныйплан.дисциплина_план_id = преподавательидисциплина.дисциплина_план_id INNER JOIN дисциплины ON дисциплины.дисциплина_id = учебныйплан.дисциплина_id WHERE преподавательидисциплина.`зачетная/табельный` = @zt", db.getConnection());
            command.Parameters.Add("@zt", MySqlDbType.VarChar).Value = LectureridcomboBox.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DisciplineslistBox.Items.Add(reader.GetString("наименование") + "/" + reader.GetString("индекс") + "/" + reader.GetString("дисциплина_план_id"));
            }
            db.closeConnection();
        }

        private void LectureridcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisciplineslistBox.Items.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT дисциплины.наименование, учебныйплан.индекс, преподавательидисциплина.дисциплина_план_id FROM `преподавательидисциплина` INNER JOIN учебныйплан ON учебныйплан.дисциплина_план_id = преподавательидисциплина.дисциплина_план_id INNER JOIN дисциплины ON дисциплины.дисциплина_id = учебныйплан.дисциплина_id WHERE преподавательидисциплина.`зачетная/табельный` = @zt", db.getConnection());
            command.Parameters.Add("@zt", MySqlDbType.VarChar).Value = LectureridcomboBox.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DisciplineslistBox.Items.Add(reader.GetString("наименование") + "/" + reader.GetString("индекс") + "/" + reader.GetString("дисциплина_план_id"));
            }
            db.closeConnection();
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            string[] DisciplineslistString = DisciplineslistBox.Text.Split('/');
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("DELETE FROM преподавательидисциплина WHERE дисциплина_план_id = @dpid AND `зачетная/табельный` = @zt", db.getConnection());
            command.Parameters.Add("@zt", MySqlDbType.VarChar).Value = LectureridcomboBox.Text;
            command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = DisciplineslistString[2];
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();// Закрывать из-за нагрузки на базу данных
            DisciplineslistBox.Items.RemoveAt(DisciplineslistBox.SelectedIndex);
        }
        private void GroupPrintComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupPrintidcomboBox.SelectedIndex = GroupPrintComboBox.SelectedIndex; 
        }
        private void AddLessonsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void NavigationLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            NavigationForm navigationform = new NavigationForm();
            navigationform.Show();
        }
        private void PrintStudyplanbutton_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application(); // Начало работы с приложением Word
            Document doc = app.Documents.Add(Visible: true);
            Range newRange = doc.Range();
            newRange.InsertBreak(WdBreakType.wdSectionBreakNextPage);
            doc.Sections.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT индекс, дисциплины.наименование, `форма контроля-экзамен`, `форма контроля-зачет`, `форма контроля-зачет с оценкой`, `форма контроля-КР`, `итого часов-по плану`, `сем.1-курс 1-лек`, `сем.1-курс 1-пр`, `сем.2-курс 1-лек`, `сем.2-курс 1-пр`, `сем.3-курс 2-лек`, `сем.3-курс 2-пр`, `сем.4-курс 2-лек`, `сем.4-курс 2-пр`, `сем.5-курс 3-лек`, `сем.5-курс 3-пр`, `сем.6-курс 3-лек`, `сем.6-курс 3-пр`, `сем.7-курс 4-лек`, `сем.7-курс 4-пр`, `сем.8-курс 4-лек`, `сем.8-курс 4-пр`, `сем.9-курс 5-лек`, `сем.9-курс 5-пр` FROM учебныйплан INNER JOIN дисциплины ON дисциплины.дисциплина_id = учебныйплан.дисциплина_id WHERE группа_id = @gid", db.getConnection());
            command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = GroupPrintidcomboBox.Text;
            db.openConnection();
            System.Data.DataTable table = new System.Data.DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            MySqlDataReader reader = command.ExecuteReader();
            int c = table.Rows.Count;
            object start = doc.Sentences[1].Start, end = doc.Sentences[1].Start;
            Range r = doc.Range(ref start, ref end);
            Table t = r.Tables.Add(r, c+1, 25);
            t.AllowAutoFit = true;
            t.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);
            t.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
            t.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
            t.Range.ParagraphFormat.SpaceBefore = 0;
            t.Range.ParagraphFormat.SpaceAfter = 0;
            t.Range.ParagraphFormat.LineSpacingRule = (WdLineSpacing)0.5;
            t.Range.Font.Size = 6;
            t.Range.Font.Name = "Times New Roman";
            int i = 2;
            while (reader.Read())
            {
                t.Cell(1, 1).Range.Text = reader.GetName(0); // GetNAme получает имя столбца из базы данных SQL
                t.Cell(1, 2).Range.Text = reader.GetName(1);
                t.Cell(1, 3).Range.Text = reader.GetName(2);
                t.Cell(1, 4).Range.Text = reader.GetName(3);
                t.Cell(1, 5).Range.Text = reader.GetName(4);
                t.Cell(1, 6).Range.Text = reader.GetName(5);
                t.Cell(1, 7).Range.Text = reader.GetName(6);
                t.Cell(1, 8).Range.Text = reader.GetName(7);
                t.Cell(1, 9).Range.Text = reader.GetName(8);
                t.Cell(1, 10).Range.Text = reader.GetName(9);
                t.Cell(1, 11).Range.Text = reader.GetName(10);
                t.Cell(1, 12).Range.Text = reader.GetName(11);
                t.Cell(1, 13).Range.Text = reader.GetName(12);
                t.Cell(1, 14).Range.Text = reader.GetName(13);
                t.Cell(1, 15).Range.Text = reader.GetName(14);
                t.Cell(1, 16).Range.Text = reader.GetName(15);
                t.Cell(1, 17).Range.Text = reader.GetName(16);
                t.Cell(1, 18).Range.Text = reader.GetName(17);
                t.Cell(1, 19).Range.Text = reader.GetName(18);
                t.Cell(1, 20).Range.Text = reader.GetName(19);
                t.Cell(1, 21).Range.Text = reader.GetName(20);
                t.Cell(1, 22).Range.Text = reader.GetName(21);
                t.Cell(1, 23).Range.Text = reader.GetName(22);
                t.Cell(1, 24).Range.Text = reader.GetName(23);
                t.Cell(1, 25).Range.Text = reader.GetName(24);
                t.Cell(1, 25).Range.Text = reader.GetName(24);
                t.Cell(i, 1).Range.Text = reader.IsDBNull(0) ? "" : reader.GetString("индекс");
                t.Cell(i, 2).Range.Text = reader.IsDBNull(1) ? "" : reader.GetString("наименование");
                t.Cell(i, 3).Range.Text = reader.IsDBNull(2) ? "" : reader.GetString("форма контроля-экзамен");
                t.Cell(i, 4).Range.Text = reader.IsDBNull(3) ? "" : reader.GetString("форма контроля-зачет");
                t.Cell(i, 5).Range.Text = reader.IsDBNull(4) ? "" : reader.GetString("форма контроля-зачет с оценкой");
                t.Cell(i, 6).Range.Text = reader.IsDBNull(5) ? "" : reader.GetString("форма контроля-КР");
                t.Cell(i, 7).Range.Text = reader.IsDBNull(6) ? "" : reader.GetString("итого часов-по плану");
                t.Cell(i, 8).Range.Text = reader.IsDBNull(7) ? "" : reader.GetString("сем.1-курс 1-лек");
                t.Cell(i, 9).Range.Text = reader.IsDBNull(8) ? "" : reader.GetString("сем.1-курс 1-пр");
                t.Cell(i, 10).Range.Text = reader.IsDBNull(9) ? "" : reader.GetString("сем.2-курс 1-лек");
                t.Cell(i, 11).Range.Text = reader.IsDBNull(10) ? "" : reader.GetString("сем.2-курс 1-пр");
                t.Cell(i, 12).Range.Text = reader.IsDBNull(11) ? "" : reader.GetString("сем.3-курс 2-лек");
                t.Cell(i, 13).Range.Text = reader.IsDBNull(12) ? "" : reader.GetString("сем.3-курс 2-лек");
                t.Cell(i, 14).Range.Text = reader.IsDBNull(13) ? "" : reader.GetString("сем.4-курс 2-лек");
                t.Cell(i, 15).Range.Text = reader.IsDBNull(14) ? "" : reader.GetString("сем.4-курс 2-лек");
                t.Cell(i, 16).Range.Text = reader.IsDBNull(15) ? "" : reader.GetString("сем.5-курс 3-лек");
                t.Cell(i, 17).Range.Text = reader.IsDBNull(16) ? "" : reader.GetString("сем.5-курс 3-лек");
                t.Cell(i, 18).Range.Text = reader.IsDBNull(17) ? "" : reader.GetString("сем.6-курс 3-лек");
                t.Cell(i, 19).Range.Text = reader.IsDBNull(18) ? "" : reader.GetString("сем.6-курс 3-лек");
                t.Cell(i, 20).Range.Text = reader.IsDBNull(19) ? "" : reader.GetString("сем.7-курс 4-лек");
                t.Cell(i, 21).Range.Text = reader.IsDBNull(20) ? "" : reader.GetString("сем.7-курс 4-лек");
                t.Cell(i, 22).Range.Text = reader.IsDBNull(21) ? "" : reader.GetString("сем.8-курс 4-лек");
                t.Cell(i, 23).Range.Text = reader.IsDBNull(22) ? "" : reader.GetString("сем.8-курс 4-лек");
                t.Cell(i, 24).Range.Text = reader.IsDBNull(23) ? "" : reader.GetString("сем.9-курс 9-лек");
                t.Cell(i, 25).Range.Text = reader.IsDBNull(24) ? "" : reader.GetString("сем.9-курс 9-лек");
                i=+2;
            }
            db.closeConnection();
            doc.Save();
            doc.Close();
            app.Quit();
        }

    }
 }

