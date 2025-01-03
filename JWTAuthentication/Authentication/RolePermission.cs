using Microsoft.AspNetCore.Identity;

namespace JWTAuthentication.Authentication;

public class RolePermission
{
    public string RoleId { get; set; } // Use string type for RoleId
    public IdentityRole Role { get; set; }

    public int PermissionId { get; set; }
    public Permission Permission { get; set; }
}
