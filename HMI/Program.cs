using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMI
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormMain());

            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            DialogResult result;

            
            using (var loginForm = new fmLogin())
                result = loginForm.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                // login was successful
                Application.Run(new FormMain());
            }
        }
    }
}
