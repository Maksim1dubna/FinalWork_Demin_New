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
            CoursecomboBox1.SelectedIndex = 0;
            Deletebutton1.Visible = false;
            Deletebutton2.Visible = false;
            Deletebutton3.Visible = false;
            Deletebutton4.Visible = false;
        }
        private void LoadDataIntoAddNewGroupForm()
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
            DirectioncomboBox1.Items.Clear();
            DirectioncomboBox2.Items.Clear();
            SpecialtyсomboBox1.Items.Clear();
            SpecialtyсomboBox2.Items.Clear();
            GroupcomboBox1.Items.Clear();
            DisciplinescomboBox.Items.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM directions", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DirectioncomboBox1.Items.Add(reader.GetString("direction"));
                DirectioncomboBox2.Items.Add(reader.GetString("direction"));
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT * FROM specialtys", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                SpecialtyсomboBox1.Items.Add(reader.GetString("specialtyname"));
                SpecialtyсomboBox2.Items.Add(reader.GetString("specialtyname"));
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT * FROM groups", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                GroupcomboBox1.Items.Add(reader.GetString("nameofgroup"));
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT * FROM disciplines", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                DisciplinescomboBox.Items.Add(reader.GetString("nameofdiscipline"));
            }
            db.closeConnection();
        }
        // Первая часть программы для направлений
        // Первая часть программы для направлений
        // Первая часть программы для направлений
        private void DirectioncomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM directions WHERE direction = @d", db.getConnection());
            command.Parameters.Add("@d", MySqlDbType.VarChar).Value = DirectioncomboBox1.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TypeDatacheckBox1.Checked = true;
                TypeDatacheckBox1.Enabled = true;
                Deletebutton1.Visible = true;
                InsertUpddatebutton1.Text = "Обновить";
                CheckBoxTextlabel1.Text = "Cуществует в базе данных как " + reader.GetString("direction_id");
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
                MySqlCommand command = new MySqlCommand("INSERT INTO directions (direction_id,direction) VALUES(NULL, @d)", db.getConnection());
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
                MySqlCommand command = new MySqlCommand("UPDATE directions SET direction = @d WHERE direction_id = @did", db.getConnection());
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
            MySqlCommand command = new MySqlCommand("DELETE FROM directions WHERE direction_id = @did", db.getConnection());
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
            MySqlCommand command = new MySqlCommand("SELECT * FROM directions WHERE direction = @d", db.getConnection());
            command.Parameters.Add("@d", MySqlDbType.VarChar).Value = DirectioncomboBox1.Text;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            System.Data.DataTable table = new System.Data.DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                //command = new MySqlCommand("SELECT * FROM directions WHERE direction = @d", db.getConnection());
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TypeDatacheckBox1.Checked = true;
                    TypeDatacheckBox1.Enabled = true;
                    Deletebutton1.Visible = true;
                    InsertUpddatebutton1.Text = "Обновить";
                    CheckBoxTextlabel1.Text = "Cуществует в базе данных как " + reader.GetString("direction_id");
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
            MySqlCommand command = new MySqlCommand("SELECT directions.direction, specialtys.specialtyname, specialtys.specialty_id FROM specialtys INNER JOIN directions ON directions.direction_id = specialtys.direction_id WHERE specialtys.specialtyname = @s", db.getConnection());
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SpecialtyсomboBox1.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TypeDatacheckBox2.Checked = true;
                TypeDatacheckBox2.Enabled = true;
                Deletebutton2.Visible = true;
                InsertUpddatebutton2.Text = "Обновить";
                CheckBoxTextlabel2.Text = "Cуществует в базе данных как " + reader.GetString("specialty_id");
                int index = DirectioncomboBox2.Items.IndexOf(reader.GetString("direction"));
                DirectioncomboBox2.SelectedIndex = index;
            }
            db.closeConnection();
        }

        private void SpecialtyсomboBox1_TextChanged(object sender, EventArgs e)
        {

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT directions.direction, specialtys.specialtyname, specialtys.specialty_id FROM specialtys INNER JOIN directions ON directions.direction_id = specialtys.direction_id WHERE specialtys.specialtyname = @s", db.getConnection());
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
                    CheckBoxTextlabel2.Text = "Cуществует в базе данных как " + reader.GetString("specialty_id");
                    int index = DirectioncomboBox2.Items.IndexOf(reader.GetString("direction"));
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
                MySqlCommand command = new MySqlCommand("SELECT direction_id FROM directions WHERE direction = @d;", db.getConnection());
                command.Parameters.Add("@d", MySqlDbType.VarChar).Value = DirectioncomboBox2.Text;
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                int id = 0;
                while (reader.Read())
                {
                    id = reader.GetInt32("direction_id");
                }
                db.closeConnection();
                command = new MySqlCommand("INSERT INTO specialtys(specialty_id, direction_id, specialtyname) VALUES(NULL, @id, @s)", db.getConnection());
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
                MySqlCommand command = new MySqlCommand("SELECT direction_id FROM directions WHERE direction = @d;", db.getConnection());
                command.Parameters.Add("@d", MySqlDbType.VarChar).Value = DirectioncomboBox2.Text;
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                int id = 0;
                while (reader.Read())
                {
                    id = reader.GetInt32("direction_id");
                }
                db.closeConnection();
                command = new MySqlCommand("UPDATE specialtys SET specialtyname = @s, direction_id = @id WHERE specialty_id = @sid", db.getConnection());
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
            MySqlCommand command = new MySqlCommand("DELETE FROM specialtys WHERE specialty_id = @sid", db.getConnection());
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
            MySqlCommand command = new MySqlCommand("SELECT groups.group_id, specialtys.specialtyname, groups.nameofgroup,groups.course FROM groups INNER JOIN specialtys ON specialtys.specialty_id = groups.specialty_id WHERE groups.nameofgroup = @nog", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox1.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TypeDatacheckBox3.Checked = true;
                TypeDatacheckBox3.Enabled = true;
                Deletebutton3.Visible = true;
                InsertUpddatebutton3.Text = "Обновить";
                CheckBoxTextlabel3.Text = "Cуществует в базе данных как " + reader.GetString("group_id");
                int index = CoursecomboBox1.Items.IndexOf(reader.GetString("course"));
                CoursecomboBox1.SelectedIndex = index;
                index = SpecialtyсomboBox2.Items.IndexOf(reader.GetString("specialtyname"));
                SpecialtyсomboBox2.SelectedIndex = index;
            }
            db.closeConnection();
        }

        private void GroupcomboBox1_TextChanged(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT groups.group_id, specialtys.specialtyname, groups.nameofgroup,groups.course FROM groups INNER JOIN specialtys ON specialtys.specialty_id = groups.specialty_id WHERE groups.nameofgroup = @nog", db.getConnection());
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
                    CheckBoxTextlabel3.Text = "Cуществует в базе данных как " + reader.GetString("group_id");
                    int index = CoursecomboBox1.Items.IndexOf(reader.GetString("course"));
                    CoursecomboBox1.SelectedIndex = index;
                    index = SpecialtyсomboBox2.Items.IndexOf(reader.GetString("specialtyname"));
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
                MySqlCommand command = new MySqlCommand("SELECT specialty_id FROM specialtys WHERE specialtyname = @s", db.getConnection());
                command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SpecialtyсomboBox2.Text;
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                int id = 0;
                while (reader.Read())
                {
                    id = reader.GetInt32("specialty_id");
                }
                db.closeConnection();
                command = new MySqlCommand("INSERT INTO groups (group_id, specialty_id, nameofgroup, course) VALUES (NULL, @id, @nog, @c)", db.getConnection());
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox1.Text;
                command.Parameters.Add("@c", MySqlDbType.VarChar).Value = CoursecomboBox1.Text;
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();// Закрывать из-за нагрузки на базу данных
                LoadDataIntoAddNewGroupForm();
            }
            else
            {
                string[] StringCheckBox = CheckBoxTextlabel3.Text.Split(' ');//5
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("SELECT specialty_id FROM specialtys WHERE specialtyname = @s", db.getConnection());
                command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SpecialtyсomboBox2.Text;
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                int id = 0;
                while (reader.Read())
                {
                    id = reader.GetInt32("specialty_id");
                }
                db.closeConnection();
                command = new MySqlCommand("UPDATE groups SET specialty_id = @id, nameofgroup = @nog, course=@c WHERE group_id = @gid", db.getConnection());
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox1.Text;
                command.Parameters.Add("@c", MySqlDbType.VarChar).Value = CoursecomboBox1.Text;
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
            MySqlCommand command = new MySqlCommand("DELETE FROM groups WHERE group_id = @gid", db.getConnection());
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
            MySqlCommand command = new MySqlCommand("SELECT * FROM disciplines WHERE nameofdiscipline = @nod", db.getConnection());
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinescomboBox.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TypeDatacheckBox4.Checked = true;
                TypeDatacheckBox4.Enabled = true;
                Deletebutton4.Visible = true;
                InsertUpddatebutton4.Text = "Обновить";
                CheckBoxTextlabel4.Text = "Cуществует в базе данных как " + reader.GetString("discipline_id");
            }
            db.closeConnection();
        }

        private void InsertUpddatebutton4_Click(object sender, EventArgs e)
        {
            if (InsertUpddatebutton4.Text == "Записать")
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("INSERT INTO disciplines (discipline_id,nameofdiscipline) VALUES(NULL, @nod)", db.getConnection());
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
                MySqlCommand command = new MySqlCommand("UPDATE disciplines SET nameofdiscipline = @nod WHERE discipline_id = @did", db.getConnection());
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
            MySqlCommand command = new MySqlCommand("DELETE FROM disciplines WHERE discipline_id = @did", db.getConnection());
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
            MySqlCommand command = new MySqlCommand("SELECT * FROM disciplines WHERE nameofdiscipline = @nod", db.getConnection());
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
                    CheckBoxTextlabel4.Text = "Cуществует в базе данных как " + reader.GetString("discipline_id");
                }
                db.closeConnection();
            }
        }
    }
}
