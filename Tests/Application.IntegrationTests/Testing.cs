using Application.Common.Interfaces;
using Infrastructure.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using NUnit.Framework;
using Persistence;
using Respawn;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebUI;

namespace Application.IntegrationTests
{
    [SetUpFixture]
    public class Testing
    {
        private static IConfigurationRoot _configuration;
        private static IServiceScopeFactory _scopeFactory;
        private static Checkpoint _checkpoint;
        private static int _currentUserTeamId;

        [OneTimeSetUp]
        public async Task RunBeforeAnyTestsAsync()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();

            var startup = new Startup(_configuration);

            var services = new ServiceCollection();
            services.AddSingleton(Mock.Of<IHostEnvironment>(w =>
                w.EnvironmentName == "Development" &&
                w.ApplicationName == "DynamoLeague.WebUI"));

            startup.ConfigureServices(services);

            // Replace service registration for ICurrentUserService
            // Remove existing registration
            var currentUserServiceDescriptor = services.FirstOrDefault(d =>
                d.ServiceType == typeof(ICurrentUserService));

            services.Remove(currentUserServiceDescriptor);

            // Register testing version
            var currentUserService = new Mock<ICurrentUserService>();
            currentUserService.Setup(cus => cus.GetTeamIdAsync()).ReturnsAsync(_currentUserTeamId);
            services.AddScoped(provider => currentUserService.Object);

            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

            _checkpoint = new Checkpoint
            {
                TablesToIgnore = new[] { "__EFMigrationsHistory" }
            };

            await EnsureDatabaseAsync();
        }

        private async Task EnsureDatabaseAsync()
        {
            using var scope = _scopeFactory.CreateScope();

            var dynamoLeagueDbContext = scope.ServiceProvider.GetService<DynamoLeagueDbContext>();
            var identityDbContext = scope.ServiceProvider.GetService<ApplicationIdentityDbContext>();

            await dynamoLeagueDbContext.Database.MigrateAsync();
            await identityDbContext.Database.MigrateAsync();
        }

        public static async Task ResetState()
        {
            await _checkpoint.Reset(_configuration.GetConnectionString("DefaultConnection"));

            _currentUserTeamId = default;
        }

        public static async Task<TEntity> FindAsync<TEntity>(int id)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<DynamoLeagueDbContext>();

            return await context.FindAsync<TEntity>(id);
        }

        public static async Task AddAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<DynamoLeagueDbContext>();

            context.Add(entity);

            await context.SaveChangesAsync();
        }

        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetService<IMediator>();

            return await mediator.Send(request);
        }

        public static async Task<int> RunAsDefaultUserAsync()
        {
            var userName = "test@local";
            var password = "Testing1234!";
            var teamId = 1;

            using var scope = _scopeFactory.CreateScope();

            var userManager = scope.ServiceProvider.GetService<IUserManager>();

            var user = new ApplicationUser(userName, userName, teamId);

            var (Result, UserId) = await userManager.CreateAsync(userName, password, teamId);

            _currentUserTeamId = user.TeamId;

            return _currentUserTeamId;
        }
    }
}
