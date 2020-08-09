using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;
using ILogger = Serilog.ILogger;

namespace Infrastructure.Logging.Serilog
{
    public static class SerilogUtilities
    {
        private static readonly string AspNetCoreEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        /// <summary>
        ///     Only for use in logging to Startup. Use <see cref="Common.IAppLogger{T}"/> otherwise.
        /// </summary>
        /// <returns></returns>
        public static ILogger GetLogger()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{AspNetCoreEnvironment}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            return new LoggerConfiguration()
                .ReadFrom.Configuration(configurationBuilder)
                .Enrich.FromLogContext()
                .CreateLogger();
        }
    }
}
