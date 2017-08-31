using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace SyonOnline.WebApi.Identity
{
    public class SyonRoleStore : IRoleStore<SyonApplicationRole>
    {
        private readonly List<SyonApplicationRole> _roles;

        public SyonRoleStore()
        {
            _roles = new List<SyonApplicationRole>();
        }

        public Task<IdentityResult> CreateAsync(SyonApplicationRole role, CancellationToken cancellationToken)
        {
            _roles.Add(role);

            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> UpdateAsync(SyonApplicationRole role, CancellationToken cancellationToken)
        {
            var match = _roles.FirstOrDefault(r => r.RoleId == role.RoleId);
            if (match != null)
            {
                match.RoleName = role.RoleName;

                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed());
            }
        }

        public Task<IdentityResult> DeleteAsync(SyonApplicationRole role, CancellationToken cancellationToken)
        {
            var match = _roles.FirstOrDefault(r => r.RoleId == role.RoleId);
            if (match != null)
            {
                _roles.Remove(match);

                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed());
            }
        }

        public Task<SyonApplicationRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            var role = _roles.FirstOrDefault(r => r.RoleId == roleId);

            return Task.FromResult(role);
        }

        public Task<SyonApplicationRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            var role = _roles.FirstOrDefault(r => String.Equals(r.RoleNameNormalized, normalizedRoleName, StringComparison.OrdinalIgnoreCase));

            return Task.FromResult(role);
        }

        public Task<string> GetRoleIdAsync(SyonApplicationRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.RoleId);
        }

        public Task<string> GetRoleNameAsync(SyonApplicationRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.RoleName);
        }

        public Task<string> GetNormalizedRoleNameAsync(SyonApplicationRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.RoleNameNormalized);
        }

        public Task SetRoleNameAsync(SyonApplicationRole role, string roleName, CancellationToken cancellationToken)
        {
            role.RoleName = roleName;

            return Task.FromResult(true);
        }

        public Task SetNormalizedRoleNameAsync(SyonApplicationRole role, string normalizedName, CancellationToken cancellationToken)
        {
            // Do nothing. In this simple example, the normalized name is generated from the role name.

            return Task.FromResult(true);
        }

        public void Dispose() { }
    }
}
