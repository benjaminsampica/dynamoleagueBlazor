using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() { }
        public ApplicationRole(string roleName) : base(roleName) { }

        public const string Admin = "Admin";
        public const string User = "Admin";
    }
}
