using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new HostBuilder()
              .ConfigureServices((hostContext, services) =>
              {
                  services.AddDbContext<SqLiteContexto>(options =>
                  {
                      options.UseSqlite("Data Source=SqLiteContexto.db;");
                  });
              });

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    var logg = services.GetRequiredService<ILogger<Form1>>();
                    var employeeContext = services.GetRequiredService<SqLiteContexto>();
                    Application.SetHighDpiMode(HighDpiMode.SystemAware);
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1(employeeContext));

                    Console.WriteLine("Success");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Occured");
                }
            }

        }

    }
}
