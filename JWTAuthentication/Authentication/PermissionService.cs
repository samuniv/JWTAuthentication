using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthentication.Authentication;

public class PermissionService : IPermissionService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public PermissionService(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<HashSet<string>> GetPermissionsAsync(string userId)
    {
        /*ICollection<Role>[] roles = await _context.Set<User>()
            .Include(x => x.Roles)
            .ThenInclude(x => x.Permissions)
            .Where(x => x.Id == userId)
            .Select(x => x.Roles)
            .ToArrayAsync();*/

        /*return roles
            .SelectMany(x => x)
            .SelectMany(x => x.Permissions)
            .Select(x => x.Name)
            .ToHashSet();*/

        var roles = await _userManager.GetRolesAsync(new IdentityUser() { Id = userId });

        var roleIds = await _roleManager.FindByNameAsync(roles.First());

        /*var permissions = await _context.Set<RolePermission>()
            .Include(x => x.Permission)
            .Where(x => x.RoleId == roleIds.Id)
            .Select(x => x.Permission.Name)
            .ToHashSetAsync();*/

        var rolePermissions = await _context.RolePermissions
                        .Include(x => x.Permission)
                        .Select(x => x.Permission.Name)
                        .ToHashSetAsync();

        var userPermissions = await _context.UserPermissions
            .Include(x => x.Permission)
            .Where(x => x.UserId == userId)
            .Select(x => x.Permission.Name)
            .ToHashSetAsync();

        return rolePermissions.Union(userPermissions).ToHashSet();
    }
}