using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SyonOnline.WebApi.Identity
{
    public class SyonUserStore : IUserStore<SyonApplicationUser>,
                                    IUserEmailStore<SyonApplicationUser>,
                                    IUserPasswordStore<SyonApplicationUser>,
                                    IUserLoginStore<SyonApplicationUser>,
                                    IUserPhoneNumberStore<SyonApplicationUser>,
                                    IUserTwoFactorStore<SyonApplicationUser>
    {
        private static readonly List<SyonApplicationUser> _users = new List<SyonApplicationUser>();

        public Task<IdentityResult> CreateAsync(SyonApplicationUser user, CancellationToken cancellationToken)
        {
            user.UserId = Guid.NewGuid().ToString();

            _users.Add(user);

            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> UpdateAsync(SyonApplicationUser user, CancellationToken cancellationToken)
        {
            var match = _users.FirstOrDefault(u => u.UserId == user.UserId);
            if (match != null)
            {
                match.UserName = user.UserName;
                match.Email = user.Email;
                match.PhoneNumber = user.PhoneNumber;
                match.TwoFactorEnabled = user.TwoFactorEnabled;
                match.PasswordHash = user.PasswordHash;

                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed());
            }
        }

        public Task<IdentityResult> DeleteAsync(SyonApplicationUser user, CancellationToken cancellationToken)
        {
            var match = _users.FirstOrDefault(u => u.UserId == user.UserId);
            if (match != null)
            {
                _users.Remove(match);

                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed());
            }
        }

        public Task<SyonApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            var user = _users.FirstOrDefault(u => u.UserId == userId);

            return Task.FromResult(user);
        }

        public Task<SyonApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var user = _users.FirstOrDefault(u => String.Equals(u.UserNameNormalized, normalizedUserName, StringComparison.OrdinalIgnoreCase));

            return Task.FromResult(user);
        }

        public Task<string> GetUserIdAsync(SyonApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserId);
        }

        public Task<string> GetUserNameAsync(SyonApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task<string> GetNormalizedUserNameAsync(SyonApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserNameNormalized);
        }

        public Task SetEmailAsync(SyonApplicationUser user, string email, CancellationToken cancellationToken)
        {
            user.Email = email;

            return Task.CompletedTask;
        }

        public Task<string> GetEmailAsync(SyonApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(SyonApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

        public Task SetEmailConfirmedAsync(SyonApplicationUser user, bool confirmed, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task<SyonApplicationUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            var user = _users.FirstOrDefault(u => String.Equals(u.EmailNormalized, normalizedEmail, StringComparison.OrdinalIgnoreCase));

            return Task.FromResult(user);
        }

        public Task<string> GetNormalizedEmailAsync(SyonApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.EmailNormalized);
        }

        public Task SetNormalizedEmailAsync(SyonApplicationUser user, string normalizedEmail, CancellationToken cancellationToken)
        {
            // Do nothing. In this simple example, the normalized email is generated from the email.

            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(SyonApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(SyonApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash != null);
        }

        public Task SetUserNameAsync(SyonApplicationUser user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;

            return Task.FromResult(true);
        }

        public Task SetNormalizedUserNameAsync(SyonApplicationUser user, string normalizedName, CancellationToken cancellationToken)
        {
            // Do nothing. In this simple example, the normalized user name is generated from the user name.

            return Task.FromResult(true);
        }

        public Task SetPasswordHashAsync(SyonApplicationUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;

            return Task.FromResult(true);
        }

        public Task<string> GetPhoneNumberAsync(SyonApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PhoneNumber);
        }

        public Task SetPhoneNumberAsync(SyonApplicationUser user, string phoneNumber, CancellationToken cancellationToken)
        {
            user.PhoneNumber = phoneNumber;

            return Task.FromResult(true);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(SyonApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PhoneNumberConfirmed);
        }

        public Task SetPhoneNumberConfirmedAsync(SyonApplicationUser user, bool confirmed, CancellationToken cancellationToken)
        {
            user.PhoneNumberConfirmed = confirmed;

            return Task.FromResult(true);
        }

        public Task SetTwoFactorEnabledAsync(SyonApplicationUser user, bool enabled, CancellationToken cancellationToken)
        {
            user.TwoFactorEnabled = enabled;

            return Task.FromResult(true);
        }

        public Task<bool> GetTwoFactorEnabledAsync(SyonApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.TwoFactorEnabled);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(SyonApplicationUser user, CancellationToken cancellationToken)
        {
            // Just returning an empty list because I don't feel like implementing this. You should get the idea though...
            IList<UserLoginInfo> logins = new List<UserLoginInfo>();
            return Task.FromResult(logins);
        }

        public Task<SyonApplicationUser> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddLoginAsync(SyonApplicationUser user, UserLoginInfo login, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(SyonApplicationUser user, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose() { }
    }
}
