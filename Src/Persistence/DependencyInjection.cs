using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DynamoLeagueDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(DynamoLeagueDbContext).Assembly.FullName)));

            services.AddScoped<IDynamoLeagueDbContext>(provider => provider.GetService<DynamoLeagueDbContext>());

            return services;
        }
    }
}
