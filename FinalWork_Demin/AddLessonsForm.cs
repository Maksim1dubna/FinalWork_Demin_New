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
            if (InsertUpddatebutton1.Text == "Записать")
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
        private void OpenLectionslabel_Click(object sender, EventArgs e)
        {
            ListOfLessonsForm listoflessons = new ListOfLessonsForm();
            listoflessons.Show();
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
                idgroup = reader.GetInt16("группа_id");
            }
            db.closeConnection();
            command = new MySqlCommand("SET lc_time_names = 'ru_RU'; call pr1(@ds, @de, @sd, @gid, @dpid, @s,@tow,@typeofl,@timeofl,@toa, @doa, @cw, @doc); SET lc_time_names = 'en_US';", db.getConnection());
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
        }
        private void DisciplinescomboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DisciplineidcomboBox.SelectedIndex = DisciplinescomboBox.SelectedIndex;
        }

        private void LecturerscomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LectureridcomboBox.SelectedIndex = LecturerscomboBox.SelectedIndex;
        }

        private void InsertUpdatebutton_Click(object sender, EventArgs e)
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
    }
 }
