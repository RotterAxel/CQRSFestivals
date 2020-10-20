using System;
using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebUI
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            
            using (var scope = host.Services.CreateScope())
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                try
                {
                    var env = scope.ServiceProvider.GetService<IWebHostEnvironment>();
                    var context = scope.ServiceProvider.GetService<FestivalsDbContext>();
                    logger.LogInformation("Applying migrations...");
                    context.Database.Migrate();

                    if (env.IsDevelopment())
                    {
                        var dateTimeService = scope.ServiceProvider.GetService<IDateTime>();
                        context.EnsureSeedDataForContext(dateTimeService);
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred with migrating or seeding the DB.");
                    return 1;
                }
            }
            host.Run();
            return 0;
        }
        

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}