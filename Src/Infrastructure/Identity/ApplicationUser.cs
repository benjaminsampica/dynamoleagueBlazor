using Application.Common.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser, IApplicationUser
    {
        public ApplicationUser() { }
        public ApplicationUser(string userName, string email, int teamId) : base(userName)
        {
            TeamId = teamId;
            Email = email;
        }

        public int TeamId { get; set; }
    }
}
