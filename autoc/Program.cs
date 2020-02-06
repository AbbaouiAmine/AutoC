using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.IO;

namespace autoc
{
    static class Program
    {
        public static string filepath = "";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //Services.etat = Services.Etat();
            if (args.Length != 0)
            {
                string file = @args[0];
                FileInfo f = new FileInfo(file);
                //MessageBox.Show();
                Program.filepath = f.FullName;
            }
            else 
            {
                Program.filepath ="";
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new _08Choix());
            Application.Run(new Welcome());
            //Application.Run(new _09Message());
        }

       //static void opened()
       // {

       //     string[] args = System.Environment.GetCommandLineArgs();
       //     if (args.Length == 1)
       //     {
       //         // make sure it is a file and not some other command-line argument
       //         if (System.IO.File.Exists(args[0]))
       //         {
       //             string filePath = args[0];
       //             string filename = System.IO.Path.GetFileName(filePath); // returns file.ext
       //             MessageBox.Show(filename + "   " + filePath);
       //         }
       //     }

       // }
    }
}
