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
    public partial class VisitsForStudentsForm : Form
    {
        public VisitsForStudentsForm()
        {
            InitializeComponent();
            LoadDataInto();
        }
        private void CountMisses()
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT COUNT(посещение) AS пропуски FROM `посещения` INNER JOIN занятия ON занятия.номер_занятия = посещения.номер_занятия WHERE занятия.группа_id = @gid AND посещения.посещение = 0 AND занятия.семестр = @s AND занятия.дисциплина_план_id = @dpid AND посещения.`зачетная/табельный` = @zt", db.getConnection());
            command.Parameters.Add("@zt", MySqlDbType.VarChar).Value = StudentidcomboBox.Text;
            command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = GroupidcomboBox.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrcomboBox.Text;
            command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = DisciplineidcomboBox.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MissesofPersontextBox.Text = reader.GetString("пропуски");
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT COUNT(посещение) AS все FROM `посещения` INNER JOIN занятия ON занятия.номер_занятия = посещения.номер_занятия WHERE занятия.группа_id = @gid AND занятия.семестр = @s AND занятия.дисциплина_план_id = @dpid AND посещения.`зачетная/табельный` = @zt", db.getConnection());
            command.Parameters.Add("@zt", MySqlDbType.VarChar).Value = StudentidcomboBox.Text;
            command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = GroupidcomboBox.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrcomboBox.Text;
            command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = DisciplineidcomboBox.Text;
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                AllVisitsofStudenttextBox.Text = reader.GetString("все");
            }
            db.closeConnection();
        }
        private void LoadDataInto()
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT пользователи.фамилия, пользователи.имя, пользователи.отчество, пользователи.`зачетная/табельный` FROM `пользователи` INNER JOIN авторизация ON авторизация.`зачетная/табельный` = пользователи.`зачетная/табельный` WHERE пользователи.статус_пользователя='Студент' AND авторизация.логин = @l", db.getConnection());
            command.Parameters.Add("@l", MySqlDbType.VarChar).Value = DataCheck.L;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                StudentsComboBox.Items.Add(reader.GetString("фамилия") + " " + reader.GetString("имя") + " " + reader.GetString("отчество"));
                StudentidcomboBox.Items.Add(reader.GetString("зачетная/табельный"));
            }
            db.closeConnection();
            StudentsComboBox.SelectedIndex = 0;
        }
        private void StudentsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            StudentidcomboBox.SelectedIndex = StudentsComboBox.SelectedIndex;
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT имя_группы, группы.группа_id FROM группы INNER JOIN группаистудент ON группаистудент.группа_id = группы.группа_id WHERE группаистудент.`зачетная/табельный` = @zt", db.getConnection());
            command.Parameters.Add("@zt", MySqlDbType.VarChar).Value = StudentidcomboBox.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GroupComboBox.Items.Add(reader.GetString("имя_группы"));
                GroupidcomboBox.Items.Add(reader.GetString("группа_id"));
            }
            db.closeConnection();
            GroupComboBox.SelectedIndex = 0;
        }
        private void GroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupidcomboBox.SelectedIndex = GroupComboBox.SelectedIndex;
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT семестр FROM занятия WHERE группа_id = @gid GROUP BY семестр", db.getConnection());
            command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = GroupidcomboBox.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SemestrcomboBox.Items.Add(reader.GetString("семестр"));
            }
            db.closeConnection();
        }
        private void SemestrcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT дисциплины.наименование, учебныйплан.индекс, занятия.дисциплина_план_id FROM занятия INNER JOIN учебныйплан ON учебныйплан.дисциплина_план_id = занятия.дисциплина_план_id INNER JOIN дисциплины ON дисциплины.дисциплина_id = учебныйплан.дисциплина_id WHERE занятия.семестр = @s AND занятия.группа_id = @gid GROUP BY занятия.дисциплина_план_id", db.getConnection());
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = GroupidcomboBox.Text;
            command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = GroupidcomboBox.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DisciplinecomboBox.Items.Add(reader.GetString("наименование") + "/" + reader.GetString("индекс"));
                DisciplineidcomboBox.Items.Add(reader.GetString("дисциплина_план_id"));
            }
            db.closeConnection();
        }
        private void DisciplinecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisciplineidcomboBox.SelectedIndex = DisciplinecomboBox.SelectedIndex;
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT занятия.номер_пары AS 'Номер пары', занятия.дата_занятия AS 'Дата занятия', посещения.посещение AS Посещение, посещения.номер_посещения FROM посещения INNER JOIN пользователи ON пользователи.`зачетная/табельный` = посещения.`зачетная/табельный` INNER JOIN занятия ON занятия.номер_занятия = посещения.номер_занятия WHERE дисциплина_план_id = @dpid AND занятия.семестр = @s AND занятия.группа_id = @gid AND пользователи.`зачетная/табельный`=@zt", db.getConnection());
            command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = DisciplineidcomboBox.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrcomboBox.Text;
            command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = GroupidcomboBox.Text;
            command.Parameters.Add("@zt", MySqlDbType.VarChar).Value = StudentidcomboBox.Text;
            db.openConnection();
            MySqlDataReader read = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(read);
            VisitsAndProgressDataGridView.DataSource = dataTable;
            db.closeConnection();
            CountMisses();
            this.VisitsAndProgressDataGridView.Columns[3].Visible = false;
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
    }
}