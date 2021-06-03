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
    public partial class ListOfLessonsForm : Form
    {
        public ListOfLessonsForm()
        {
            InitializeComponent();
            LoadDataIntoListOfLessons();
        }
        private void LoadDataIntoListOfLessons()
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT groups.nameofgroup, lections.group_id FROM lections INNER JOIN groups ON groups.group_id=lections.group_id GROUP BY lections.group_id", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GroupcomboBox.Items.Add(reader.GetString("nameofgroup")+"/"+ reader.GetString("group_id"));
            }
            db.closeConnection();
            GroupcomboBox.SelectedIndex = 0;
        }

        private void GroupcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SemestrComboBox.Items.Clear();
            string[] GroupString = GroupcomboBox.Text.Split('/');
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT lections.semestr FROM lections WHERE group_id = @gid GROUP BY lections.semestr", db.getConnection());
            command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = GroupString[1];
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SemestrComboBox.Items.Add(reader.GetString("semestr"));
            }
            db.closeConnection();
            SemestrComboBox.SelectedIndex = 0;
        }

        private void SemestrComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] GroupString = GroupcomboBox.Text.Split('/');
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT discipline_id, semestr, dayofweek, TypeOfWeek FROM lections WHERE group_id = @gid AND semestr = @s GROUP BY discipline_id, dayofweek,TypeOfWeek", db.getConnection());
            command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = GroupString[1];
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrComboBox.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            ListOfLessonsdataGridView.DataSource = dataTable;
            db.closeConnection();
        }

        private void NavigationLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
