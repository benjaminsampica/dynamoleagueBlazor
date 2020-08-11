using Application.Common.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebUI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly AuthenticationStateProvider _provider;

        public CurrentUserService(AuthenticationStateProvider provider)
        {
            _provider = provider;
        }

        public async Task<int> GetTeamIdAsync()
        {
            var result = await _provider.GetAuthenticationStateAsync();
            var teamIdString = result?.User?.FindFirstValue(nameof(ApplicationUser.TeamId));
            int.TryParse(teamIdString, out int teamidInt);

            return teamidInt;
        }
    }
}
