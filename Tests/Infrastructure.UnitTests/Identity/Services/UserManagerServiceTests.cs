using FluentAssertions;
using Infrastructure.Identity;
using Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Infrastructure.UnitTests.Identity.Services
{
    public class UserManagerServiceTests
    {
        [Fact]
        public async Task CreateUserAsync_Successful_ReturnsSuccessResult()
        {
            var sut = new UserManagerService(TestUserManager.GetSuccessfulManager());
            var (result, _) = await sut.CreateUserAsync(string.Empty, string.Empty, int.MaxValue);

            result.Succeeded.Should().BeTrue();
        }

        [Fact]
        public async Task CreateUserAsync_Failed_ReturnsFailedResult()
        {
            var sut = new UserManagerService(TestUserManager.GetFailedManager());
            var (result, _) = await sut.CreateUserAsync(string.Empty, string.Empty, int.MaxValue);

            result.Succeeded.Should().BeFalse();
        }

        [Fact]
        public async Task AddToRoleAsync_UserFound_ReturnsSuccessResult()
        {
            var sut = new UserManagerService(TestUserManager.GetSuccessfulManager());
            var result = await sut.AddToRoleAsync(string.Empty, string.Empty);

            result.Succeeded.Should().BeTrue();
        }

        [Fact]
        public async Task AddToRoleAsync_UserNotFound_ReturnsFailedResult()
        {
            var sut = new UserManagerService(TestUserManager.GetFailedManager());
            var result = await sut.AddToRoleAsync(string.Empty, string.Empty);

            result.Succeeded.Should().BeFalse();
            result.Errors[0].Should().BeEquivalentTo("User not found.");
        }

        [Fact]
        public async Task AddToTeamAsync_UserFound_ReturnsSuccessResult()
        {
            var sut = new UserManagerService(TestUserManager.GetSuccessfulManager());
            var result = await sut.AddToTeamAsync(string.Empty, int.MaxValue);

            result.Succeeded.Should().BeTrue();
        }

        [Fact]
        public async Task AddToTeamAsync_UserNotFound_ReturnsFailedResult()
        {
            var sut = new UserManagerService(TestUserManager.GetFailedManager());
            var result = await sut.AddToTeamAsync(string.Empty, int.MaxValue);

            result.Succeeded.Should().BeFalse();
            result.Errors[0].Should().BeEquivalentTo("User not found.");
        }
    }

    internal sealed class TestUserManager : UserManager<ApplicationUser>
    {
        private readonly bool Success;

        public TestUserManager(bool success)
            : base(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null)
        {
            Success = success;
        }

        internal static TestUserManager GetSuccessfulManager() => new TestUserManager(true);
        internal static TestUserManager GetFailedManager() => new TestUserManager(false);
        private Task<IdentityResult> GetIdentityResultTask() => Task.FromResult(Success ? IdentityResult.Success : IdentityResult.Failed());

        public override Task<IdentityResult> CreateAsync(ApplicationUser role, string password) => GetIdentityResultTask();
        public override Task<ApplicationUser> FindByIdAsync(string userId) => Task.FromResult(Success ? new ApplicationUser() : null);
        public override Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role) => GetIdentityResultTask();
        public override Task<IdentityResult> UpdateAsync(ApplicationUser user) => GetIdentityResultTask();
    }
}
