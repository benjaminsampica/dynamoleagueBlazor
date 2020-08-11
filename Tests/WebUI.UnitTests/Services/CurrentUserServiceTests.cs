using FluentAssertions;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebUI.Services;
using Xunit;

namespace WebUI.UnitTests.Services
{
    public class CurrentUserServiceTests
    {
        [Fact]
        public async Task GetTeamIdAsync_UserAuthenticated_ReturnsTeamIdOfOne()
        {
            var sut = new CurrentUserService(new FakeAuthenticationStateProvider(true));

            var result = await sut.GetTeamIdAsync();

            result.Should().Be(1);
        }

        [Fact]
        public async Task GetTeamIdAsync_UserNotAuthenticated_ReturnsZero()
        {
            var sut = new CurrentUserService(new FakeAuthenticationStateProvider(false));

            var result = await sut.GetTeamIdAsync();

            result.Should().Be(0);
        }
    }

    internal sealed class FakeAuthenticationStateProvider : AuthenticationStateProvider
    {
        private bool IsAuthenticated { get; }

        public FakeAuthenticationStateProvider(bool isAuthenticated)
        {
            IsAuthenticated = isAuthenticated;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (IsAuthenticated)
            {
                var fakeTeamIdClaim = new List<Claim>() { new Claim(nameof(ApplicationUser.TeamId), "1") };
                return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(fakeTeamIdClaim))));
            }

            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
        }
    }
}
