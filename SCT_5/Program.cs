using Application.ViewModels;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence.Context;
using Persistence.Repositories;
using SCT_5.Factories;
using SCT_5.Forms;

namespace SCT_5
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();

            IHostBuilder builder = Host.CreateDefaultBuilder();

            builder.ConfigureAppConfiguration(configurationBuilder => configurationBuilder.AddJsonFile("appsettings.json"));

            builder.ConfigureServices((context, services) =>
            {
                string connectionString = context.Configuration.GetConnectionString("SCT_2025") ?? throw new Exception("Cannot get connection string");
                services.AddDbContextFactory<CarServiceContext>(options => options.UseNpgsql(connectionString));

                services.AddTransient<IEmployeesRepository, EmployeesRepository>();

                services.AddTransient<EmployeesViewModel>();
                services.AddTransient<EmployeeViewModel>();

                services.AddTransient<EmployeesFormFactory>();
                services.AddTransient<EmployeeFormFactory>();


                services.AddTransient<ICarPartsRepository, CarPartsRepository>();

                services.AddTransient<CarPartsViewModel>();
                services.AddTransient<CarPartViewModel>();

                services.AddTransient<CarPartFormFactory>();
                services.AddTransient<CarPartsFormFactory>();


                services.AddTransient<MainForm>();
            });

            IHost host = builder.Build();

            System.Windows.Forms.Application.Run(host.Services.GetRequiredService<MainForm>());
        }
    }
}
