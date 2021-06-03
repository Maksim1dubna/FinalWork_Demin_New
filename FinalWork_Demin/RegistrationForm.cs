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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
            TypeofJobcomboBox.SelectedIndex = 0;
           
            RegistationLoginField.ForeColor = Color.Gray;
            RegistationPassField.ForeColor = Color.Gray;
            FIOtextBox.ForeColor = Color.Gray;
            RegistationLoginField.Text = "Введите имя пользователя";
            RegistationPassField.Text = "Введите пароль";
            FIOtextBox.Text = "Введите ФИО";
            LoadDataIntoAddLessonsForm();
        }
        private void LoadDataIntoAddLessonsForm()
        {
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
            if (DataCheck.TypeOfUser == "Админ" || DataCheck.TypeOfUser == "Уч.часть" )
            {
                NavigationLabel.Enabled = false;
                NavigationLabel.Visible = false;
            }    
            GroupcomboBox.Items.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM groups", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GroupcomboBox.Items.Add(reader.GetString("nameofgroup"));
            }
        }
        private void RegistationLoginField_Enter(object sender, EventArgs e)
        {
            if (RegistationLoginField.Text == "Введите имя пользователя")
            {
                RegistationLoginField.Text = "";
                RegistationLoginField.ForeColor = Color.Black;
            }
        }
        private void FIOtextBox_Enter(object sender, EventArgs e)
        {
            if (FIOtextBox.Text == "Введите ФИО")
            {
                FIOtextBox.Text = "";
                FIOtextBox.ForeColor = Color.Black;
            }
        }
        private void RegistationPassField_Enter(object sender, EventArgs e)
        {
            if (RegistationPassField.Text == "Введите пароль")
            {
                RegistationPassField.Text = "";
                RegistationPassField.ForeColor = Color.Black;
            }
        }
        private void RegistationLoginField_Leave(object sender, EventArgs e)
        {
            if (RegistationLoginField.Text == "")
            {
                RegistationLoginField.Text = "Введите имя пользователя";
                RegistationLoginField.ForeColor = Color.Gray;
            }
        }

        private void RegistationPassField_Leave(object sender, EventArgs e)
        {
            if (RegistationPassField.Text == "")
            {
                RegistationPassField.Text = "Введите пароль";
                RegistationPassField.ForeColor = Color.Gray;
            }
        }
        private void FIOtextBox_Leave(object sender, EventArgs e)
        {
            if (FIOtextBox.Text == "")
            {
                FIOtextBox.Text = "Введите ФИО";
                FIOtextBox.ForeColor = Color.Gray;
            }
        }

        private void buttonRegistation_Click(object sender, EventArgs e)
        {
            
            if (RegistationLoginField.Text == "Введите имя пользователя")
            {
                MessageBox.Show("Введите имя пользователя");
                return;
            }
            if (RegistationPassField.Text == "Введите пароль")
            {
                MessageBox.Show("Введите пароль");
                return;
            }
            if (FIOtextBox.Text == "Введите ФИО")
            {
                MessageBox.Show("Введите ФИО");
                return;
            }
            if (isUserExists())
                return;
            if (TypeofJobcomboBox.Text == "Студент")
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT group_id FROM groups WHERE nameofgroup = @nog", db.getConnection());
                command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox.Text;
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                int id = 0;
                while (reader.Read())
                {
                    id = reader.GetInt32("group_id");
                }
                db.closeConnection();
                command = new MySqlCommand("INSERT INTO `students` (`student_id`, `group_id`, `secondname`, `firstname`, `thirdname`, `gender`, `dateofborn`, `numberofticket`, " +
                    "`numberofzachetki`, `login`, `password`) VALUES (NULL, @gid, @sn, @fn, @tn, @gen, @d, @not, @noz, @uL, @p);select @@IDENTITY AS id;", db.getConnection());
                string[] FIO = FIOtextBox.Text.Split(' ');
                command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = id;
                command.Parameters.Add("@sn", MySqlDbType.VarChar).Value = FIO[0];
                command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = FIO[1];
                command.Parameters.Add("@tn", MySqlDbType.VarChar).Value = FIO[2];
                if (MaleradioButton.Checked == true)
                    command.Parameters.Add("@gen", MySqlDbType.VarChar).Value = MaleradioButton.Text;
                if (FemaleradioButton.Checked == true)
                    command.Parameters.Add("@gen", MySqlDbType.VarChar).Value = FemaleradioButton.Text;
                command.Parameters.Add("@d", MySqlDbType.Date).Value = DateOfBorndateTimePicker.Value;
                command.Parameters.Add("@not", MySqlDbType.VarChar).Value = TabelnytextBox.Text;
                command.Parameters.Add("@noz", MySqlDbType.VarChar).Value = TabelnytextBox.Text;
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = RegistationLoginField.Text;
                command.Parameters.Add("@p", MySqlDbType.VarChar).Value = RegistationPassField.Text;
                db.openConnection();
                reader = command.ExecuteReader();
                id = 0;
                while (reader.Read())
                {
                    id = reader.GetInt16("id");
                }
                db.closeConnection();
                //MessageBox.Show(id.ToString());
                command = new MySqlCommand("SELECT MAX(student_id) as student_id, visits.group_id FROM visits INNER JOIN groups ON groups.group_id = visits.group_id WHERE " +
                    "groups.nameofgroup = @nog GROUP BY group_id; ", db.getConnection());
                command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox.Text;
                db.openConnection();
                reader = command.ExecuteReader();
                int studentid = 0;
                while (reader.Read())
                {
                    studentid = reader.GetInt32("student_id");
                }
                db.closeConnection();
                //MessageBox.Show(id.ToString());
                command = new MySqlCommand("INSERT INTO visits (student_id, group_id,discipline_id, visit, dateoflection) SELECT REPLACE(student_id, student_id, @id) AS " +
                    "student_id,group_id,discipline_id,REPLACE(visit,1,0) AS visit,dateoflection FROM visits WHERE student_id = @sid ", db.getConnection());
                command.Parameters.Add("@sid", MySqlDbType.VarChar).Value = studentid;
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
                command = new MySqlCommand("SELECT MAX(student_id) AS student_id FROM exams INNER JOIN groups ON groups.group_id = exams.group_id WHERE groups.nameofgroup = @nog", db.getConnection());
                command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox.Text;
                db.openConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    studentid = reader.GetInt16("student_id");
                }
                db.closeConnection();
                command = new MySqlCommand("INSERT INTO exams( discipline_id, group_id, student_id, lecturer_id, examticket, semestr, TypeOfExam, TypeOfMark, Mark, dateofexam, dayofweek) SELECT discipline_id, groups.group_id, REPLACE (student_id, student_id, @id) AS student_id, lecturer_id, REPLACE (examticket, examticket, '-') AS examticket, semestr, TypeOfExam, TypeOfMark, REPLACE (Mark, Mark, '-') AS Mark, dateofexam, DAYOFWEEK FROM exams INNER JOIN groups ON groups.group_id = exams.group_id WHERE exams.student_id = @sid", db.getConnection());
                command.Parameters.Add("@sid", MySqlDbType.VarChar).Value = studentid;
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
                command = new MySqlCommand("SELECT MAX(student_id) AS student_id FROM courseworksdata INNER JOIN groups ON groups.group_id = courseworksdata.group_id WHERE groups.nameofgroup = @nog", db.getConnection());
                command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox.Text;
                db.openConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    studentid = reader.GetInt16("student_id");
                }
                db.closeConnection();
                MessageBox.Show(id.ToString());
                command = new MySqlCommand("INSERT INTO courseworksdata(coursework_id, discipline_id, group_id, student_id, semestr, Mark, theme) SELECT coursework_id, discipline_id, group_id, REPLACE (student_id, student_id, @id) AS student_id, semestr, REPLACE (Mark, Mark, '-') AS Mark, theme FROM courseworksdata WHERE courseworksdata.student_id = @sid", db.getConnection());
                command.Parameters.Add("@sid", MySqlDbType.VarChar).Value = studentid;
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
            }
            else
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("INSERT INTO `lecturers` (`lecturer_id`, `secondname`, `firstname`, `thirdname`, `position`, `gender`, `dateofborn`, `login`, `password`) VALUES (NULL, @sn, @fn, @tn, @pos, @gen, @d, @uL, @p)", db.getConnection());
                string[] FIO = FIOtextBox.Text.Split(' ');

                command.Parameters.Add("@sn", MySqlDbType.VarChar).Value = FIO[0];
                command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = FIO[1];
                command.Parameters.Add("@tn", MySqlDbType.VarChar).Value = FIO[2];
                command.Parameters.Add("@pos", MySqlDbType.VarChar).Value = TypeofJobcomboBox.Text;
                if (MaleradioButton.Checked == true)
                    command.Parameters.Add("@gen", MySqlDbType.VarChar).Value = MaleradioButton.Text;
                if (FemaleradioButton.Checked == true)
                    command.Parameters.Add("@gen", MySqlDbType.VarChar).Value = FemaleradioButton.Text;
                command.Parameters.Add("@d", MySqlDbType.Date).Value = DateOfBorndateTimePicker.Value;
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = RegistationLoginField.Text;
                command.Parameters.Add("@p", MySqlDbType.VarChar).Value = RegistationPassField.Text;
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();// Закрывать из-за нагрузки на базу данных
            }
        }

        public Boolean isUserExists()
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            if (TypeofJobcomboBox.Text == "Студент")
            {
                
                MySqlCommand command = new MySqlCommand("SELECT * FROM `students` WHERE `login` = @uL", db.getConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = RegistationLoginField.Text;

                adapter.SelectCommand = command;
                adapter.Fill(table);
            }
            else
            {

                MySqlCommand command = new MySqlCommand("SELECT * FROM `lecturers` WHERE `Login` = @uL", db.getConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = RegistationLoginField.Text;

                adapter.SelectCommand = command;
                adapter.Fill(table);
            }
            if (table.Rows.Count > 0)
                {
                    MessageBox.Show("Такой логин уже есть, введите другой");
                    return true;
                }
                else
                    return false;
        }          
        private void LoginLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm registrationForm = new LoginForm();
            registrationForm.Show();
            DataCheck.L = "";
            DataCheck.TypeOfUser = "";
        }

        private void TypeofJobcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TypeofJobcomboBox.Text == "Студент")
            {
                Grouplabel.Visible = true;
                GroupcomboBox.Visible = true;
                Ticketlabel.Visible = true;
                TabelnytextBox.Visible = true;
            }
            else
            {
                Grouplabel.Visible = false;
                GroupcomboBox.Visible = false;
                Ticketlabel.Visible = false;
                TabelnytextBox.Visible = false;
            }
        }

        private void TypeofJobcomboBox_TextChanged(object sender, EventArgs e)
        {
            if (TypeofJobcomboBox.Text == "Студент")
            {
                Grouplabel.Visible = true;
                GroupcomboBox.Visible = true;
                Ticketlabel.Visible = true;
                TabelnytextBox.Visible = true;
            }
            else
            {
                Grouplabel.Visible = false;
                GroupcomboBox.Visible = false;
                Ticketlabel.Visible = false;
                TabelnytextBox.Visible = false;
            }
        }
        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
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
