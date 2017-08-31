using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SyonOnline.WebApi.Identity
{
    public class SyonApplicationUser : ClaimsIdentity
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserNameNormalized => UserName?.ToUpper();
        public string Email { get; set; }
        public string EmailNormalized => Email?.ToUpper();
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public bool TwoFactorEnabled { get; set; }
    }
}
