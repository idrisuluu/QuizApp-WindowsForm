using Task3.Models;

namespace Task3
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        //[STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            // PM> Scaffold-DbContext "Server=localhost;User ID=ahmet;Password=Qwe789asd;Database=QuizDb;Trusted_Connection=False;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
            QuizDbContext _db = new QuizDbContext();
            ApplicationConfiguration.Initialize();
            Application.Run(new gLobalLogin());
            //Application.Run(new Form1(_db));
        }
    }
}