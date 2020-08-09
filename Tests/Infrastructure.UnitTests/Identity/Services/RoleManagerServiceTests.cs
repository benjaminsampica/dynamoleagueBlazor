using FluentAssertions;
using Infrastructure.Identity;
using Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Infrastructure.UnitTests.Identity.Services
{
    public class RoleManagerServiceTests
    {
        [Fact]
        public async Task AddRoleAsync_Successful_ReturnsSuccessResult()
        {
            var sut = new RoleManagerService(TestRoleManager.GetSuccessfulManager());
            var result = await sut.AddRoleAsync(string.Empty);

            result.Succeeded.Should().BeTrue();
        }

        [Fact]
        public async Task AddRoleAsync_Failed_ReturnsFailedResult()
        {
            var sut = new RoleManagerService(TestRoleManager.GetFailedManager());
            var result = await sut.AddRoleAsync(string.Empty);

            result.Succeeded.Should().BeFalse();
        }
    }

    internal sealed class TestRoleManager : RoleManager<ApplicationRole>
    {
        private readonly bool Success;

        public TestRoleManager(bool success)
            : base(Mock.Of<IRoleStore<ApplicationRole>>(), null, null, null, null)
        {
            Success = success;
        }

        internal static TestRoleManager GetSuccessfulManager() => new TestRoleManager(true);
        internal static TestRoleManager GetFailedManager() => new TestRoleManager(false);
        private Task<IdentityResult> GetIdentityResultTask() => Task.FromResult(Success ? IdentityResult.Success : IdentityResult.Failed());

        public override Task<IdentityResult> CreateAsync(ApplicationRole role) => GetIdentityResultTask();
    }
}
