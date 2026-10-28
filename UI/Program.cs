using BOL;
using DAL;

namespace UI
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
            ApplicationConfiguration.Initialize();

            // Punto único donde se ensamblan las capas (UI -> BOL -> DAL -> API).
            // Cambia la URL base por la de tu API (debe terminar en "/").
            var http = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7281/"),
                Timeout = TimeSpan.FromSeconds(15)
            };
            var dal = new ClientesDal(http);
            var bol = new ClientesBol(dal);

            Application.Run(new FrmClientes(bol));
        }
    }
}