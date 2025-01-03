using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace JWTAuthentication.Authentication;

public sealed class Role : IdentityRole
{
    //public int Id { get; }
    //public string Name { get; }

    public static readonly Role Registered = new("daa1ac36-bbe6-4040-8e92-b9de631d325e", "Registered");

    public Role(string id, string name) : base()
    {
        Id = id;
        Name = name;
    }

    public ICollection<Permission> Permissions { get; set; }

    //public ICollection<User> Users { get; set; }
}
