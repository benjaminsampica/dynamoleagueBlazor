using Application.Common.Interfaces;
using Common;
using Infrastructure.Email;
using Infrastructure.Identity;
using Infrastructure.Identity.Claims;
using Infrastructure.Identity.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserManager, UserManagerService>();
            services.AddScoped<IRoleManager, RoleManagerService>();
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddSingleton<IEmailSender, EmailSender>();

            services.AddDbContext<ApplicationIdentityDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationIdentityDbContext).Assembly.FullName)));

            services
                .AddDefaultIdentity<ApplicationUser>()
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddClaimsPrincipalFactory<CurrentUserClaimsFactory>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
            });

            services.AddAuthentication();

            return services;
        }
    }
}
