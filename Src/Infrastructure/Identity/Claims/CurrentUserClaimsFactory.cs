﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Claims
{
    public class CurrentUserClaimsFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        public CurrentUserClaimsFactory(
            UserManager<ApplicationUser> userManager,
            IOptions<IdentityOptions> optionsAccessor)
                : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            identity.AddClaim(new Claim(nameof(user.TeamId), user.TeamId.ToString()));

            return identity;
        }
    }
}
