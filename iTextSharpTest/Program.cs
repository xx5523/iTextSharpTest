using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTextSharpTest
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            if (!Directory.Exists("input"))
            {
                Directory.CreateDirectory("input");
            }
            if (!Directory.Exists("output"))
            {
                Directory.CreateDirectory("output");
            }
            if (!Directory.Exists("config"))
            {
                Directory.CreateDirectory("config");
            }
        }
    }
}
