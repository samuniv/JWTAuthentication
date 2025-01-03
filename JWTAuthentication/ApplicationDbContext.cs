using JWTAuthentication.Authentication;
using JWTAuthentication.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JWTAuthentication
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new PermissionConfiguration());

            builder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });

            builder.Entity<UserPermission>()
                .HasKey(up => new { up.UserId, up.PermissionId });

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "15f636ea-7f79-49e0-be51-eea53a7727d6", Name = "Admin", NormalizedName = "ADMIN" }
            );

            /*builder.Entity<RolePermission>().HasData(
                new RolePermission { RoleId = "15f636ea-7f79-49e0-be51-eea53a7727d6", PermissionId = (int)PermissionEnum.AccessWeather },
                new RolePermission { RoleId = "15f636ea-7f79-49e0-be51-eea53a7727d6", PermissionId = (int)PermissionEnum.ReadWeather });*/

            // Seed role permissions
            IEnumerable<Permission> permissions = Enum
                .GetValues<PermissionEnum>()
                .Select(p => new Permission
                {
                    Id = (int)p,
                    Name = p.ToString()
                });

            var rolePermissions = permissions.Select(p => new RolePermission
            {
                RoleId = "15f636ea-7f79-49e0-be51-eea53a7727d6",
                PermissionId = p.Id
            }).ToArray();

            builder.Entity<RolePermission>().HasData(rolePermissions);

        }

        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<Test> Tests { get; set; }
    }
}
