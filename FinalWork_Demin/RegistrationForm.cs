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
            this.Text = "Регистрация" + "(" + DataCheck.TypeOfUser + ")";
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
            MySqlCommand command = new MySqlCommand("SELECT * FROM группы", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GroupcomboBox.Items.Add(reader.GetString("имя_группы"));
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
                MySqlCommand command = new MySqlCommand("SELECT `группа_id` FROM `группы` WHERE `имя_группы` = @nog", db.getConnection());
                command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox.Text;
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                int idgroup = 0;
                while (reader.Read())
                {
                    idgroup = reader.GetInt32("группа_id");
                }
                db.closeConnection();
                command = new MySqlCommand("INSERT INTO `пользователи`( `зачетная/табельный`, `статус_пользователя`, `фамилия`, `имя`, `отчество`, `пол`, `дата_рождения` ) VALUES( @nt, @stat, @sn, @fn, @tn, @g, @dob );", db.getConnection());
                string[] FIO = FIOtextBox.Text.Split(' ');
                command.Parameters.Add("@nt", MySqlDbType.VarChar).Value = TabelnytextBox.Text;
                command.Parameters.Add("@stat", MySqlDbType.VarChar).Value = TypeofJobcomboBox.Text;
                command.Parameters.Add("@sn", MySqlDbType.VarChar).Value = FIO[0];
                command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = FIO[1];
                command.Parameters.Add("@tn", MySqlDbType.VarChar).Value = FIO[2];
                if (MaleradioButton.Checked == true)
                    command.Parameters.Add("@g", MySqlDbType.VarChar).Value = MaleradioButton.Text;
                if (FemaleradioButton.Checked == true)
                    command.Parameters.Add("@g", MySqlDbType.VarChar).Value = FemaleradioButton.Text;
                command.Parameters.Add("@dob", MySqlDbType.Date).Value = DateOfBorndateTimePicker.Value;
                db.openConnection();
                reader = command.ExecuteReader();
                int iduser = 0;
                while (reader.Read())
                {
                    iduser = reader.GetInt16("id");
                }
                MessageBox.Show(iduser.ToString());
                db.closeConnection();
                command = new MySqlCommand("INSERT INTO `авторизация`(`зачетная/табельный`, `логин`, `пароль`) VALUES( @nt, @l, @p);", db.getConnection());
                command.Parameters.Add("@nt", MySqlDbType.VarChar).Value = TabelnytextBox.Text; ;
                command.Parameters.Add("@l", MySqlDbType.VarChar).Value = RegistationLoginField.Text;
                command.Parameters.Add("@p", MySqlDbType.VarChar).Value = RegistationPassField.Text;
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
                command = new MySqlCommand("INSERT INTO `группаистудент`(`группа_id`, `зачетная/табельный`) VALUES( @gid, @nt);", db.getConnection());
                command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = idgroup;
                command.Parameters.Add("@nt", MySqlDbType.VarChar).Value = TabelnytextBox.Text;
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
            }
            else
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("INSERT INTO `пользователи`( `зачетная/табельный`, `статус_пользователя`, `фамилия`, `имя`, `отчество`, `пол`, `дата_рождения` ) VALUES( @nt, @stat, @sn, @fn, @tn, @g, @dob ); SELECT @@IDENTITY AS id;", db.getConnection());
                string[] FIO = FIOtextBox.Text.Split(' ');
                command.Parameters.Add("@nt", MySqlDbType.VarChar).Value = TabelnytextBox.Text;
                command.Parameters.Add("@stat", MySqlDbType.VarChar).Value = TypeofJobcomboBox.Text;
                command.Parameters.Add("@sn", MySqlDbType.VarChar).Value = FIO[0];
                command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = FIO[1];
                command.Parameters.Add("@tn", MySqlDbType.VarChar).Value = FIO[2];
                if (MaleradioButton.Checked == true)
                    command.Parameters.Add("@g", MySqlDbType.VarChar).Value = MaleradioButton.Text;
                if (FemaleradioButton.Checked == true)
                    command.Parameters.Add("@g", MySqlDbType.VarChar).Value = FemaleradioButton.Text;
                command.Parameters.Add("@dob", MySqlDbType.Date).Value = DateOfBorndateTimePicker.Value;
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                int iduser = 0;
                while (reader.Read())
                {
                    iduser = reader.GetInt16("id");
                }
                db.closeConnection();
                command = new MySqlCommand("INSERT INTO `авторизация`(`зачетная/табельный`, `логин`, `пароль`) VALUES( @nt, @l, @p);", db.getConnection());
                command.Parameters.Add("@nt", MySqlDbType.VarChar).Value = TabelnytextBox.Text;
                command.Parameters.Add("@l", MySqlDbType.VarChar).Value = RegistationLoginField.Text;
                command.Parameters.Add("@p", MySqlDbType.VarChar).Value = RegistationPassField.Text;
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
            }
        }

        public Boolean isUserExists()
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `авторизация` INNER JOIN `пользователи` ON `пользователи`.`зачетная/табельный`=`авторизация`.`зачетная/табельный` WHERE `логин` = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = RegistationLoginField.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
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
            }
            else
            {
                Grouplabel.Visible = false;
                GroupcomboBox.Visible = false;
            }
        }

        private void TypeofJobcomboBox_TextChanged(object sender, EventArgs e)
        {
            if (TypeofJobcomboBox.Text == "Студент")
            {
                Grouplabel.Visible = true;
                GroupcomboBox.Visible = true;
            }
            else
            {
                Grouplabel.Visible = false;
                GroupcomboBox.Visible = false;
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
