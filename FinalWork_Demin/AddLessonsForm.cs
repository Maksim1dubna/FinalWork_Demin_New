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
        private void LoadDataIntoAddLessonsForm()
        {
            DisciplineComboBox.Items.Clear();
            GroupcomboBox.Items.Clear();
            DisciplinescomboBox.Items.Clear();
            LecturerscomboBox.Items.Clear();
            DisciplineidcomboBox.Items.Clear();
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
            TypeOfMarkcomboBox.SelectedIndex = 0;
            SemestrComboBox.SelectedIndex = 0;
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM groups", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GroupcomboBox.Items.Add(reader.GetString("nameofgroup") + "/" + reader.GetString("group_id"));
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT * FROM disciplines", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                DisciplineComboBox.Items.Add(reader.GetString("nameofdiscipline") + "/" + reader.GetString("discipline_id"));
                DisciplinescomboBox.Items.Add(reader.GetString("nameofdiscipline"));
                DisciplineidcomboBox.Items.Add(reader.GetString("discipline_id"));
            }
            db.closeConnection();
            GroupcomboBox.SelectedIndex = 0;
            command = new MySqlCommand("SELECT * FROM lecturers", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                LecturerscomboBox.Items.Add(reader.GetString("secondname") + " " + reader.GetString("firstname") + " " + reader.GetString("thirdname"));
                LectureridcomboBox.Items.Add(reader.GetString("lecturer_id"));
            }
            db.closeConnection();
            GroupcomboBox.SelectedIndex = 0;
            WeeknumcomboBox.SelectedIndex = 0;
            TypeoflectioncomboBox.SelectedIndex = 0;
            TimeoflectioncomboBox.SelectedIndex = 0;
        }
        private void ExamcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ExamcheckBox.Checked == true)
            {
                ExamCreditlabel.Text = "Дата Экзамена";
                TypeOfMarkLabel.Visible = false;
                TypeOfMarkcomboBox.Visible = false;
            }
            if (ExamcheckBox.Checked == false)
            {
                ExamCreditlabel.Text = "Дата Зачета";
                TypeOfMarkLabel.Visible = true;
                TypeOfMarkcomboBox.Visible = true;
            }
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

        private void LecturerscomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisciplineslistBox.Items.Clear();
            string[] FIO = LecturerscomboBox.Text.Split(' ');
            LectureridcomboBox.SelectedIndex = LecturerscomboBox.SelectedIndex;
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM lecturers WHERE secondname = @sn AND firstname = @fn AND thirdname = @tn AND lecturer_id = @lid", db.getConnection());
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = FIO[1];
            command.Parameters.Add("@sn", MySqlDbType.VarChar).Value = FIO[0];
            command.Parameters.Add("@tn", MySqlDbType.VarChar).Value = FIO[2];
            command.Parameters.Add("@lid", MySqlDbType.VarChar).Value = LectureridcomboBox.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                PositiontextBox.Text = reader.GetString("position");
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT disciplines.nameofdiscipline, lecturersanddisciplines.main FROM disciplines INNER JOIN lecturersanddisciplines ON lecturersanddisciplines.discipline_id = disciplines.discipline_id INNER JOIN lecturers ON lecturers.lecturer_id = lecturersanddisciplines.lecturer_id WHERE lecturers.lecturer_id = @lid", db.getConnection());
            command.Parameters.Add("@lid", MySqlDbType.VarChar).Value = LectureridcomboBox.Text;
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                int main = reader.GetInt16("main");
                if (main == 1)
                    DisciplineslistBox.Items.Add(reader.GetString("nameofdiscipline") + "/ОСНОВНОЙ");
                else
                    DisciplineslistBox.Items.Add(reader.GetString("nameofdiscipline"));
            }
            db.closeConnection();
        }

        private void DisciplinescomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisciplineidcomboBox.SelectedIndex = DisciplinescomboBox.SelectedIndex;
            TypeDatacheckBox.Checked = true;
            TypeDatacheckBox.Enabled = true;
            Deletebutton.Visible = true;
            InsertUpdatebutton.Text = "Обновить";
            CheckBoxTextlabel.Text = "Cуществует в базе данных как " + DisciplineidcomboBox.Text;
        }

        private void TypeDatacheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TypeDatacheckBox.Checked == false)
            {
                TypeDatacheckBox.Enabled = false;
                Deletebutton.Visible = false;
                InsertUpdatebutton.Text = "Записать";
                CheckBoxTextlabel.Text = "Не существует в базе данных";
                DisciplineslistBox.Items.Clear();
            }
        }

        private void InsertUpdatebutton_Click(object sender, EventArgs e)
        {
            if (InsertUpdatebutton.Text == "Записать")
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT * FROM disciplines WHERE nameofdiscipline = @nod", db.getConnection());
                command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinescomboBox.Text;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                System.Data.DataTable table = new System.Data.DataTable();
                adapter.SelectCommand = command;
                adapter.Fill(table);
                int id = 0;
                /*MySqlCommand command = new MySqlCommand("INSERT INTO disciplines(discipline_id, nameofdiscipline) VALUES(NULL, @nod);" +
                                      "INSERT INTO lecturersanddisciplines (lecturer_id, discipline_id, main, numofrelation) VALUES(@lid, @did, @m, NULL); ", db.getConnection());*/
                command.Parameters.Clear();
                if (table.Rows.Count > 0)
                {
                    command = new MySqlCommand("INSERT INTO lecturersanddisciplines (lecturer_id, discipline_id, main, numofrelation) VALUES(@lid, @did, @m, NULL);", db.getConnection());
                    command.Parameters.Add("@lid", MySqlDbType.VarChar).Value = LectureridcomboBox.Text;
                    command.Parameters.Add("@did", MySqlDbType.VarChar).Value = DisciplineidcomboBox.Text;
                    if (MaincheckBox.Checked == true)
                        command.Parameters.Add("@m", MySqlDbType.VarChar).Value = 1;
                    if (MaincheckBox.Checked == false)
                        command.Parameters.Add("@m", MySqlDbType.VarChar).Value = 0;
                    db.openConnection();
                    command.ExecuteNonQuery();
                    db.closeConnection();// Закрывать из-за нагрузки на базу данных
                    LoadDataIntoAddLessonsForm();
                }
                else 
                {
                    command = new MySqlCommand("INSERT INTO disciplines(discipline_id, nameofdiscipline) VALUES(NULL, @nod);", db.getConnection());
                    command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinescomboBox.Text;
                    db.openConnection();
                    command.ExecuteNonQuery();
                    db.closeConnection();// Закрывать из-за нагрузки на базу данных
                    command = new MySqlCommand("SELECT * FROM disciplines WHERE nameofdiscipline = @nod", db.getConnection());
                    command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinescomboBox.Text;
                    db.openConnection();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        id = reader.GetInt16("discipline_id");
                    }
                    db.closeConnection();
                    command = new MySqlCommand("INSERT INTO lecturersanddisciplines (lecturer_id, discipline_id, main, numofrelation) VALUES(@lid, @did, @m, NULL);", db.getConnection());
                    command.Parameters.Add("@lid", MySqlDbType.VarChar).Value = LectureridcomboBox.Text;
                    command.Parameters.Add("@did", MySqlDbType.VarChar).Value = id;
                    if(MaincheckBox.Checked == true)
                        command.Parameters.Add("@m", MySqlDbType.VarChar).Value = 1;
                    if (MaincheckBox.Checked == false)
                        command.Parameters.Add("@m", MySqlDbType.VarChar).Value = 0;
                    db.openConnection();
                    command.ExecuteNonQuery();
                    db.closeConnection();// Закрывать из-за нагрузки на базу данных
                }
                
            }
            else
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("UPDATE disciplines SET nameofdiscipline = @nod WHERE discipline_id = @did; " +
                    "UPDATE lecturersanddisciplines SET lecturer_id = @lid, main = @m WHERE discipline_id = @did;", db.getConnection());
                command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinescomboBox.Text;
                command.Parameters.Add("@did", MySqlDbType.VarChar).Value = DisciplineidcomboBox.Text;
                command.Parameters.Add("@lid", MySqlDbType.VarChar).Value = LectureridcomboBox.Text;
                if (MaincheckBox.Checked == true)
                    command.Parameters.Add("@m", MySqlDbType.VarChar).Value = 1;
                else
                    command.Parameters.Add("@m", MySqlDbType.VarChar).Value = 0;
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();// Закрывать из-за нагрузки на базу данных
            }
        }
        private void Deletebutton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("DELETE FROM `lecturersanddisciplines` WHERE `lecturersanddisciplines`.`discipline_id` = @did;DELETE FROM `disciplines` WHERE `disciplines`.`discipline_id` = @did;", db.getConnection());
            command.Parameters.Add("@did", MySqlDbType.VarChar).Value = DisciplineidcomboBox.Text;
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();// Закрывать из-за нагрузки на базу данных
            LoadDataIntoAddLessonsForm();
        }
        private void InsertDataButton_Click(object sender, EventArgs e)
        {
            string[] GroupString = GroupcomboBox.Text.Split('/');
            string[] DisciplineString = DisciplineComboBox.Text.Split('/');
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM lecturersanddisciplines INNER JOIN disciplines ON disciplines.discipline_id = lecturersanddisciplines.discipline_id WHERE main = 1 AND disciplines.nameofdiscipline = @nod", db.getConnection());
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplineString[0];
            db.openConnection();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("У преподавателя нету предмета");
                return;
            }
            db.closeConnection();
            command = new MySqlCommand("SET lc_time_names = 'ru_RU'; call pr1(@ds, @de, @sd, @gid, @did, @s,@toe,@tom,@doe,@tow,@typeofl,@timeofl); SET lc_time_names = 'en_US';", db.getConnection());
            command.Parameters.AddWithValue("@ds", Convert.ToDateTime(DateofStartdateTimePicker.Value));
            command.Parameters.AddWithValue("@de", Convert.ToDateTime(DateOfEnddateTimePicker.Value));
            command.Parameters.AddWithValue("@tow", Convert.ToString(WeeknumcomboBox.Text));
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
            command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = GroupString[1];
            command.Parameters.Add("@did", MySqlDbType.VarChar).Value = DisciplineString[1];
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrComboBox.Text;
            if (ExamcheckBox.Checked == true)
            {
                command.Parameters.Add("@toe", MySqlDbType.VarChar).Value = "Экзамен";
                command.Parameters.Add("@tom", MySqlDbType.VarChar).Value = "оценка";
            }
            else
            {
                command.Parameters.Add("@toe", MySqlDbType.VarChar).Value = "Зачет";
                command.Parameters.Add("@tom", MySqlDbType.VarChar).Value = TypeOfMarkcomboBox.Text;
            }
            command.Parameters.AddWithValue("@doe", Convert.ToDateTime(ExamCreditTimePicker.Value));
            command.Parameters.Add("@typeofl", MySqlDbType.VarChar).Value = TypeoflectioncomboBox.Text;
            command.Parameters.Add("@timeofl", MySqlDbType.VarChar).Value = TimeoflectioncomboBox.Text;
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();// Закрывать из-за нагрузки на базу данных
        }
        private void OpenLectionslabel_Click(object sender, EventArgs e)
        {
            ListOfLessonsForm listoflessons = new ListOfLessonsForm();
            listoflessons.Show();
        }
    }
 }
