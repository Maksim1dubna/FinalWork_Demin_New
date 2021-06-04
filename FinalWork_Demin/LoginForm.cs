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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.PassField.AutoSize = false;
            this.PassField.Size = new Size(this.PassField.Size.Width, 64);
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (loginField.Text == "" || PassField.Text == "")
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }
            String loginUser = loginField.Text;
            String passUser = PassField.Text;
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            if(StudentradioButton.Checked == true)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM `авторизация` INNER JOIN пользователи ON `пользователи`.`зачетная/табельный`=`авторизация`.`зачетная/табельный` WHERE `логин` = @uL AND `пароль` = @uP AND `пользователи`.`статус_пользователя` = @tou", db.getConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
                command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;
                command.Parameters.Add("@tou", MySqlDbType.VarChar).Value = StudentradioButton.Text;
                db.openConnection();
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    DataCheck.TypeOfUser = StudentradioButton.Text;
                    DataCheck.L = loginField.Text;
                    this.Hide();
                    NavigationForm navigationForm = new NavigationForm();
                    navigationForm.Show();
                }
                else
                    MessageBox.Show("Empty");
                db.closeConnection();
            }
            if (LecturerradioButton.Checked == true)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM `авторизация` INNER JOIN пользователи ON `пользователи`.`зачетная/табельный`=`авторизация`.`зачетная/табельный` WHERE `логин` = @uL AND `пароль` = @uP AND `пользователи`.`статус_пользователя` = @tou", db.getConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
                command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;
                command.Parameters.Add("@tou", MySqlDbType.VarChar).Value = LecturerradioButton.Text;
                db.openConnection();
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    DataCheck.TypeOfUser = LecturerradioButton.Text;
                    DataCheck.L = loginField.Text;
                    this.Hide();
                    NavigationForm navigationForm = new NavigationForm();
                    navigationForm.Show();
                }
                else
                    MessageBox.Show("Empty");
                db.closeConnection();
            }
            if (AdminradioButton.Checked == true)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM `авторизация` INNER JOIN пользователи ON `пользователи`.`зачетная/табельный`=`авторизация`.`зачетная/табельный` WHERE `логин` = @uL AND `пароль` = @uP AND `пользователи`.`статус_пользователя` = @tou", db.getConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
                command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;
                command.Parameters.Add("@tou", MySqlDbType.VarChar).Value = AdminradioButton.Text;
                db.openConnection();
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    DataCheck.TypeOfUser = AdminradioButton.Text;
                    DataCheck.L = loginField.Text;
                    this.Hide();
                    NavigationForm navigationForm = new NavigationForm();
                    navigationForm.Show();
                }
                else
                    MessageBox.Show("Empty");
                db.closeConnection();
            }
            if (DirectorradioButton.Checked == true)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM `авторизация` INNER JOIN пользователи ON `пользователи`.`зачетная/табельный`=`авторизация`.`зачетная/табельный` WHERE `логин` = @uL AND `пароль` = @uP AND `пользователи`.`статус_пользователя` = @tou", db.getConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
                command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;
                command.Parameters.Add("@tou", MySqlDbType.VarChar).Value = DirectorradioButton.Text;
                db.openConnection();
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    DataCheck.TypeOfUser = AdminradioButton.Text;
                    DataCheck.L = loginField.Text;
                    this.Hide();
                    NavigationForm navigationForm = new NavigationForm();
                    navigationForm.Show();
                }
                else
                    MessageBox.Show("Empty");
                db.closeConnection();
            }
            if (LecturerradioButton.Checked == false && StudentradioButton.Checked == false && AdminradioButton.Checked == false && DirectorradioButton.Checked==false)
                MessageBox.Show("Выберите тип пользователя");
        }
        
        private void RegistationLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}