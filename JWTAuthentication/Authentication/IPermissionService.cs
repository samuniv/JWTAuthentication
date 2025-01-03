using System.Collections.Generic;
using System.Threading.Tasks;

namespace JWTAuthentication.Authentication;

public interface IPermissionService
{
    Task<HashSet<string>> GetPermissionsAsync(string userId);
}
