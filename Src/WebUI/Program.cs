using Application.Common.Interfaces;
using Application.System.Commands;
using Infrastructure.Identity;
using Infrastructure.Identity.Services;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Startup>>();

                try
                {
                    var dynamoLeagueContext = services.GetRequiredService<DynamoLeagueDbContext>();
                    var identityContext = services.GetRequiredService<ApplicationIdentityDbContext>();
                    var hostingEnvironment = services.GetRequiredService<IHostEnvironment>();
                    if (hostingEnvironment.IsDevelopment())
                    {
                        await dynamoLeagueContext.Database.EnsureDeletedAsync();
                        await dynamoLeagueContext.Database.EnsureCreatedAsync();
                        await identityContext.Database.MigrateAsync();

                        var mediatr = services.GetRequiredService<IMediator>();
                        await mediatr.Send(new SeedDataCommand(), CancellationToken.None);

                        var identitySeedService = new SeedIdentityService(services.GetRequiredService<IUserManager>(), services.GetRequiredService<IRoleManager>());
                        await identitySeedService.SeedDevelopmentEnvironmentAsync();
                    }
                    else
                    {
                        logger.LogInformation("Beginning database migration.");
                        await dynamoLeagueContext.Database.MigrateAsync();
                        await identityContext.Database.MigrateAsync();
                        logger.LogInformation("Migrated database successfully.");
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred migrating the database.");
                }
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
