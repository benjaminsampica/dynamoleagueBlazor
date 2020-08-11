using Application.Common.Interfaces;
using Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Services
{
    public class UserManagerService : IUserManager
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManagerService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password, int teamId)
        {
            var user = new ApplicationUser(userName, userName, teamId);

            var result = await _userManager.CreateAsync(user, password);

            return (result.ToApplicationResult(), user.Id);
        }

        public async Task<Result> AddToRoleAsync(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var result = user != null 
                ? await _userManager.AddToRoleAsync(user, role) 
                : IdentityResult.Failed(new IdentityError { Description = "User not found." });

            return result.ToApplicationResult();
        }

        public async Task<Result> AddToTeamAsync(string userId, int teamId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if(user == null) return IdentityResult.Failed(new IdentityError { Description = "User not found." }).ToApplicationResult();

            user.TeamId = teamId;
            var result = await _userManager.UpdateAsync(user);

            return result.ToApplicationResult();
        }
    }
}
