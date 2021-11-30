using System;
using System.Threading;
using System.Windows.Forms;
using SharpGL;
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
            SplashScreen.ProgressTime();
            MainForm mainForm = new MainForm(); //this takes ages
            //System.Threading.Thread.Sleep(5000);
            SplashScreen.CloseForm();
            Application.Run(mainForm);
            mainForm.Focus();
            System.Threading.Thread.Sleep(500);
            
        }
    }

   


}
