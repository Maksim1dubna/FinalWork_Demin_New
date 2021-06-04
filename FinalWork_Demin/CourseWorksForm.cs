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
            MySqlCommand command;
            MySqlDataReader reader;
            if (DataCheck.TypeOfUser != "Админ" && DataCheck.TypeOfUser != "Уч.Часть" )
            {
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
                command = new MySqlCommand("SELECT группы.имя_группы, группы.группа_id FROM группы INNER JOIN учебныйплан ON учебныйплан.группа_id = группы.группа_id INNER JOIN аттестация ON аттестация.дисциплина_план_id = учебныйплан.дисциплина_план_id WHERE аттестация.курсовая_работа = 1 GROUP BY группы.группа_id", db.getConnection());
                db.openConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GroupcomboBox2.Items.Add(reader.GetString("имя_группы"));
                    GroupidcomboBox.Items.Add(reader.GetString("группа_id"));
                }
                db.closeConnection();

            }
            if (DataCheck.TypeOfUser == "Студент")
            {
                command = new MySqlCommand("SELECT группы.имя_группы, группы.группа_id FROM группы INNER JOIN учебныйплан ON учебныйплан.группа_id = группы.группа_id INNER JOIN группаистудент ON группаистудент.группа_id = группы.группа_id INNER JOIN пользователи ON пользователи.`зачетная/табельный` = группаистудент.`зачетная/табельный` INNER JOIN авторизация ON авторизация.`зачетная/табельный` = пользователи.`зачетная/табельный` INNER JOIN аттестация ON аттестация.дисциплина_план_id = учебныйплан.дисциплина_план_id WHERE авторизация.логин = @l AND пользователи.статус_пользователя = 'Студент' AND аттестация.курсовая_работа = 1 GROUP BY группы.группа_id", db.getConnection());
                command.Parameters.Add("@l", MySqlDbType.VarChar).Value = DataCheck.L;
                db.openConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GroupcomboBox2.Items.Add(reader.GetString("имя_группы"));
                    GroupidcomboBox.Items.Add(reader.GetString("группа_id"));
                }
                db.closeConnection();
            }
        }
        private void GroupcomboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupidcomboBox.SelectedIndex = GroupcomboBox2.SelectedIndex;
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT аттестация.семестр FROM группы INNER JOIN учебныйплан ON учебныйплан.группа_id = группы.группа_id INNER JOIN аттестация ON аттестация.дисциплина_план_id = учебныйплан.дисциплина_план_id WHERE аттестация.курсовая_работа = 1 AND группы.группа_id = @gid GROUP BY аттестация.семестр", db.getConnection());
            command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = GroupidcomboBox.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SemestrComboBox2.Items.Add(reader.GetString("семестр"));
            }
            db.closeConnection();
        }
        private void SemestrComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT пользователи.фамилия, пользователи.имя, пользователи.отчество, пользователи.`зачетная/табельный` FROM `пользователи` INNER JOIN группаистудент ON группаистудент.`зачетная/табельный`=пользователи.`зачетная/табельный` INNER JOIN группы ON группы.группа_id = группаистудент.группа_id INNER JOIN аттестация ON аттестация.`зачетная/табельный`=пользователи.`зачетная/табельный` WHERE аттестация.семестр = @s AND группы.группа_id = @gid AND аттестация.курсовая_работа = 1", db.getConnection());
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrComboBox2.Text;
            command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = GroupidcomboBox.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                StudentcomboBox.Items.Add(reader.GetString("фамилия") + " " + reader.GetString("имя") + " " + reader.GetString("отчество"));
                StudentidcomboBox.Items.Add(reader.GetString("зачетная/табельный"));
            }
            db.closeConnection();
        }
        private void StudentcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            StudentidcomboBox.SelectedIndex = StudentcomboBox.SelectedIndex;
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT дисциплины.наименование, аттестация.дисциплина_план_id, учебныйплан.индекс FROM аттестация INNER JOIN учебныйплан ON учебныйплан.дисциплина_план_id = аттестация.дисциплина_план_id INNER JOIN дисциплины ON дисциплины.дисциплина_id=учебныйплан.дисциплина_id INNER JOIN группы ON группы.группа_id = учебныйплан.группа_id WHERE аттестация.семестр=@s AND аттестация.`зачетная/табельный` = @zt AND группы.группа_id = @gid AND аттестация.курсовая_работа = 1", db.getConnection());
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrComboBox2.Text;
            command.Parameters.Add("@zt", MySqlDbType.VarChar).Value = StudentidcomboBox.Text;
            command.Parameters.Add("@gid", MySqlDbType.VarChar).Value = GroupidcomboBox.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DisciplinecomboBox2.Items.Add(reader.GetString("индекс") + "/" + reader.GetString("наименование"));
                DisciplineidcomboBox1.Items.Add(reader.GetString("дисциплина_план_id"));
            }
            db.closeConnection();
        }
        private void DisciplinecomboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisciplineidcomboBox1.SelectedIndex = DisciplinecomboBox2.SelectedIndex;
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT аттестация.оценка_курсовой_работы, аттестация.тема_курсовой_работы FROM `аттестация` WHERE семестр = @s AND дисциплина_план_id = @dpid AND `зачетная/табельный`= @zt AND аттестация.курсовая_работа = 1", db.getConnection());
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrComboBox2.Text;
            command.Parameters.Add("@zt", MySqlDbType.VarChar).Value = StudentidcomboBox.Text;
            command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = DisciplineidcomboBox1.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int index = MarkcomboBox.Items.IndexOf(reader.GetString("оценка_курсовой_работы"));
                MarkcomboBox.SelectedIndex = index;
                ThemetextBox.Text = reader.GetString("тема_курсовой_работы");
            }
            db.closeConnection();
        }
        private void InsertMarksButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("UPDATE аттестация SET аттестация.оценка_курсовой_работы = @mocw, аттестация.тема_курсовой_работы = @tocw WHERE семестр = @s AND дисциплина_план_id = @dpid AND `зачетная/табельный` = @zt", db.getConnection());
            command.Parameters.Add("@mocw", MySqlDbType.VarChar).Value = MarkcomboBox.Text;
            command.Parameters.Add("@tocw", MySqlDbType.VarChar).Value = ThemetextBox.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrComboBox2.Text;
            command.Parameters.Add("@zt", MySqlDbType.VarChar).Value = StudentidcomboBox.Text;
            command.Parameters.Add("@dpid", MySqlDbType.VarChar).Value = DisciplineidcomboBox1.Text;
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();// Закрывать из-за нагрузки на базу данных
        }
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