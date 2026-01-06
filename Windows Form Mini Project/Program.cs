using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Windows_Form_Mini_Project
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Registration()); // form 1
            Application.Run(new Registration_Successful()); // form 2
            Application.Run(new Login_Page()); // form 3
            Application.Run(new View_Page()); // form 4
            Application.Run(new Grid_View()); // form 5
            Application.Run(new Alignment_Page()); // form 6
            Application.Run(new Forgot()); // form 7
            Application.Run(new Forgot_Username()); // form 8
            Application.Run(new Forgot_Password()); // form 9
            //Application.Run(new ());
        }
    }
}
