using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VetClinika
{
    static class Data
    {
        //public static string Glob_connection_string = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Honor\source\repos\VetClinika2\VetClinika\VetClinika\VetDB.mdf;Integrated Security = True";
        public static string Glob_connection_string = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|VetDB.mdf;Integrated Security = True";
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
            Application.Run(new Form1());
        }
    }
}
