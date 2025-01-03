using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace JWTAuthentication.Authentication
{
    public class User : IdentityUser
    {
        public ICollection<Role> Roles { get; set; }
    }
}
