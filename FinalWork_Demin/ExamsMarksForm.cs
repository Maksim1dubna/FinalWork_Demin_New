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
using Microsoft.Office.Interop.Word;
namespace FinalWork_Demin
{
    public partial class ExamsMarksForm : Form
    {
        public ExamsMarksForm()
        {
            InitializeComponent();
            LoadDataInto();
        }

        private void LoadDataInto()
        {
            if (DataCheck.TypeOfUser != "Админ")
            {
                GroupPrintComboBox.Visible = false;
                GroupPrintComboBox.Enabled = false;
                SemestrPrintlabel.Visible = false;
                SemestrPrintlabel.Enabled = false;
                SemestrprintcomboBox.Visible = false;
                SemestrprintcomboBox.Enabled = false;
                TypeOFExamPrintlabel.Visible = false;
                TypeOFExamPrintlabel.Enabled = false;
                DisciplinePrintcomboBox.Visible = false;
                DisciplinePrintcomboBox.Enabled = false;
                NewDocumentbutton.Visible = false;
                NewDocumentbutton.Enabled = false;
                MarkscomboBox.Enabled = false;
                ExamTicketcomboBox.Enabled = false;
            }
            GroupComboBox.Items.Clear();
            StudentsComboBox.Items.Clear();
            SemestrcomboBox.Items.Clear();
            DisciplinecomboBox.Items.Clear();
            MarkscomboBox.Items.Clear();
            GroupPrintComboBox.Items.Clear();
            DisciplinePrintcomboBox.Items.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("");
            if (DataCheck.TypeOfUser == "Админ" || DataCheck.TypeOfUser == "Уч.часть" )
                command = new MySqlCommand("SELECT groups.nameofgroup FROM groups INNER JOIN exams ON groups.group_id = exams.group_id GROUP BY exams.group_id", db.getConnection());
            if (DataCheck.TypeOfUser == "Студент")
            {
                command = new MySqlCommand("SELECT groups.nameofgroup FROM groups INNER JOIN exams ON groups.group_id = exams.group_id INNER JOIN students ON students.student_id = exams.student_id WHERE students.login = @l GROUP BY exams.group_id", db.getConnection());
                command.Parameters.Add("@l", MySqlDbType.VarChar).Value = DataCheck.L;
            }
            if (DataCheck.TypeOfUser == "Преподаватель")
            {
             
            }
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GroupComboBox.Items.Add(reader.GetString("nameofgroup"));
                GroupPrintComboBox.Items.Add(reader.GetString("nameofgroup"));
            }
            db.closeConnection();
            GroupComboBox.SelectedIndex = 0;
            GroupPrintComboBox.SelectedIndex = 0;
        }
        private void GroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisciplinecomboBox.Items.Clear();
            StudentsComboBox.Items.Clear();
            SemestrcomboBox.Items.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("select semestr from exams INNER JOIN groups ON groups.group_id = exams.group_id WHERE groups.nameofgroup = @nog GROUP BY semestr", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupComboBox.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SemestrcomboBox.Items.Add(reader.GetString("semestr"));
            }
            db.closeConnection();
            SemestrcomboBox.SelectedIndex = 0;
        }

        private void SemestrcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("");
            if (DataCheck.TypeOfUser == "Админ" || DataCheck.TypeOfUser == "Уч.часть" )
            {
                command = new MySqlCommand("SELECT secondname, firstname, thirdname, student_id FROM students INNER JOIN groups ON groups.group_id = students.group_id WHERE groups.nameofgroup = @nog GROUP BY students.student_id ORDER BY secondname;", db.getConnection());
                command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupComboBox.Text;
            }
            if (DataCheck.TypeOfUser == "Студент")
            {
                command = new MySqlCommand("SELECT secondname, firstname, thirdname, student_id FROM students INNER JOIN groups ON groups.group_id = students.group_id WHERE groups.nameofgroup = @nog AND students.login = @l GROUP BY students.student_id ORDER BY secondname;", db.getConnection());
                command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupComboBox.Text;
                command.Parameters.Add("@l", MySqlDbType.VarChar).Value = DataCheck.L;
            }
            db.openConnection();
            int i = 1;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                StudentsComboBox.Items.Add(i + "/" + reader.GetString("secondname") + " " + reader.GetString("firstname") + " " + reader.GetString("thirdname") + "/" + reader.GetString("student_id"));
                i++;
            }
            db.closeConnection();
            StudentsComboBox.SelectedIndex = 0;
            command = new MySqlCommand("SELECT disciplines.nameofdiscipline FROM disciplines INNER JOIN exams ON exams.discipline_id = disciplines.discipline_id INNER JOIN groups ON groups.group_id = exams.group_id WHERE groups.nameofgroup = @nog AND exams.semestr = @s GROUP BY disciplines.discipline_id", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupComboBox.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrcomboBox.Text;
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                DisciplinecomboBox.Items.Add(reader.GetString("nameofdiscipline"));
            }
            DisciplinecomboBox.SelectedIndex = 0;
        }
        private void StudentsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MarkscomboBox.Items.Clear();
            string[] MarksSring = { "Отлично", "Хорошо", "Удовлетворительно", "Неудовлетворительно", "н/я", "-" };
            string[] NoMarksSring = { "Зачтено", "Не зачтено", "н/я", "-" };
            string[] StudentString = StudentsComboBox.Text.Split('/');
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT students.secondname, students.firstname, students.thirdname, disciplines.nameofdiscipline,exams.TypeOfExam,exams.TypeOfMark,exams.Mark," +
                "exams.dateofexam,exams.numofexam FROM exams LEFT JOIN students ON students.student_id = exams.student_id LEFT JOIN groups ON groups.group_id = " +
                "exams.group_id LEFT JOIN disciplines ON disciplines.discipline_id = exams.discipline_id  WHERE groups.nameofgroup = @nog AND " +
                "disciplines.nameofdiscipline = @nod AND students.student_id = @sid ORDER BY students.student_id", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupComboBox.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox.Text;
            command.Parameters.Add("@sid", MySqlDbType.VarChar).Value = StudentString[2];
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if ((reader.GetString("TypeOfMark") == "оценка" && reader.GetString("TypeOfExam") == "Зачет") || reader.GetString("TypeOfExam") == "Экзамен")
                {
                    MarkscomboBox.Items.AddRange(MarksSring);
                    TypeOFExamlabel.Text = reader.GetString("TypeOfExam");
                }
                else
                {
                    MarkscomboBox.Items.AddRange(NoMarksSring);
                    TypeOFExamlabel.Text = reader.GetString("TypeOfExam");
                }
                int index = MarkscomboBox.Items.IndexOf(reader.GetString("Mark"));
                MarkscomboBox.SelectedIndex = index;
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT exams.examticket FROM exams INNER JOIN disciplines ON disciplines.discipline_id = exams.discipline_id WHERE disciplines.nameofdiscipline = @nod AND student_id = @sid", db.getConnection());
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox.Text;
            command.Parameters.Add("@sid", MySqlDbType.VarChar).Value = StudentString[2];
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                int index = ExamTicketcomboBox.Items.IndexOf(reader.GetString("examticket"));
                ExamTicketcomboBox.SelectedIndex = index;
            }
            db.closeConnection();
        }

        private void DisciplinecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MarkscomboBox.Items.Clear();
            string[] MarksSring = { "Отлично", "Хорошо", "Удовлетворительно", "Неудовлетворительно", "н/я", "-"};
            string[] NoMarksSring = { "Зачтено", "Не зачтено", "н/я", "-"};
            string[] StudentString = StudentsComboBox.Text.Split('/');
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT students.secondname, students.firstname, students.thirdname, disciplines.nameofdiscipline,exams.TypeOfExam,exams.TypeOfMark,exams.Mark," +
               "exams.dateofexam,exams.numofexam FROM exams LEFT JOIN students ON students.student_id = exams.student_id LEFT JOIN groups ON groups.group_id = " +
               "exams.group_id LEFT JOIN disciplines ON disciplines.discipline_id = exams.discipline_id  WHERE groups.nameofgroup = @nog AND " +
               "disciplines.nameofdiscipline = @nod AND students.student_id = @sid ORDER BY students.student_id", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupComboBox.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox.Text;
            command.Parameters.Add("@sid", MySqlDbType.VarChar).Value = StudentString[2];
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if ((reader.GetString("TypeOfMark") == "оценка" && reader.GetString("TypeOfExam") == "Зачет") || reader.GetString("TypeOfExam") == "Экзамен")
                {
                    MarkscomboBox.Items.AddRange(MarksSring);
                    TypeOFExamlabel.Text = reader.GetString("TypeOfExam");
                }
                else
                {
                    MarkscomboBox.Items.AddRange(NoMarksSring);
                    TypeOFExamlabel.Text = reader.GetString("TypeOfExam");
                }
                int index = MarkscomboBox.Items.IndexOf(reader.GetString("Mark"));
                MarkscomboBox.SelectedIndex = index;
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT exams.examticket FROM exams INNER JOIN disciplines ON disciplines.discipline_id = exams.discipline_id WHERE disciplines.nameofdiscipline = @nod AND student_id = @sid", db.getConnection());
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox.Text;
            command.Parameters.Add("@sid", MySqlDbType.VarChar).Value = StudentString[2];
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                int index = ExamTicketcomboBox.Items.IndexOf(reader.GetString("examticket"));
                ExamTicketcomboBox.SelectedIndex = index;
            }
            db.closeConnection();
        }
        private void ExamTicketcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] StudentString = StudentsComboBox.Text.Split('/');
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("UPDATE exams INNER JOIN groups ON exams.group_id = groups.group_id INNER JOIN disciplines ON " +
                "exams.discipline_id = disciplines.discipline_id INNER JOIN students ON exams.student_id = students.student_id SET exams.examticket = @et WHERE " +
                "exams.TypeOfExam = @toe AND disciplines.nameofdiscipline = @nod AND groups.nameofgroup = @nog AND exams.student_id = @sid AND exams.semestr = @s", db.getConnection());
            command.Parameters.AddWithValue("@et", Convert.ToString(ExamTicketcomboBox.Text));
            command.Parameters.Add("@toe", MySqlDbType.VarChar).Value = TypeOFExamlabel.Text;
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupComboBox.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox.Text;
            command.Parameters.Add("@sid", MySqlDbType.VarChar).Value = StudentString[2];
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrcomboBox.Text;
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();// Закрывать из-за нагрузки на базу данных
            command.Parameters.Clear();
        }
        private void MarkscomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] StudentString = StudentsComboBox.Text.Split('/');
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("UPDATE exams INNER JOIN groups ON exams.group_id = groups.group_id INNER JOIN disciplines ON " +
                "exams.discipline_id = disciplines.discipline_id INNER JOIN students ON exams.student_id = students.student_id SET exams.Mark = @m WHERE " +
                "exams.TypeOfExam = @toe AND disciplines.nameofdiscipline = @nod AND groups.nameofgroup = @nog AND exams.student_id = @sid AND exams.semestr = @s", db.getConnection());
            command.Parameters.AddWithValue("@m", Convert.ToString(MarkscomboBox.Text));
            command.Parameters.Add("@toe", MySqlDbType.VarChar).Value = TypeOFExamlabel.Text;
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupComboBox.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinecomboBox.Text;
            command.Parameters.Add("@sid", MySqlDbType.VarChar).Value = StudentString[2];
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrcomboBox.Text;
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();// Закрывать из-за нагрузки на базу данных
            command.Parameters.Clear();
        }
        private void GroupPrintComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //DisciplinePrintcomboBox.SelectedIndex = 0;
            SemestrprintcomboBox.Items.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("select semestr from exams INNER JOIN groups ON groups.group_id = exams.group_id WHERE groups.nameofgroup = @nog GROUP BY semestr", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupPrintComboBox.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SemestrprintcomboBox.Items.Add(reader.GetString("semestr"));
            }
            db.closeConnection();
            SemestrprintcomboBox.SelectedIndex = 0;
        }
        private void SemestrprintcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisciplinePrintcomboBox.Items.Clear();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT disciplines.nameofdiscipline FROM disciplines INNER JOIN exams ON " +
                "exams.discipline_id = disciplines.discipline_id INNER JOIN groups ON groups.group_id = exams.group_id " +
                "WHERE groups.nameofgroup = @nog AND exams.semestr=@s GROUP BY disciplines.discipline_id", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupPrintComboBox.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrprintcomboBox.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DisciplinePrintcomboBox.Items.Add(reader.GetString("nameofdiscipline"));
            }
            db.closeConnection();
        }
        private void DisciplinePrintcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT exams.TypeOfExam, exams.TypeOfMark FROM exams LEFT JOIN groups ON groups.group_id = exams.group_id LEFT " +
                "JOIN disciplines ON disciplines.discipline_id = exams.discipline_id WHERE groups.nameofgroup = @nog AND disciplines.nameofdiscipline = @nod AND exams.semestr = @s " +
                "GROUP BY exams.TypeOfExam, exams.TypeOfMark", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupPrintComboBox.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinePrintcomboBox.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = SemestrprintcomboBox.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString("TypeOfMark") == "оценка" && reader.GetString("TypeOfExam") == "Зачет")
                {
                    TypeOFExamPrintlabel.Text = reader.GetString("TypeOfExam");
                }
                else
                {
                    TypeOFExamPrintlabel.Text = reader.GetString("TypeOfExam");
                }

            }
            db.closeConnection();
        }


        private void ExamsMarksForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void NavigationLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            NavigationForm navigationform = new NavigationForm();
            navigationform.Show();
        }

        private void NewDocumentbutton_Click(object sender, EventArgs e)
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
            DB db = new DB();
            /////
            MySqlCommand command = new MySqlCommand("SELECT exams.group_id, exams.TypeOfExam FROM exams INNER JOIN groups ON groups.group_id = exams.group_id " +
                "INNER JOIN disciplines ON disciplines.discipline_id = exams.discipline_id INNER JOIN lecturers ON lecturers.lecturer_id = exams.lecturer_id " +
                "WHERE groups.nameofgroup = @nog AND disciplines.nameofdiscipline = @nod GROUP BY  exams.group_id, exams.TypeOfExam", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupPrintComboBox.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinePrintcomboBox.Text;
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString("TypeOfExam") == "Экзамен")
                    s.TypeText("Экзаменационная ведомость\n\n");
                else if (reader.GetString("TypeOfExam") == "Зачет")
                    s.TypeText("Зачетная ведомость\n\n");
            }
            db.closeConnection();

            s.Font.Bold = 0;
            s.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            command = new MySqlCommand("SELECT groups.course FROM groups WHERE groups.nameofgroup = @nog GROUP BY groups.group_id", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupPrintComboBox.Text;
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                s.TypeText("Курс    " + reader.GetString("course") + "                                  ");
            }
            db.closeConnection();
            s.TypeText("Семестр   " + SemestrcomboBox.Text + "                                  ");
            command = new MySqlCommand("SELECT groups.nameofgroup FROM groups WHERE groups.nameofgroup = @nog GROUP BY groups.group_id", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupPrintComboBox.Text;
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                s.TypeText("Группа " + reader.GetString("nameofgroup") + "\n\n");
            }
            db.closeConnection();
            s.ParagraphFormat.LineSpacingRule = (WdLineSpacing)1;
            s.TypeText("Название предмета: " + DisciplinePrintcomboBox.Text + "\n");
            command = new MySqlCommand("SELECT lecturers.position, lecturers.secondname, lecturers.firstname, lecturers.thirdname FROM lecturersanddisciplines " +
                "INNER JOIN lecturers ON lecturers.lecturer_id = lecturersanddisciplines.lecturer_id INNER JOIN disciplines ON disciplines.discipline_id = lecturersanddisciplines.discipline_id " +
                "INNER JOIN groups WHERE groups.nameofgroup = @nog AND disciplines.nameofdiscipline = @nod AND lecturersanddisciplines.main = 1;", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupPrintComboBox.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinePrintcomboBox.Text;
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                s.TypeText("Преподаватель(должность, Ф.И.О.) " + reader.GetString("position") + " " + reader.GetString("secondname") + " " + reader.GetString("firstname") + " " + reader.GetString("thirdname") + "\n\n");
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT students.firstname, students.secondname, students.thirdname, students.numberofzachetki, exams.Mark, exams.dateofexam " +
                "FROM students INNER JOIN exams ON exams.student_id = students.student_id INNER JOIN groups ON groups.group_id = exams.group_id INNER JOIN disciplines " +
                "ON disciplines.discipline_id = exams.discipline_id WHERE groups.nameofgroup = @nog AND disciplines.nameofdiscipline = @nod ORDER BY students.secondname ASC", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupPrintComboBox.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinePrintcomboBox.Text;
            db.openConnection();
            reader = command.ExecuteReader();
            string dateString = "-";
            while (reader.Read())
            {
                dateString = Convert.ToDateTime(reader["dateofexam"]).ToString("dd/MM/yyyy");
            }
            db.closeConnection();
            s.TypeText("Дата и время выдачи ведомости: " + dateString + " г\n");
            s.TypeText("Дата и время возвращения ведомости: " + dateString + " г\n");
            s.TypeText("Начальник учебного отдела ________________");
            command = new MySqlCommand("SELECT secondname, firstname, thirdname FROM directorofstudies", db.getConnection());
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                s.TypeText("(" + reader.GetString("secondname") + " " + reader.GetString("firstname").Substring(0, 1) + "." + reader.GetString("thirdname").Substring(0, 1) + ")\n");
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT exams.TypeOfExam, exams.TypeOfMark, exams.Mark FROM exams LEFT JOIN groups ON groups.group_id = exams.group_id LEFT " +
                "JOIN disciplines ON disciplines.discipline_id = exams.discipline_id WHERE groups.nameofgroup = @nog AND disciplines.nameofdiscipline = @nod", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupPrintComboBox.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinePrintcomboBox.Text;
            db.openConnection();
            reader = command.ExecuteReader();
            int countMarks0 = 0;
            int countMarks2 = 0;
            int countMarks3 = 0;
            int countMarks4 = 0;
            int countMarks5 = 0;
            int countMarksGood = 0;
            int countMarksBad = 0;
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
                    case "Зачет":
                        countMarksGood++;
                        break;
                    case "Не зачтено":
                        countMarksBad++;
                        break;
                    default:
                        break;
                }
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT exams.TypeOfExam, exams.TypeOfMark FROM exams INNER JOIN groups ON groups.group_id = exams.group_id " +
                "INNER JOIN disciplines ON disciplines.discipline_id = exams.discipline_id WHERE groups.nameofgroup = @nog AND " +
                "disciplines.nameofdiscipline = @nod GROUP BY exams.TypeOfExam, exams.TypeOfMark", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupPrintComboBox.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinePrintcomboBox.Text;
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                if ((reader.GetString("TypeOfMark") == "оценка" && reader.GetString("TypeOfExam") == "Зачет") || reader.GetString("TypeOfExam") == "Экзамен")
                {
                    if(countMarks5 != 0)
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
                }
                else
                {
                    if (countMarksGood != 0)
                        s.TypeText("Зачет " + countMarksGood.ToString() + "\n");
                    else
                        s.TypeText("Зачет " + "-" + "\n");
                    if (countMarksBad != 0)
                        s.TypeText("Не зачет " + countMarksBad.ToString() + "\n");
                    else
                        s.TypeText("Не зачет " + "-" + "\n");
                    if (countMarks3 != 0)
                        s.TypeText("Не явились " + countMarks0.ToString() + "\n");
                    else
                        s.TypeText("Удовлетворительно " + "-" + "\n");
                    
                    
                }
            }
            db.closeConnection();

            command = new MySqlCommand("SELECT lecturers.secondname, lecturers.firstname, lecturers.thirdname FROM exams INNER JOIN groups ON groups.group_id = exams.group_id INNER JOIN disciplines ON disciplines.discipline_id = exams.discipline_id INNER JOIN lecturers ON lecturers.lecturer_id = exams.lecturer_id WHERE groups.nameofgroup = @nog AND disciplines.nameofdiscipline = @nod GROUP BY lecturers.lecturer_id", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupPrintComboBox.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinePrintcomboBox.Text;
            db.openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                s.TypeText("Подпись преподавателя _____________" + reader.GetString("secondname") + " " + reader.GetString("firstname").Substring(0, 1) + "." + reader.GetString("thirdname").Substring(0, 1) + ".");
            }
            db.closeConnection();
            command = new MySqlCommand("SELECT students.firstname, students.secondname, students.thirdname, students.numberofzachetki, exams.Mark, exams.dateofexam, exams.examticket " +
                "FROM students INNER JOIN exams ON exams.student_id = students.student_id INNER JOIN groups ON groups.group_id = exams.group_id INNER JOIN disciplines " +
                "ON disciplines.discipline_id = exams.discipline_id WHERE groups.nameofgroup = @nog AND disciplines.nameofdiscipline = @nod ORDER BY students.secondname ASC", db.getConnection());
            command.Parameters.Add("@nog", MySqlDbType.VarChar).Value = GroupPrintComboBox.Text;
            command.Parameters.Add("@nod", MySqlDbType.VarChar).Value = DisciplinePrintcomboBox.Text;
            db.openConnection();
            System.Data.DataTable table = new System.Data.DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            reader = command.ExecuteReader();
            int c = table.Rows.Count;
            object start = doc.Sentences[13].Start, end = doc.Sentences[13].Start;
            Range r = doc.Range(ref start, ref end);
            Table t = r.Tables.Add(r, c + 1, 7);
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
            t.Cell(1, 5).Range.Text = "Номер билета";
            t.Cell(1, 6).Range.Text = "Дата сдачи экзамена";
            t.Cell(1, 7).Range.Text = "Подпись преподавателя";
            int i = 2;
            int count = 1;

            while (reader.Read())
            {
                t.Cell(i, 1).Range.Text = count.ToString() + ".";
                t.Cell(i, 2).Range.Text = reader.GetString("secondname") + " " + reader.GetString("firstname").Substring(0, 1) + "." + reader.GetString("thirdname").Substring(0, 1) + ".";
                t.Cell(i, 3).Range.Text = reader.GetString("numberofzachetki");
                t.Cell(i, 4).Range.Text = reader.GetString("Mark");
                t.Cell(i, 5).Range.Text = reader.GetString("examticket");
                t.Cell(i, 6).Range.Text = Convert.ToDateTime(reader["dateofexam"]).ToString("dd/MM/yyyy");
                t.Cell(i, 7).Range.Text = "ПОДПИСЬ";
                i++;
                count++;
            }
            db.closeConnection();
            doc.Save();
            doc.Close();
            app.Quit();
        }

    }
}