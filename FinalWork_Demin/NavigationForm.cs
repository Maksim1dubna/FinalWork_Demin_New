using System;
using System.Windows.Forms;

namespace FinalWork_Demin
{
    public partial class NavigationForm : Form
    {
        public NavigationForm()
        {
            InitializeComponent();
            this.Text = "Навигация" + "(" + DataCheck.TypeOfUser + ")";
            if (DataCheck.TypeOfUser != "Админ" && DataCheck.TypeOfUser != "Уч.часть") // проверка типа вошедшего пользователя по статическому классу Datacheck в данном случае, кто не является администратором или руководителем учебной части не могут переходить на окна добавления начальных данных, занятия и преподаватели, регистрацию пользователя
            {
                AddNewDatalabel.Enabled = false;
                AddNewDatalabel.Visible = false;
                AddLessonsLabel.Enabled = false;
                AddLessonsLabel.Visible = false;
                RegistationLabel.Enabled = false;
                RegistationLabel.Visible = false;
            }
        }

        private void AddLessonsLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddLessonsForm addlessonsForm = new AddLessonsForm();
            addlessonsForm.Show();
        }

        private void AddNewDatalabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddNewData addnewdata = new AddNewData();
            addnewdata.Show();
        }

        private void CourseWorkslabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            CourseWorksForm courseworksform = new CourseWorksForm();
            courseworksform.Show();
        }

        private void ExamsMarksFormlabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            ExamsMarksForm examsmarksform = new ExamsMarksForm();
            examsmarksform.Show();
        }

        private void VisitsAndProgresslabel_Click(object sender, EventArgs e)
        {
            if (DataCheck.TypeOfUser == "Студент") // если пользователь является студетом, то он переходит в специальное окно для посещения
            {
                this.Hide();
                VisitsForStudentsForm visitsandprogress = new VisitsForStudentsForm();
                visitsandprogress.Show();
            }
            else 
            {
                this.Hide();
                VisitingForm visitsandprogress = new VisitingForm();
                visitsandprogress.Show();
            }
        }

        private void RegistrationLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm registrationform = new RegistrationForm();
            registrationform.Show();
        }
        private void Loginlabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm registrationForm = new LoginForm();
            registrationForm.Show();
            DataCheck.L = ""; // очитстка логина
            DataCheck.TypeOfUser = ""; // очитстка типа пользователя
        }

        private void NavigationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
