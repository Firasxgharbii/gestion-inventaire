using System;
using System.Windows.Forms;
using renaissanceproject2025; // souvent le même que Program.cs

namespace renaissanceproject2025
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BienvenueForm());
        }
    }
}
