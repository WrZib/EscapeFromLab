using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EscapeFromLab
{
    internal static class Program
    {
        static Menu menu = new Menu();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            Application.Run(menu);
        }
    }
}