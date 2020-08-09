using Application.Common.Interfaces;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Services
{
    public class SeedIdentityService
    {
        private readonly IUserManager _userManager;
        private readonly IRoleManager _roleManager;

        public SeedIdentityService(IUserManager userManager, IRoleManager roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedDevelopmentEnvironmentAsync()
        {
            await _roleManager.AddRoleAsync(ApplicationRole.Admin);
            await _roleManager.AddRoleAsync(ApplicationRole.User);
            var (_, benUserId) = await _userManager.CreateUserAsync("benjamin.sampica@gmail.com", "hunter2");

            await _userManager.AddToRoleAsync(benUserId, ApplicationRole.Admin);
        }
    }
}
