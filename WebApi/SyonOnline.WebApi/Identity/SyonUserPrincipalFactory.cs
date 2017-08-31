using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace SyonOnline.WebApi.Identity
{
    public class SyonUserPrincipalFactory : IUserClaimsPrincipalFactory<SyonApplicationUser>
    {
        private readonly IdentityOptions _options;

        public SyonUserPrincipalFactory(IOptions<IdentityOptions> optionsAccessor)
        {
            _options = optionsAccessor?.Value ?? new IdentityOptions();
        }

        public Task<ClaimsPrincipal> CreateAsync(SyonApplicationUser user)
        {
            var identity = new ClaimsIdentity(
                _options.Cookies.ApplicationCookieAuthenticationScheme,
                _options.ClaimsIdentity.UserNameClaimType,
                _options.ClaimsIdentity.RoleClaimType);

            identity.AddClaim(new Claim(_options.ClaimsIdentity.UserIdClaimType, user.UserId));
            identity.AddClaim(new Claim(_options.ClaimsIdentity.UserNameClaimType, user.UserName));

            var principal = new ClaimsPrincipal(identity);

            return Task.FromResult(principal);
        }
    }
}
