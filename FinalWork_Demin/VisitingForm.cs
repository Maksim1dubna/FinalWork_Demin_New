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
    public partial class VisitingForm : Form
    {
        private void CountMisses()
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT COUNT(посещение) AS пропуски FROM `посещения` INNER JOIN занятия ON занятия.номер_занятия = посещения.номер_занятия WHERE занятия.группа_id = @gid AND посещения.посещение = 0 AND занятия.семестр = @s AND занятия.дисциплина_план_id = @dpid", db.getConnection());
            command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = GroupidcomboBox.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrcomboBox.Text;
            command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = DisciplineidcomboBox.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MissesofGrouptextBox.Text = reader.GetString("пропуски");
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT COUNT(посещение) AS все FROM `посещения` INNER JOIN занятия ON занятия.номер_занятия = посещения.номер_занятия WHERE занятия.группа_id = @gid AND занятия.семестр = @s AND занятия.дисциплина_план_id = @dpid", db.getConnection());
            command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = GroupidcomboBox.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrcomboBox.Text;
            command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = DisciplineidcomboBox.Text;
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                AllLessonsofGrouptextBox.Text = reader.GetString("все");
            }
        }
        public VisitingForm()
        {
            InitializeComponent();
            LoadDataInto();
        }
        private void LoadDataInto()
        {
            if (DataCheck.TypeOfUser != "Преподаватель")
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT группы.имя_группы, группы.группа_id FROM занятия INNER JOIN группы ON группы.группа_id = занятия.группа_id GROUP BY группы.группа_id", db.getConnection());
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GroupComboBox.Items.Add(reader.GetString("имя_группы"));
                    GroupidcomboBox.Items.Add(reader.GetString("группа_id"));
                }
                db.closeConnection();
                CountMisses();
            }
            else
            {
                
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT группы.имя_группы, группы.группа_id FROM занятия INNER JOIN группы ON группы.группа_id = занятия.группа_id INNER JOIN учебныйплан ON учебныйплан.группа_id = группы.группа_id INNER JOIN преподавательидисциплина ON преподавательидисциплина.дисциплина_план_id = учебныйплан.дисциплина_план_id INNER JOIN пользователи ON пользователи.`зачетная/табельный`= преподавательидисциплина.`зачетная/табельный` INNER JOIN авторизация ON авторизация.`зачетная/табельный`= пользователи.`зачетная/табельный` WHERE пользователи.статус_пользователя = 'Преподаватель' AND авторизация.логин = @l GROUP BY группы.группа_id", db.getConnection());
                command.Parameters.Add("@l", MySqlDbType.VarChar).Value = DataCheck.L;
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GroupComboBox.Items.Add(reader.GetString("имя_группы"));
                    GroupidcomboBox.Items.Add(reader.GetString("группа_id"));
                }
                db.closeConnection();
                CountMisses();
            }
        }
        private void GroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DataCheck.TypeOfUser != "Преподаватель")
            {
                SemestrcomboBox.Items.Clear();
                GroupidcomboBox.SelectedIndex = GroupComboBox.SelectedIndex;
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT семестр FROM занятия WHERE группа_id=@gid GROUP BY семестр", db.getConnection());
                command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = GroupidcomboBox.Text;
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SemestrcomboBox.Items.Add(reader.GetString("семестр"));
                }
                db.closeConnection();
            }
            else
            {
                SemestrcomboBox.Items.Clear();
                GroupidcomboBox.SelectedIndex = GroupComboBox.SelectedIndex;
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT семестр FROM занятия INNER JOIN группы ON группы.группа_id = занятия.группа_id INNER JOIN учебныйплан ON учебныйплан.группа_id = группы.группа_id INNER JOIN преподавательидисциплина ON преподавательидисциплина.дисциплина_план_id = учебныйплан.дисциплина_план_id INNER JOIN пользователи ON пользователи.`зачетная/табельный` = преподавательидисциплина.`зачетная/табельный` INNER JOIN авторизация ON авторизация.`зачетная/табельный` = пользователи.`зачетная/табельный` WHERE группы.группа_id = @gid AND пользователи.статус_пользователя = 'Преподаватель' AND авторизация.логин = @l GROUP BY занятия.семестр", db.getConnection());
                command.Parameters.Add("@l", MySqlDbType.VarChar).Value = DataCheck.L;
                command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = GroupidcomboBox.Text;
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SemestrcomboBox.Items.Add(reader.GetString("семестр"));
                }
                db.closeConnection();
            }
        }
        private void SemestrcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DataCheck.TypeOfUser != "Преподаватель")
            {
                DisciplineidcomboBox.Items.Clear();
                DisciplinecomboBox.Items.Clear();
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT дисциплины.наименование, учебныйплан.индекс, занятия.дисциплина_план_id FROM занятия INNER JOIN учебныйплан ON учебныйплан.дисциплина_план_id = занятия.дисциплина_план_id INNER JOIN дисциплины ON дисциплины.дисциплина_id = учебныйплан.дисциплина_id WHERE занятия.семестр = @s AND занятия.группа_id = @gid GROUP BY занятия.дисциплина_план_id", db.getConnection());
                command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = GroupidcomboBox.Text;
                command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrcomboBox.Text;
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DisciplinecomboBox.Items.Add(reader.GetString("наименование") + "/" + reader.GetString("индекс"));
                    DisciplineidcomboBox.Items.Add(reader.GetString("дисциплина_план_id"));
                }
                db.closeConnection();
            }
            else 
            {
                DisciplineidcomboBox.Items.Clear();
                DisciplinecomboBox.Items.Clear();
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT дисциплины.наименование, учебныйплан.индекс, занятия.дисциплина_план_id FROM занятия INNER JOIN учебныйплан ON учебныйплан.дисциплина_план_id = занятия.дисциплина_план_id INNER JOIN дисциплины ON дисциплины.дисциплина_id = учебныйплан.дисциплина_id INNER JOIN преподавательидисциплина ON преподавательидисциплина.дисциплина_план_id = учебныйплан.дисциплина_план_id INNER JOIN пользователи ON пользователи.`зачетная/табельный` = преподавательидисциплина.`зачетная/табельный` INNER JOIN авторизация ON авторизация.`зачетная/табельный` = пользователи.`зачетная/табельный` WHERE занятия.семестр = @s AND занятия.группа_id = @gid AND пользователи.статус_пользователя = 'Преподаватель' AND авторизация.логин = @l GROUP BY занятия.дисциплина_план_id", db.getConnection());
                command.Parameters.Add("@l", MySqlDbType.VarChar).Value = DataCheck.L;
                command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = GroupidcomboBox.Text;
                command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrcomboBox.Text;
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DisciplinecomboBox.Items.Add(reader.GetString("наименование") + "/" + reader.GetString("индекс"));
                    DisciplineidcomboBox.Items.Add(reader.GetString("дисциплина_план_id"));
                }
                db.closeConnection();
            }
        }
        private void DisciplinecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
                DateComboBox.Items.Clear();
                DisciplineidcomboBox.SelectedIndex = DisciplinecomboBox.SelectedIndex;
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT занятия.дата_занятия FROM занятия WHERE занятия.группа_id = @gid AND занятия.семестр = @s AND занятия.дисциплина_план_id = @dpid GROUP BY занятия.дата_занятия", db.getConnection());
                command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = GroupidcomboBox.Text;
                command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrcomboBox.Text;
                command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = DisciplineidcomboBox.Text;
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DateComboBox.Items.Add(reader.GetDateTime("дата_занятия").ToString("dd/MM/yyyy"));
                }
                db.closeConnection();
        }
        private void DateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            NumoflessoncomboBox.Items.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT занятия.номер_пары FROM занятия WHERE занятия.дата_занятия = @dol GROUP BY занятия.номер_пары", db.getConnection());
            //command.Parameters.Add("@dol", MySqlDbType.VarChar).Value = DateComboBox.Text;
            command.Parameters.AddWithValue("@dol", Convert.ToDateTime(DateComboBox.Text));
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                NumoflessoncomboBox.Items.Add(reader.GetString("номер_пары"));
            }
            db.closeConnection();
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void NavigationLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            NavigationForm navigationform = new NavigationForm();
            navigationform.Show();
        }

        private void NumoflessoncomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT посещения.`зачетная/табельный` AS '№ зачетной книжки', пользователи.фамилия AS Фамилия, пользователи.имя AS Имя, пользователи.Отчество AS Отчество, посещения.посещение AS Посещение, посещения.номер_посещения FROM посещения INNER JOIN пользователи ON пользователи.`зачетная/табельный`=посещения.`зачетная/табельный` INNER JOIN занятия ON занятия.номер_занятия = посещения.номер_занятия WHERE занятия.дата_занятия = @dol AND занятия.номер_пары = @nol AND дисциплина_план_id = @dpid AND занятия.семестр = @s AND занятия.группа_id = @gid", db.getConnection());
            command.Parameters.AddWithValue("@dol", Convert.ToDateTime(DateComboBox.Text));
            command.Parameters.Add("@nol", MySqlDbType.VarChar).Value = NumoflessoncomboBox.Text;
            command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = DisciplineidcomboBox.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrcomboBox.Text;
            command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = GroupidcomboBox.Text;
            db.openConnection();
            MySqlDataReader read = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(read);
            VisitsAndProgressDataGridView.DataSource = dataTable;
            db.closeConnection();
        }

        private void VisitsAndProgressDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (DataCheck.TypeOfUser == "Админ" || DataCheck.TypeOfUser == "Уч.часть" || DataCheck.TypeOfUser == "Преподаватель")
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("UPDATE `посещения` SET посещение=@vis  WHERE номер_посещения=@nov", db.getConnection());
                for (int i = 0; i < VisitsAndProgressDataGridView.Rows.Count; i++)
                {
                    command.Parameters.AddWithValue("@vis", Convert.ToBoolean(VisitsAndProgressDataGridView.Rows[i].Cells[4].Value));
                    command.Parameters.AddWithValue("@nov", Convert.ToString(VisitsAndProgressDataGridView.Rows[i].Cells[5].Value));
                    db.openConnection();
                    command.ExecuteNonQuery();
                    db.closeConnection();// Закрывать из-за нагрузки на базу данных
                    command.Parameters.Clear();
                }
                CountMisses();
            }
        }
    }
}