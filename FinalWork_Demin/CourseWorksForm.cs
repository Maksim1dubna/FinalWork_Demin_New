using Microsoft.Office.Interop.Word;
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
    public partial class CourseWorksForm : Form
    {
        public CourseWorksForm()
        {
            InitializeComponent();
            LoadDataIntoCourseWorksForm();
        }
        private void LoadDataIntoCourseWorksForm()
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("");
            MySqlDataReader reader;
            if (DataCheck.TypeOfUser != "Админ" && DataCheck.TypeOfUser != "Уч.Часть" )
            {
                Grouplabel1.Visible = false;
                Grouplabel1.Enabled = false;
                GroupcomboBox1.Visible = false;
                GroupcomboBox1.Enabled = false;
                Semestrlabel1.Visible = false;
                Semestrlabel1.Enabled = false;
                SemestrComboBox1.Visible = false;
                SemestrComboBox1.Enabled = false;
                LessonLabel.Visible = false;
                LessonLabel.Enabled = false;
                DisciplinecomboBox1.Visible = false;
                DisciplinecomboBox1.Enabled = false;
                DateOfCourselabel.Visible = false;
                DateOfCourselabel.Enabled = false;
                DateOfCoursedateTimePicker.Visible = false;
                DateOfCoursedateTimePicker.Enabled = false;
                InsertDataButton.Visible = false;
                InsertDataButton.Enabled = false;
                if(DataCheck.TypeOfUser != "Преподаватель")
                {
                    MarkcomboBox.Enabled = false;
                    StudentcomboBox.Enabled = false;
                    ThemetextBox.Enabled = false;
                    Printbutton.Enabled = false;
                    Printbutton.Visible = false;
                }
            }
            else
            {
                command = new MySqlCommand("SELECT lections.group_id, groups.nameofgroup FROM groups INNER JOIN lections ON " +
                    "lections.group_id = groups.group_id GROUP BY groups.group_id", db.getConnection());
                db.openConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GroupcomboBox1.Items.Add(reader.GetString("nameofgroup"));
                }
                db.closeConnection();
                GroupcomboBox1.SelectedIndex = 0;
            }
            if (DataCheck.TypeOfUser == "Студент")
            {
                command = new MySqlCommand("SELECT courseworks.group_id, groups.nameofgroup FROM courseworks INNER JOIN groups ON groups.group_id " +
                    "= courseworks.group_id INNER JOIN students ON students.group_id = groups.group_id WHERE students.login = @l GROUP BY courseworks.group_id", db.getConnection());
                command.Parameters.Add("@l", MySqlDbType.VarChar).Value = DataCheck.L;
            }
            command = new MySqlCommand("SELECT courseworks.group_id, groups.nameofgroup FROM courseworks INNER JOIN groups ON groups.group_id = courseworks.group_id GROUP BY courseworks.group_id", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                GroupcomboBox2.Items.Add(reader.GetString("nameofgroup"));
            }
            db.closeConnection();
            GroupcomboBox2.SelectedIndex = 0;
        }

        private void GroupcomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisciplinecomboBox1.Items.Clear();
            SemestrComboBox1.Items.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT lections.semestr FROM lections INNER JOIN groups ON groups.group_id = lections.group_id WHERE groups.nameofgroup =@nog GROUP BY lections.semestr", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox1.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SemestrComboBox1.Items.Add(reader.GetString("semestr"));
            }
            db.closeConnection();
            SemestrComboBox1.SelectedIndex = 0;
        }

        private void SemestrComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisciplinecomboBox1.Items.Clear();
            DisciplinecomboBox1.Text = "";
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT lections.discipline_id, disciplines.nameofdiscipline FROM lections INNER JOIN disciplines ON disciplines.discipline_id = lections.discipline_id INNER JOIN groups ON groups.group_id = lections.group_id WHERE groups.nameofgroup = @nog AND lections.semestr = @s GROUP BY lections.discipline_id", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox1.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrComboBox1.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DisciplinecomboBox1.Items.Add(reader.GetString("nameofdiscipline"));
            }
            db.closeConnection();
        }

        private void InsertDataButton_Click(object sender, EventArgs e)
        {
            GroupcomboBox2.Items.Clear();
            SemestrComboBox2.Items.Clear();
            StudentcomboBox.Items.Clear();
            ThemetextBox.Text = "";
            DB db = new DB();
            System.Data.DataTable table = new System.Data.DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT disciplines.nameofdiscipline, groups.nameofgroup, courseworks.semestr FROM courseworks " +
                "INNER JOIN disciplines ON disciplines.discipline_id = courseworks.discipline_id INNER JOIN groups ON groups.group_id = courseworks.group_id " +
                "WHERE groups.nameofgroup = @nog AND courseworks.semestr = @s AND disciplines.nameofdiscipline = @nod", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox1.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrComboBox1.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox1.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой объект уже есть, введите другой");
            }
            else
            {
                command = new MySqlCommand("INSERT INTO courseworks( discipline_id, group_id, semestr ) SELECT lections.discipline_id, groups.group_id, lections.semestr FROM groups INNER JOIN lections ON lections.group_id = groups.group_id INNER JOIN disciplines ON disciplines.discipline_id = lections.discipline_id WHERE disciplines.nameofdiscipline = @nod AND groups.nameofgroup = @nog AND lections.semestr = 1 GROUP BY groups.group_id, lections.semestr, lections.discipline_id; UPDATE courseworks INNER JOIN groups ON groups.group_id = courseworks.group_id INNER JOIN lections ON lections.group_id = groups.group_id INNER JOIN disciplines ON disciplines.discipline_id = courseworks.discipline_id SET dateofcoursework = @doc WHERE disciplines.nameofdiscipline = @nod AND groups.nameofgroup = @nog AND lections.semestr = 1; INSERT INTO courseworksdata( coursework_id, student_id ) SELECT courseworks.coursework_id, students.student_id FROM courseworks INNER JOIN disciplines ON disciplines.discipline_id = courseworks.discipline_id INNER JOIN groups ON groups.group_id = courseworks.group_id INNER JOIN students ON students.group_id = courseworks.group_id WHERE disciplines.nameofdiscipline = @nod AND groups.nameofgroup = @nog AND courseworks.semestr = @s; UPDATE courseworksdata INNER JOIN courseworks ON courseworks.coursework_id = courseworksdata.coursework_id INNER JOIN groups ON groups.group_id = courseworks.group_id INNER JOIN disciplines ON disciplines.discipline_id = courseworks.discipline_id INNER JOIN lections ON lections.group_id = groups.group_id SET Mark = '-', theme = '-' WHERE disciplines.nameofdiscipline = @nod AND groups.nameofgroup = @nog AND lections.semestr = 1;", db.getConnection());
                command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox1.Text;
                command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox1.Text;
                command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrComboBox1.Text;
                command.Parameters.Add("@doc", MySqlDbType.Date).Value = DateOfCoursedateTimePicker.Value;
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
            }
            command = new MySqlCommand("SELECT courseworks.group_id, groups.nameofgroup FROM courseworks INNER JOIN groups ON groups.group_id = courseworks.group_id GROUP BY courseworks.group_id", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GroupcomboBox2.Items.Add(reader.GetString("nameofgroup"));
            }
            db.closeConnection();
        }

        private void GroupcomboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SemestrComboBox2.Items.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT courseworks.semestr FROM courseworks INNER JOIN groups ON groups.group_id = courseworks.group_id WHERE groups.nameofgroup = @nog GROUP BY courseworks.semestr", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox2.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SemestrComboBox2.Items.Add(reader.GetString("semestr"));
            }
            db.closeConnection();
            //SemestrComboBox2.SelectedIndex = 0;
        }

        private void SemestrComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisciplinecomboBox2.Items.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT disciplines.nameofdiscipline FROM courseworks INNER JOIN disciplines ON disciplines.discipline_id = courseworks.discipline_id INNER JOIN groups ON groups.group_id = courseworks.group_id WHERE groups.nameofgroup = @nog AND semestr = @s GROUP BY disciplines.nameofdiscipline", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox2.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrComboBox2.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DisciplinecomboBox2.Items.Add(reader.GetString("nameofdiscipline"));
            }
            db.closeConnection();
            DisciplinecomboBox2.SelectedIndex = 0;
        }
        private void DisciplinecomboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            StudentcomboBox.Items.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("");
            if (DataCheck.TypeOfUser == "Админ" || DataCheck.TypeOfUser == "Уч.часть" || DataCheck.TypeOfUser == "Админ" || DataCheck.TypeOfUser == "Преподаватель")
            {
                command = new MySqlCommand("SELECT students.secondname, students.firstname, students.thirdname, courseworksdata.student_id, courseworksdata.Mark FROM courseworksdata INNER JOIN courseworks ON courseworks.coursework_id = courseworksdata.coursework_id INNER JOIN students ON students.student_id = courseworksdata.student_id INNER JOIN groups ON groups.group_id = courseworks.group_id INNER JOIN disciplines ON disciplines.discipline_id = courseworks.discipline_id WHERE groups.nameofgroup = @nog AND courseworks.semestr = @s AND disciplines.nameofdiscipline = @nod", db.getConnection());
                command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox2.Text;
                command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrComboBox2.Text;
                command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox2.Text;
            }
            if (DataCheck.TypeOfUser == "Студент")
            {
                command = new MySqlCommand("SELECT students.secondname, students.firstname, students.thirdname, courseworksdata.student_id, courseworksdata.Mark FROM courseworksdata INNER JOIN courseworks ON courseworks.coursework_id = courseworksdata.coursework_id INNER JOIN students ON students.student_id = courseworksdata.student_id INNER JOIN groups ON groups.group_id = courseworks.group_id INNER JOIN disciplines ON disciplines.discipline_id = courseworks.discipline_id WHERE groups.nameofgroup = @nog AND courseworks.semestr = @s AND students.login = @l AND disciplines.nameofdiscipline = @nod;", db.getConnection());
                command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox2.Text;
                command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrComboBox2.Text;
                command.Parameters.Add("@l", MySqlDbType.VarChar).Value = DataCheck.L;
                command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox2.Text;
            }
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                StudentcomboBox.Items.Add(reader.GetString("secondname") + " " + reader.GetString("firstname") + " " + reader.GetString("thirdname") + "/" + reader.GetString("student_id"));
            }
            db.closeConnection();
        }
        private void StudentcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] StudentString = StudentcomboBox.Text.Split('/');
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT courseworksdata.theme, courseworksdata.Mark FROM courseworksdata INNER JOIN courseworks ON courseworks.coursework_id = courseworksdata.coursework_id INNER JOIN groups ON groups.group_id = courseworks.group_id INNER JOIN disciplines ON disciplines.discipline_id = courseworks.discipline_id WHERE groups.nameofgroup = @nog AND courseworks.semestr = @s AND courseworksdata.student_id = @sid AND disciplines.nameofdiscipline = @nod", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox2.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrComboBox2.Text;
            command.Parameters.Add("@sid", MySqlDbType.VarChar).Value = StudentString[1];
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox2.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ThemetextBox.Text = reader.GetString("theme");
                int index = MarkcomboBox.Items.IndexOf(reader.GetString("Mark"));
                MarkcomboBox.SelectedIndex = index;
            }
            db.closeConnection();
        }

        private void InsertMarksButton_Click(object sender, EventArgs e)
        {
            string[] StudentString = StudentcomboBox.Text.Split('/');
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("UPDATE courseworksdata INNER JOIN courseworks ON courseworksdata.coursework_id = courseworks.coursework_id INNER JOIN groups ON groups.group_id = courseworks.group_id INNER JOIN disciplines ON disciplines.discipline_id = courseworks.discipline_id SET theme = @t, Mark = @m WHERE groups.nameofgroup = @nog AND disciplines.nameofdiscipline = @nod AND semestr = @s AND courseworksdata.student_id = @sid", db.getConnection());
            command.Parameters.AddWithValue("@t", Convert.ToString(ThemetextBox.Text));
            command.Parameters.AddWithValue("@m", Convert.ToString(MarkcomboBox.Text));
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox2.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox2.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrComboBox2.Text;
            command.Parameters.Add("@sid", MySqlDbType.VarChar).Value = StudentString[1];
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();// Закрывать из-за нагрузки на базу данных
            command.Parameters.Clear();
        }
        /////
        private void Printbutton_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            Document doc = app.Documents.Add(Visible: true);
            Selection s = app.Selection;
            s.ParagraphFormat.SpaceBefore = 0;
            s.ParagraphFormat.SpaceAfter = 0;
            s.ParagraphFormat.LineSpacingRule = (WdLineSpacing)0.5;
            s.Font.Size = 14;
            s.Font.Name = "Times New Roman";
            s.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            s.TypeText("\n\nР О С С И Й С К А Я   Ф Е Д Е Р А Ц И Я\n");
            s.Font.Size = 12;
            s.TypeText("М о с к о в с к а я  о б л а с т ь\n\n");
            s.Font.Bold = 1;
            s.TypeText("Филиал «Котельники»\n");
            s.Font.Size = 10;
            s.Font.Bold = 0;
            s.TypeText("государственного  бюджетного образовательного учреждения\nвысшего образования Московской области\n");
            s.Font.Size = 11;
            s.TypeText("«Университет «Дубна»\n\n");
            s.Font.Size = 12;
            s.TypeText("Очная форма обучения\n\n");
            s.Font.Bold = 1;
            s.TypeText("Ведомость защиты курсовых работ\n\n");
            s.Font.Bold = 0;
            s.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT groups.course FROM groups WHERE groups.nameofgroup = @nog GROUP BY groups.group_id", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox2.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                s.TypeText("Курс    " + reader.GetString("course") + "                                  ");
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT exams.semestr FROM exams INNER JOIN groups ON groups.group_id = exams.group_id WHERE groups.nameofgroup = @nog GROUP BY exams.semestr;", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox2.Text; ;
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                s.TypeText("Семестр   " + reader.GetString("semestr") + "                                  ");
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT groups.nameofgroup FROM groups WHERE groups.nameofgroup = @nog GROUP BY groups.group_id", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox2.Text;
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                s.TypeText("Группа " + reader.GetString("nameofgroup") + "\n\n");
            }
            db.closeConnection();
            s.ParagraphFormat.LineSpacingRule = (WdLineSpacing)1;
            command = new MySqlCommand("SELECT	disciplines.nameofdiscipline FROM courseworks INNER JOIN lecturersanddisciplines ON lecturersanddisciplines.discipline_id = courseworks.discipline_id INNER JOIN lecturers ON lecturers.lecturer_id = lecturersanddisciplines.lecturer_id INNER JOIN groups ON groups.group_id = courseworks.group_id INNER JOIN disciplines ON disciplines.discipline_id = courseworks.discipline_id WHERE groups.nameofgroup = @nog AND disciplines.nameofdiscipline = @nod AND lecturersanddisciplines.main = 1 AND courseworks.semestr = @s", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox2.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox2.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrComboBox2.Text;
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                s.TypeText("Название предмета: " + reader.GetString("nameofdiscipline") + "\n");
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT lecturers.secondname, lecturers.firstname, lecturers.thirdname, lecturers.position FROM courseworks INNER JOIN lecturersanddisciplines ON lecturersanddisciplines.discipline_id = courseworks.discipline_id INNER JOIN lecturers ON lecturers.lecturer_id = lecturersanddisciplines.lecturer_id INNER JOIN groups ON groups.group_id = courseworks.group_id INNER JOIN disciplines ON disciplines.discipline_id = courseworks.discipline_id WHERE groups.nameofgroup = @nog AND lecturersanddisciplines.main = 1 AND disciplines.nameofdiscipline = @nod AND courseworks.semestr =@s", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox2.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox2.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrComboBox2.Text;
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                s.TypeText("Преподаватель(должность, Ф.И.О.) " + reader.GetString("position") + " " + reader.GetString("secondname") + " " + reader.GetString("firstname") + " " + reader.GetString("thirdname") + "\n\n");
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT courseworks.dateofcoursework FROM courseworks INNER JOIN lecturersanddisciplines ON lecturersanddisciplines.discipline_id = courseworks.discipline_id INNER JOIN lecturers ON lecturers.lecturer_id = lecturersanddisciplines.lecturer_id INNER JOIN groups ON groups.group_id = courseworks.group_id INNER JOIN disciplines ON disciplines.discipline_id = courseworks.discipline_id WHERE groups.nameofgroup = @nog AND disciplines.nameofdiscipline = @nod AND courseworks.semestr = @s", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox2.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox2.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrComboBox2.Text;
            db.openConnection();
            reader = command.ExecuteReader();
            string dateString = "-";
            while (reader.Read())
            {
                dateString = Convert.ToDateTime(reader["dateofcoursework"]).ToString("dd/MM/yyyy");
            }
            db.closeConnection();
            s.TypeText("Дата и время выдачи ведомости: " + dateString + " г\n");
            s.TypeText("Дата и время возвращения ведомости: "+ dateString  + " г\n");
            s.TypeText("Начальник учебного отдела ________________");
            command = new MySqlCommand("SELECT secondname, firstname, thirdname FROM directorofstudies", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                s.TypeText("("+ reader.GetString("secondname") + " " + reader.GetString("firstname").Substring(0, 1) + "." + reader.GetString("thirdname").Substring(0, 1) + ")\n");
            }
            db.closeConnection();
            ////////////////
            command = new MySqlCommand("SELECT courseworksdata.Mark FROM courseworksdata INNER JOIN courseworks ON courseworks.coursework_id = courseworksdata.coursework_id INNER JOIN groups ON groups.group_id = courseworks.group_id INNER JOIN disciplines ON disciplines.discipline_id = courseworks.discipline_id WHERE groups.nameofgroup = @nog AND disciplines.nameofdiscipline = @nod AND courseworks.semestr = @s", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox2.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox2.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrComboBox2.Text;
            db.openConnection();
            reader = command.ExecuteReader();
            int countMarks0 = 0;
            int countMarks2 = 0;
            int countMarks3 = 0;
            int countMarks4 = 0;
            int countMarks5 = 0;
            while (reader.Read())
            {
                switch (reader.GetString("Mark"))
                {
                    case "н/я":
                        countMarks0++;
                        break;
                    case "Неудовлетворительно":
                        countMarks2++;
                        break;
                    case "Удовлетворительно":
                        countMarks3++;
                        break;
                    case "Хорошо":
                        countMarks4++;
                        break;
                    case "Отлично":
                        countMarks5++;
                        break;
                    default:
                        break;
                }
            }
            db.closeConnection();
            if (countMarks5 != 0)
                s.TypeText("Отлично " + countMarks5.ToString() + "\n");
            else
                s.TypeText("Отлично " + "-" + "\n");
            if (countMarks4 != 0)
                s.TypeText("Хорошо " + countMarks4.ToString() + "\n");
            else
                s.TypeText("Хорошо " + "-" + "\n");
            if (countMarks3 != 0)
                s.TypeText("Удовлетворительно " + countMarks3.ToString() + "\n");
            else
                s.TypeText("Удовлетворительно " + "-" + "\n");
            if (countMarks2 != 0)
                s.TypeText("Неудовлетворительно " + countMarks2.ToString() + "\n");
            else
                s.TypeText("Неудовлетворительно " + "-" + "\n");
            if (countMarks0 != 0)
                s.TypeText("Не явились " + countMarks0.ToString() + "\n");
            else
                s.TypeText("Не явились " + "-" + "\n");
            command = new MySqlCommand("SELECT lecturers.secondname, lecturers.firstname, lecturers.thirdname FROM exams INNER JOIN groups ON groups.group_id = exams.group_id INNER JOIN disciplines ON disciplines.discipline_id = exams.discipline_id INNER JOIN lecturers ON lecturers.lecturer_id = exams.lecturer_id WHERE groups.nameofgroup = @nog AND disciplines.nameofdiscipline = @nod GROUP BY lecturers.lecturer_id", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox2.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox2.Text;
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                s.TypeText("Подпись преподавателя _____________" + reader.GetString("secondname") + " " + reader.GetString("firstname").Substring(0, 1) + "." + reader.GetString("thirdname").Substring(0, 1) + ".");
            }
            ///////////////
            db.closeConnection();
            command = new MySqlCommand("SELECT students.firstname, students.secondname, students.thirdname, students.numberofzachetki, courseworksdata.Mark, courseworks.dateofcoursework, courseworksdata.theme FROM courseworksdata INNER JOIN courseworks ON courseworks.coursework_id = courseworksdata.coursework_id INNER JOIN students ON students.student_id = courseworksdata.student_id INNER JOIN groups ON groups.group_id = courseworks.group_id INNER JOIN disciplines ON disciplines.discipline_id = courseworks.discipline_id WHERE groups.nameofgroup = @nog AND courseworks.semestr = @s AND disciplines.nameofdiscipline = @nod ORDER BY students.secondname ASC", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupcomboBox2.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox2.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrComboBox2.Text;
            db.openConnection();
            System.Data.DataTable table = new System.Data.DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            int c = table.Rows.Count;
            object start = doc.Sentences[13].Start, end = doc.Sentences[13].Start;
            Range r = doc.Range(ref start, ref end);
            Table t = r.Tables.Add(r, (c + 1)*2-1, 6);
            t.AllowAutoFit = true;
            t.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);
            t.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
            t.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
            t.Range.ParagraphFormat.SpaceBefore = 0;
            t.Range.ParagraphFormat.SpaceAfter = 0;
            t.Range.ParagraphFormat.LineSpacingRule = (WdLineSpacing)0.5;
            t.Range.Font.Size = 12;
            t.Range.Font.Name = "Times New Roman";
            t.Cell(1, 1).Range.Text = "№ п/п";
            t.Cell(1, 2).Range.Text = "Фамилия студента";
            t.Cell(1, 3).Range.Text = "№ зачетной книжки";
            t.Cell(1, 4).Range.Text = "Оценка";
            t.Cell(1, 5).Range.Text = "Дата защиты кур. работы";
            t.Cell(1, 6).Range.Text = "Подпись преподавателя";
            int i = 2;
            int count = 1;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                t.Cell(i, 1).Range.Text = count.ToString();
                t.Cell(i, 2).Range.Text = reader.GetString("secondname") + " " + reader.GetString("firstname").Substring(0, 1) + "." + reader.GetString("thirdname").Substring(0, 1) + ".";
                t.Cell(i, 3).Range.Text = reader.GetString("numberofzachetki");
                t.Cell(i, 4).Range.Text = reader.GetString("Mark");
                t.Cell(i, 5).Range.Text = Convert.ToDateTime(reader["dateofcoursework"]).ToString("dd/MM/yyyy");
                t.Cell(i, 6).Range.Text = "подпись";
                t.Cell(i+1, 1).Range.Text = "Тема: " + reader.GetString("theme");
                object begCell = t.Cell(i + 1, 1).Range.Start;
                object endCell = t.Cell(i + 1, 6).Range.End;
                Range wordcellrange = doc.Range(ref begCell, ref endCell);
                wordcellrange.Select();
                app.Selection.Cells.Merge();

                //Cells.Merge()
                i = i+2;
                count++;
            }
            db.closeConnection();
            ///////////
            doc.Save();
            doc.Close();
            app.Quit();
        }

        private void CourseWorksForm_FormClosed(object sender, FormClosedEventArgs e)
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