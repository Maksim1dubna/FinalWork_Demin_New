using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace FinalWork_Demin
{
    public partial class AddNewData : Form
    {
        public AddNewData()
        {
            InitializeComponent();
            LoadDataIntoAddNewGroupForm();
            Deletebutton1.Visible = false;
            Deletebutton2.Visible = false;
            Deletebutton3.Visible = false;
            Deletebutton4.Visible = false;
        }
        private void LoadDataIntoAddNewGroupForm()
        {
            this.Text = "Добавление начальных данных" + "(" + DataCheck.TypeOfUser + ")";
            DirectioncomboBox1.Items.Clear();
            DirectioncomboBox2.Items.Clear();
            SpecialtyсomboBox1.Items.Clear();
            SpecialtyсomboBox2.Items.Clear();
            GroupcomboBox1.Items.Clear();
            DisciplinescomboBox.Items.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `направления`", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DirectioncomboBox1.Items.Add(reader.GetString("направление"));
                DirectioncomboBox2.Items.Add(reader.GetString("направление"));
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT * FROM `специальности`", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                SpecialtyсomboBox1.Items.Add(reader.GetString("имя_специальности"));
                SpecialtyсomboBox2.Items.Add(reader.GetString("имя_специальности"));
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT * FROM `группы`", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                GroupcomboBox1.Items.Add(reader.GetString("имя_группы"));
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT * FROM `дисциплины`", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                DisciplinescomboBox.Items.Add(reader.GetString("наименование"));
            }
            db.closeConnection();
        }
        // Первая часть программы для направлений
        // Первая часть программы для направлений
        // Первая часть программы для направлений
        private void DirectioncomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `направления` WHERE `направление` = @d", db.getConnection());
            command.Parameters.Add("@d", MySqlDbType.VarChar).Value = DirectioncomboBox1.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TypeDatacheckBox1.Checked = true;
                TypeDatacheckBox1.Enabled = true;
                Deletebutton1.Visible = true;
                InsertUpddatebutton1.Text = "Обновить";
                CheckBoxTextlabel1.Text = "Cуществует в базе данных как " + reader.GetString("направление_id");
            }
            db.closeConnection();
        }

        private void TypeDatacheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (TypeDatacheckBox1.Checked == false)
            {
                TypeDatacheckBox1.Enabled = false;
                Deletebutton1.Visible = false;
                InsertUpddatebutton1.Text = "Записать";
                CheckBoxTextlabel1.Text = "Не существует в базе данных";
            }
        }

        private void InsertUpddatebutton1_Click(object sender, EventArgs e)
        {
            if (InsertUpddatebutton1.Text == "Записать")
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("INSERT INTO `направления` (`направление_id`,`направление`) VALUES(NULL, @d)", db.getConnection());
                command.Parameters.Add("@d", MySqlDbType.VarChar).Value = DirectioncomboBox1.Text;
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();// Закрывать из-за нагрузки на базу данных
                LoadDataIntoAddNewGroupForm();
            }
            else
            {
                string[] StringCheckBox= CheckBoxTextlabel1.Text.Split(' '); //5
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("UPDATE `направления` SET `направление` = @d WHERE `направление_id` = @did", db.getConnection());
                command.Parameters.Add("@d", MySqlDbType.VarChar).Value = DirectioncomboBox1.Text;
                command.Parameters.Add("@did", MySqlDbType.VarChar).Value = StringCheckBox[5];
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();// Закрывать из-за нагрузки на базу данных
                LoadDataIntoAddNewGroupForm();
                Deletebutton1.Visible = true;
            }
        }

        private void Deletebutton1_Click(object sender, EventArgs e)
        {
            string[] StringCheckBox = CheckBoxTextlabel1.Text.Split(' '); //5
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("DELETE FROM `направления` WHERE `направление_id` = @did", db.getConnection());
            command.Parameters.Add("@did", MySqlDbType.VarChar).Value = StringCheckBox[5];
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();// Закрывать из-за нагрузки на базу данных
            LoadDataIntoAddNewGroupForm();
            Deletebutton1.Visible = true;
            DirectioncomboBox1.Text = "";
            TypeDatacheckBox1.Checked = false;
            TypeDatacheckBox1.Enabled = false;
        }

        private void DirectioncomboBox1_TextChanged(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `направления` WHERE `направление` = @d", db.getConnection());
            command.Parameters.Add("@d", MySqlDbType.VarChar).Value = DirectioncomboBox1.Text;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            System.Data.DataTable table = new System.Data.DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                //command = new MySqlCommand("SELECT * FROM `направления` WHERE `направление` = @d", db.getConnection());
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TypeDatacheckBox1.Checked = true;
                    TypeDatacheckBox1.Enabled = true;
                    Deletebutton1.Visible = true;
                    InsertUpddatebutton1.Text = "Обновить";
                    CheckBoxTextlabel1.Text = "Cуществует в базе данных как " + reader.GetString("направление_id");
                }
                db.closeConnection();
            }
        }
        // Вторая часть программы для специальностей
        // Вторая часть программы для специальностей
        // Вторая часть программы для специальностей
        private void SpecialtyсomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT `направления`.`направление`, `специальности`.имя_специальности, `специальности`.`специальность_id` FROM `специальности` INNER JOIN `направления` ON `направления`.`направление_id` = `специальности`.`направление_id` WHERE `специальности`.имя_специальности = @s", db.getConnection());
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SpecialtyсomboBox1.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TypeDatacheckBox2.Checked = true;
                TypeDatacheckBox2.Enabled = true;
                Deletebutton2.Visible = true;
                InsertUpddatebutton2.Text = "Обновить";
                CheckBoxTextlabel2.Text = "Cуществует в базе данных как " + reader.GetString("специальность_id");
                int index = DirectioncomboBox2.Items.IndexOf(reader.GetString("направление"));
                DirectioncomboBox2.SelectedIndex = index;
            }
            db.closeConnection();
        }

        private void SpecialtyсomboBox1_TextChanged(object sender, EventArgs e)
        {

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT `направления`.`направление`, `специальности`.имя_специальности, `специальности`.`специальность_id` FROM `специальности` INNER JOIN `направления` ON `направления`.`направление_id` = `специальности`.`направление_id` WHERE `специальности`.имя_специальности = @s", db.getConnection());
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SpecialtyсomboBox1.Text;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            System.Data.DataTable table = new System.Data.DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TypeDatacheckBox2.Checked = true;
                    TypeDatacheckBox2.Enabled = true;
                    Deletebutton2.Visible = true;
                    InsertUpddatebutton2.Text = "Обновить";
                    CheckBoxTextlabel2.Text = "Cуществует в базе данных как " + reader.GetString("специальность_id");
                    int index = DirectioncomboBox2.Items.IndexOf(reader.GetString("направление"));
                    DirectioncomboBox2.SelectedIndex = index;
                }
                db.closeConnection();
            }
        }

        private void TypeDatacheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (TypeDatacheckBox2.Checked == false)
            {
                TypeDatacheckBox2.Enabled = false;
                Deletebutton2.Visible = false;
                InsertUpddatebutton2.Text = "Записать";
                CheckBoxTextlabel2.Text = "Не существует в базе данных";
            }
        }

        private void InsertUpddatebutton2_Click(object sender, EventArgs e)
        {
            if (InsertUpddatebutton2.Text == "Записать")
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT `направление_id` FROM `направления` WHERE `направление` = @d;", db.getConnection());
                command.Parameters.Add("@d", MySqlDbType.VarChar).Value = DirectioncomboBox2.Text;
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                int id = 0;
                while (reader.Read())
                {
                    id = reader.GetInt32("направление_id");
                }
                db.closeConnection();
                command = new MySqlCommand("INSERT INTO `специальности`(`специальность_id`, `направление_id`, имя_специальности) VALUES(NULL, @id, @s)", db.getConnection());
                command.Parameters.Add("@d", MySqlDbType.VarChar).Value = DirectioncomboBox2.Text;
                command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SpecialtyсomboBox1.Text;
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();// Закрывать из-за нагрузки на базу данных
                LoadDataIntoAddNewGroupForm();
            }
            else
            {
                string[] StringCheckBox = CheckBoxTextlabel2.Text.Split(' ');//5
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT `направление_id` FROM `направления` WHERE `направление` = @d;", db.getConnection());
                command.Parameters.Add("@d", MySqlDbType.VarChar).Value = DirectioncomboBox2.Text;
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                int id = 0;
                while (reader.Read())
                {
                    id = reader.GetInt32("направление_id");
                }
                db.closeConnection();
                command = new MySqlCommand("UPDATE `специальности` SET имя_специальности = @s, `направление_id` = @id WHERE `специальность_id` = @sid", db.getConnection());
                command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SpecialtyсomboBox1.Text;
                command.Parameters.Add("@sid", MySqlDbType.VarChar).Value = StringCheckBox[5];
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();// Закрывать из-за нагрузки на базу данных
                LoadDataIntoAddNewGroupForm();
            }
        }

        private void Deletebutton2_Click(object sender, EventArgs e)
        {
            string[] StringCheckBox = CheckBoxTextlabel2.Text.Split(' '); //5
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("DELETE FROM `специальности` WHERE `специальность_id` = @sid", db.getConnection());
            command.Parameters.Add("@sid", MySqlDbType.VarChar).Value = StringCheckBox[5];
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();// Закрывать из-за нагрузки на базу данных
            LoadDataIntoAddNewGroupForm();
            Deletebutton2.Visible = true;
            SpecialtyсomboBox1.Text = "";
            TypeDatacheckBox2.Checked = false;
            TypeDatacheckBox2.Enabled = false;
        }
        // Третья часть программы для группы
        // Третья часть программы для группы
        // Третья часть программы для группы
        private void GroupcomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT `группы`.`группа_id`, `специальности`.имя_специальности, `группы`.`имя_группы`,`группы`.`форма_обучения`,`группы`.`год_поступления` FROM `группы` INNER JOIN `специальности` ON `специальности`.`специальность_id` = `группы`.`специальность_id` WHERE `группы`.`имя_группы` = @nog", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox1.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TypeDatacheckBox3.Checked = true;
                TypeDatacheckBox3.Enabled = true;
                Deletebutton3.Visible = true;
                InsertUpddatebutton3.Text = "Обновить";
                CheckBoxTextlabel3.Text = "Cуществует в базе данных как " + reader.GetString("группа_id");
                yearofnumericUpDown.Value = reader.GetInt16("год_поступления");
                int index = FormcomboBox.Items.IndexOf(reader.GetString("форма_обучения"));
                FormcomboBox.SelectedIndex = index;
                index = SpecialtyсomboBox2.Items.IndexOf(reader.GetString("имя_специальности"));
                SpecialtyсomboBox2.SelectedIndex = index;
            }
            db.closeConnection();
        }

        private void GroupcomboBox1_TextChanged(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT `группы`.`группа_id`, `специальности`.имя_специальности, `группы`.`имя_группы`,`группы`.`год_поступления` FROM `группы` INNER JOIN `специальности` ON `специальности`.`специальность_id` = `группы`.`специальность_id` WHERE `группы`.`имя_группы` = @nog", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox1.Text;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            System.Data.DataTable table = new System.Data.DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TypeDatacheckBox3.Checked = true;
                    TypeDatacheckBox3.Enabled = true;
                    Deletebutton3.Visible = true;
                    InsertUpddatebutton3.Text = "Обновить";
                    CheckBoxTextlabel3.Text = "Cуществует в базе данных как " + reader.GetString("группа_id");
                    yearofnumericUpDown.Value = reader.GetInt16("год_поступления");
                    int index = SpecialtyсomboBox2.Items.IndexOf(reader.GetString("имя_специальности"));
                    SpecialtyсomboBox2.SelectedIndex = index;
                }
                db.closeConnection();
            }
        }

        private void TypeDatacheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (TypeDatacheckBox3.Checked == false)
            {
                TypeDatacheckBox3.Enabled = false;
                Deletebutton3.Visible = false;
                InsertUpddatebutton3.Text = "Записать";
                CheckBoxTextlabel3.Text = "Не существует в базе данных";
            }
        }

        private void InsertUpddatebutton3_Click(object sender, EventArgs e)
        {
            if (InsertUpddatebutton3.Text == "Записать")
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT `специальность_id` FROM `специальности` WHERE имя_специальности = @s", db.getConnection());
                command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SpecialtyсomboBox2.Text;
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                int id = 0;
                while (reader.Read())
                {
                    id = reader.GetInt32("специальность_id");
                }
                db.closeConnection();
                command = new MySqlCommand("INSERT INTO `группы` (`группа_id`, `специальность_id`, `имя_группы`, `форма_обучения`,`год_поступления`) VALUES (NULL, @id, @nog, @fos,@c)", db.getConnection());
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox1.Text;
                command.Parameters.Add("@fos", MySqlDbType.VarChar).Value = FormcomboBox.Text;
                command.Parameters.Add("@c", MySqlDbType.VarChar).Value = yearofnumericUpDown.Text;
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();// Закрывать из-за нагрузки на базу данных
                LoadDataIntoAddNewGroupForm();
            }
            else
            {
                string[] StringCheckBox = CheckBoxTextlabel3.Text.Split(' ');//5
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT `специальность_id` FROM `специальности` WHERE имя_специальности = @s", db.getConnection());
                command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SpecialtyсomboBox2.Text;
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                int id = 0;
                while (reader.Read())
                {
                    id = reader.GetInt32("специальность_id");
                }
                db.closeConnection();
                command = new MySqlCommand("UPDATE `группы` SET `специальность_id` = @id, `имя_группы` = @nog, `форма_обучения`=@fos,`год_поступления`=@c WHERE `группа_id` = @gid", db.getConnection());
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox1.Text;
                command.Parameters.Add("@fos", MySqlDbType.VarChar).Value = FormcomboBox.Text;
                command.Parameters.Add("@c", MySqlDbType.VarChar).Value = yearofnumericUpDown.Text;
                command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = StringCheckBox[5];
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();// Закрывать из-за нагрузки на базу данных
                LoadDataIntoAddNewGroupForm();
            }
        }
        private void Deletebutton3_Click(object sender, EventArgs e)
        {
            string[] StringCheckBox = CheckBoxTextlabel3.Text.Split(' '); //5
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("DELETE FROM `группы` WHERE `группа_id` = @gid", db.getConnection());
            command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = StringCheckBox[5];
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();// Закрывать из-за нагрузки на базу данных
            LoadDataIntoAddNewGroupForm();
            Deletebutton3.Visible = true;
            SpecialtyсomboBox2.Text = "";
            TypeDatacheckBox3.Checked = false;
            TypeDatacheckBox3.Enabled = false;
        }

        private void AddNewData_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
        // Четвертая часть программы для Дисциплины
        // Четвертая часть программы для Дисциплины
        // Четвертая часть программы для Дисциплины

        private void NavigationLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            NavigationForm navigationform = new NavigationForm();
            navigationform.Show();
        }

        private void DisciplinescomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM дисциплины WHERE `наименование` = @nod", db.getConnection());
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinescomboBox.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TypeDatacheckBox4.Checked = true;
                TypeDatacheckBox4.Enabled = true;
                Deletebutton4.Visible = true;
                InsertUpddatebutton4.Text = "Обновить";
                CheckBoxTextlabel4.Text = "Cуществует в базе данных как " + reader.GetString("дисциплина_id");
            }
            db.closeConnection();
        }

        private void InsertUpddatebutton4_Click(object sender, EventArgs e)
        {
            if (InsertUpddatebutton4.Text == "Записать")
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("INSERT INTO `дисциплины` (`дисциплина_id`,`наименование`) VALUES(NULL, @nod)", db.getConnection());
                command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinescomboBox.Text;
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();// Закрывать из-за нагрузки на базу данных
                LoadDataIntoAddNewGroupForm();
            }
            else
            {
                string[] StringCheckBox = CheckBoxTextlabel4.Text.Split(' '); //5
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("UPDATE `дисциплины` SET `наименование` = @nod WHERE `дисциплина_id` = @did", db.getConnection());
                command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinescomboBox.Text;
                command.Parameters.Add("@did", MySqlDbType.VarChar).Value = StringCheckBox[5];
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();// Закрывать из-за нагрузки на базу данных
                LoadDataIntoAddNewGroupForm();
                Deletebutton4.Visible = true;
            }
        }

        private void Deletebutton4_Click(object sender, EventArgs e)
        {
            string[] StringCheckBox = CheckBoxTextlabel4.Text.Split(' '); //5
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("DELETE FROM `дисциплины` WHERE `дисциплина_id` = @did", db.getConnection());
            command.Parameters.Add("@did", MySqlDbType.VarChar).Value = StringCheckBox[5];
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();// Закрывать из-за нагрузки на базу данных
            LoadDataIntoAddNewGroupForm();
            Deletebutton4.Visible = true;
            TypeDatacheckBox4.Checked = false;
            TypeDatacheckBox4.Enabled = false;
        }

        private void TypeDatacheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (TypeDatacheckBox1.Checked == false)
            {
                TypeDatacheckBox4.Enabled = false;
                Deletebutton4.Visible = false;
                InsertUpddatebutton4.Text = "Записать";
                CheckBoxTextlabel4.Text = "Не существует в базе данных";
            }
        }

        private void DisciplinescomboBox_TextChanged(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `дисциплины` WHERE `наименование` = @nod", db.getConnection());
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinescomboBox.Text;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            System.Data.DataTable table = new System.Data.DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TypeDatacheckBox4.Checked = true;
                    TypeDatacheckBox4.Enabled = true;
                    Deletebutton4.Visible = true;
                    InsertUpddatebutton4.Text = "Обновить";
                    CheckBoxTextlabel4.Text = "Cуществует в базе данных как " + reader.GetString("дисциплина_id");
                }
                db.closeConnection();
            }
        }
    }
}
