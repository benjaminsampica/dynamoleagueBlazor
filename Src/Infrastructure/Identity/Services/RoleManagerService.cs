using Application.Common.Interfaces;
using Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Services
{
    public class RoleManagerService : IRoleManager
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleManagerService(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<Result> AddRoleAsync(string roleName)
        {
            var applicationRole = new ApplicationRole(roleName);

            var result = await _roleManager.CreateAsync(applicationRole);
            return result.ToApplicationResult();
        }
    }
}
