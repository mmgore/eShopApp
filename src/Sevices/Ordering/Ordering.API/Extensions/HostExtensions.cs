using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;

namespace Ordering.API.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase<TContext>(this IHost host, Action<TContext, IServiceProvider> action, int? retry = 0) where TContext : DbContext
        {
            int retryFor = retry.Value;

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<TContext>>();
                var context = services.GetService<TContext>();

                try
                {
                    logger.LogInformation("Database migration started");
                    context.Database.Migrate();
                    InvokeSeeder(action, context, services);
                    logger.LogInformation("Database migration finished");
                }
                catch (SqlException ex)
                {
                    logger.LogInformation($"Error!! {ex.Message}");
                    if(retryFor < 50)
                    {
                        retryFor++;
                        Thread.Sleep(2000);
                        MigrateDatabase(host, action, retryFor);
                    }
                }
            }
            return host;
        }

        public static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> action, TContext context, IServiceProvider services) where TContext : DbContext
        {
            context.Database.Migrate();
            action(context, services);
        }
    }
}
