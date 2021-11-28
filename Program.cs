using System;
using System.Threading;
using System.Windows.Forms;

namespace Maxwell_Wheel
{


    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SplashScreen.ShowSplashScreen();
            MainForm mainForm = new MainForm(); //this takes ages
            SplashScreen.CloseForm();
            Application.Run(mainForm);
        }
    }

   


}
