using fitness_tracking_app.Forms;
using fitness_tracking_app.Repositories;

namespace fitness_tracking_app
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            FitnessDatabase.InitializeDatabase(); 
            
            ApplicationConfiguration.Initialize();
            Application.Run(new AuthForm());

            
        }
    }
}