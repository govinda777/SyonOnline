using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyonOnline.WebApi.Identity
{
    public class SyonApplicationRole
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleNameNormalized => RoleName?.ToUpper();
    }
}
