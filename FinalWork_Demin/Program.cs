using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalWork_Demin
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());
            //Application.Run(new AddLessonsForm());
            //Application.Run(new ExamsMarksForm());
            //Application.Run(new CourseWorksForm());
            //Application.Run(new AddNewData());
            //Application.Run(new RegistrationForm());
            Application.Run(new LoginForm());
            //Application.Run(new NavigationForm());
        }
    }
}
