using Microsoft.AspNetCore.Authorization;

namespace JWTAuthentication.Authentication;

public sealed class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(PermissionEnum permission)
        : base(policy: permission.ToString())
    {
    }
}
