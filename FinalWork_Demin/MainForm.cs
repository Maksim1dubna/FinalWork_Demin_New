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
        public VisitingForm()
        {
            InitializeComponent();
            LoadDataInto();
        }
        private void CountMisses()
        {
            string[] StudentString = StudentsComboBox.Text.Split(' ');
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT COUNT(visit) AS visit FROM visits INNER JOIN lections ON lections.numoflesson = visits.numoflesson INNER JOIN groups ON groups.group_id = lections.group_id INNER JOIN disciplines ON disciplines.discipline_id = lections.discipline_id WHERE groups.nameofgroup = @nog AND visits.visit = 0 AND lections.semestr = @s AND disciplines.nameofdiscipline = @nod", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupComboBox.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrcomboBox.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MissesofGrouptextBox.Text = reader.GetString("visit");
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT COUNT(visit) AS visit FROM visits INNER JOIN lections ON lections.numoflesson = visits.numoflesson INNER JOIN groups ON groups.group_id = lections.group_id INNER JOIN disciplines ON disciplines.discipline_id = lections.discipline_id WHERE groups.nameofgroup = @nog AND visits.visit = 0 AND lections.semestr = @s AND disciplines.nameofdiscipline = @nod AND visits.student_id = @sid", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupComboBox.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrcomboBox.Text;
            command.Parameters.Add("@sid", MySqlDbType.VarChar).Value = StudentString[4];
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                MissesofPersontextBox.Text = reader.GetString("visit");
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT COUNT(visit) AS visit FROM visits INNER JOIN lections ON lections.numoflesson = visits.numoflesson INNER JOIN groups ON groups.group_id = lections.group_id INNER JOIN disciplines ON disciplines.discipline_id = lections.discipline_id WHERE groups.nameofgroup = @nog AND lections.semestr = @s AND disciplines.nameofdiscipline = @nod", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupComboBox.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrcomboBox.Text;
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                AllLessonsofGrouptextBox.Text = reader.GetString("visit");
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT COUNT(visit) AS visit FROM visits INNER JOIN lections ON lections.numoflesson = visits.numoflesson INNER JOIN groups ON groups.group_id = lections.group_id INNER JOIN disciplines ON disciplines.discipline_id = lections.discipline_id WHERE groups.nameofgroup = @nog AND lections.semestr = @s AND disciplines.nameofdiscipline = @nod AND visits.student_id = @sid", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupComboBox.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrcomboBox.Text;
            command.Parameters.Add("@sid", MySqlDbType.VarChar).Value = StudentString[4];
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                AllVisitsofStudenttextBox.Text = reader.GetString("visit");
            }
        }
        private void LoadDataInto()
        {
            if (DataCheck.TypeOfUser == "Преподаватель")
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT groups.nameofgroup FROM groups INNER JOIN lections ON lections.group_id = groups.group_id INNER JOIN lecturersanddisciplines ON lecturersanddisciplines.discipline_id = lections.discipline_id INNER JOIN lecturers ON lecturers.lecturer_id = lecturersanddisciplines.lecturer_id WHERE lecturers.login = @l GROUP BY nameofgroup; ", db.getConnection());
                command.Parameters.Add("@l", MySqlDbType.VarChar).Value = DataCheck.L;
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GroupComboBox.Items.Add(reader.GetString("nameofgroup"));
                }
                db.closeConnection();
                TypeOfUserlabel.Text = DataCheck.TypeOfUser;
                GroupComboBox.SelectedIndex = 0;
            }
            if (DataCheck.TypeOfUser == "Админ" || DataCheck.TypeOfUser == "Уч.часть" )
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT groups.nameofgroup FROM groups INNER JOIN lections ON lections.group_id = groups.group_id GROUP BY nameofgroup;", db.getConnection());
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GroupComboBox.Items.Add(reader.GetString("nameofgroup"));
                }
                db.closeConnection();
                TypeOfUserlabel.Text = DataCheck.TypeOfUser;
                GroupComboBox.SelectedIndex = 0;
            }
            this.VisitsAndProgressDataGridView.Columns[0].Visible = false;
            this.VisitsAndProgressDataGridView.Columns[1].Visible = false;
            this.VisitsAndProgressDataGridView.Columns[2].Visible = false;
            this.VisitsAndProgressDataGridView.Columns[5].Visible = false;
        }
        private void VisitsAndProgressDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (DataCheck.TypeOfUser == "Админ" || DataCheck.TypeOfUser == "Уч.часть"  || DataCheck.TypeOfUser == "Преподаватель")
            {
                string[] StudentString = StudentsComboBox.Text.Split(' ');
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("UPDATE `visits` SET visit=@vis  WHERE numofvisit=@nov", db.getConnection());
                for (int i = 0; i < VisitsAndProgressDataGridView.Rows.Count; i++)
                {
                    command.Parameters.AddWithValue("@vis", Convert.ToBoolean(VisitsAndProgressDataGridView.Rows[i].Cells[3].Value));
                    command.Parameters.AddWithValue("@nov", Convert.ToString(VisitsAndProgressDataGridView.Rows[i].Cells[5].Value));
                    db.openConnection();
                    command.ExecuteNonQuery();
                    db.closeConnection();// Закрывать из-за нагрузки на базу данных
                    command.Parameters.Clear();
                }
                CountMisses();
            }
        }
        private void GroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SemestrcomboBox.Items.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT semestr FROM lections INNER JOIN groups ON groups.group_id=lections.group_id WHERE groups.nameofgroup = @nog GROUP BY semestr", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupComboBox.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SemestrcomboBox.Items.Add(reader.GetString("semestr"));
            }
            db.closeConnection();
            SemestrcomboBox.SelectedIndex = 0;
            CountMisses();
        }

        private void SemestrcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisciplinecomboBox.Items.Clear();
            StudentsComboBox.Items.Clear();
            if (DataCheck.TypeOfUser == "Преподаватель")
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT disciplines.nameofdiscipline FROM disciplines INNER JOIN lections ON lections.discipline_id = disciplines.discipline_id INNER JOIN lecturersanddisciplines ON lecturersanddisciplines.discipline_id = lections.discipline_id INNER JOIN lecturers ON lecturers.lecturer_id = lecturersanddisciplines.lecturer_id INNER JOIN groups ON groups.group_id = lections.group_id WHERE groups.nameofgroup = @nog AND lecturers.login = @l and lections.semestr=@s GROUP BY disciplines.discipline_id", db.getConnection());
                command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupComboBox.Text;
                command.Parameters.Add("@l", MySqlDbType.VarChar).Value = DataCheck.L;
                command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrcomboBox.Text;
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DisciplinecomboBox.Items.Add(reader.GetString("nameofdiscipline"));
                }
                db.closeConnection();
                command = new MySqlCommand("SELECT secondname, firstname, thirdname, student_id FROM students INNER JOIN groups ON groups.group_id = students.group_id WHERE groups.nameofgroup = @nog GROUP BY students.student_id ORDER BY secondname;", db.getConnection());
                command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupComboBox.Text;
                command.Parameters.Add("@l", MySqlDbType.VarChar).Value = DataCheck.L;
                db.openConnection();
                int i = 1;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    StudentsComboBox.Items.Add(i + " " + reader.GetString("secondname") + " " + reader.GetString("firstname") + " " + reader.GetString("thirdname") + " " + reader.GetString("student_id"));
                    i++;
                }
                db.closeConnection();
            }
            if (DataCheck.TypeOfUser == "Админ" || DataCheck.TypeOfUser == "Уч.часть" )
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT disciplines.nameofdiscipline FROM disciplines INNER JOIN lections ON lections.discipline_id = disciplines.discipline_id INNER JOIN groups ON groups.group_id = lections.group_id WHERE groups.nameofgroup = @nog and  lections.semestr=@s GROUP BY disciplines.discipline_id", db.getConnection());
                command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupComboBox.Text;
                command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrcomboBox.Text;
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DisciplinecomboBox.Items.Add(reader.GetString("nameofdiscipline"));
                }
                db.closeConnection();
                command = new MySqlCommand("SELECT secondname, firstname, thirdname, student_id FROM students INNER JOIN groups ON groups.group_id = students.group_id WHERE groups.nameofgroup = @nog GROUP BY students.student_id ORDER BY secondname;", db.getConnection());
                command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupComboBox.Text;
                db.openConnection();
                int i = 1;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    StudentsComboBox.Items.Add(i + " " + reader.GetString("secondname") + " " + reader.GetString("firstname") + " " + reader.GetString("thirdname") + " " + reader.GetString("student_id"));
                    i++;
                }
                db.closeConnection();
            }
            if (StudentsComboBox.Items.Count > 0 && DisciplinecomboBox.Items.Count > 0)
            {
                StudentsComboBox.SelectedIndex = 0;
                DisciplinecomboBox.SelectedIndex = 0;
            }
        }
        private void DisciplinecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] StudentString = StudentsComboBox.Text.Split(' ');
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT	students.secondname, students.firstname, students.thirdname, visits.visit AS Посещение, lections.dateoflection AS Дата, visits.numofvisit FROM visits INNER JOIN lections ON lections.numoflesson = visits.numoflesson INNER JOIN students ON students.student_id = visits.student_id INNER JOIN groups ON groups.group_id = lections.group_id INNER JOIN disciplines ON disciplines.discipline_id = lections.discipline_id WHERE groups.nameofgroup = @nog AND disciplines.nameofdiscipline = @nod AND students.student_id = @sid AND lections.semestr = @s", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupComboBox.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox.Text;
            command.Parameters.Add("@sid", MySqlDbType.VarChar).Value = StudentString[4];
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrcomboBox.Text;
            db.openConnection();
            MySqlDataReader read = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(read);
            VisitsAndProgressDataGridView.DataSource = dataTable;
            db.closeConnection();
            CountMisses();
        }

        private void StudentsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] StudentString = StudentsComboBox.Text.Split(' ');
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT	students.secondname, students.firstname, students.thirdname, visits.visit AS Посещение, lections.dateoflection AS Дата, visits.numofvisit FROM visits INNER JOIN lections ON lections.numoflesson = visits.numoflesson INNER JOIN students ON students.student_id = visits.student_id INNER JOIN groups ON groups.group_id = lections.group_id INNER JOIN disciplines ON disciplines.discipline_id = lections.discipline_id WHERE groups.nameofgroup = @nog AND disciplines.nameofdiscipline = @nod AND students.student_id = @sid AND lections.semestr = @s", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupComboBox.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox.Text;
            command.Parameters.Add("@sid", MySqlDbType.VarChar).Value = StudentString[4];
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrcomboBox.Text;
            db.openConnection();
            MySqlDataReader read = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(read);
            VisitsAndProgressDataGridView.DataSource = dataTable;
            db.closeConnection();
            CountMisses();
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