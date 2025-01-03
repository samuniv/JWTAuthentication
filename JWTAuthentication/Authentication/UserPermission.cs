using JWTAuthentication.Authentication;
using Microsoft.AspNetCore.Identity;

public class UserPermission
{
    public string UserId { get; set; }
    public IdentityUser User { get; set; }

    public int PermissionId { get; set; }
    public Permission Permission { get; set; }
}
