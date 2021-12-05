using System;
using System.Threading;
using System.Windows.Forms;
using SharpGL;
namespace Maxwell_Wheel
{
    static class constants
    {
        public const int side_Panel_Size = 25;
    }

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
            SplashScreen.ShowSplashScreen();
            SplashScreen.ProgressTime();
            MainForm mainForm = new MainForm(); //this takes ages
            mainForm.TopMost = true;
            SplashScreen.CloseForm();
            Application.Run(mainForm);
            
        }
    }

   


}
