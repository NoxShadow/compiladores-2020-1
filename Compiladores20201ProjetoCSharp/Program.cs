using Compiladores20201ProjetoCSharp.FrontEnd;
using System;
using System.Windows.Forms;

namespace Compiladores20201ProjetoCSharp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainLayout());
        }
    }
}
