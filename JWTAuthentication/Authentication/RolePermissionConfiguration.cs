using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JWTAuthentication.Authentication;

internal sealed class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable("RolePermissions");

        builder.HasKey(x => new { x.RoleId, x.PermissionId });

        builder.HasData(
            new RolePermission { RoleId = "15f636ea-7f79-49e0-be51-eea53a7727d6", PermissionId = (int)PermissionEnum.AccessWeather },
            new RolePermission { RoleId = "15f636ea-7f79-49e0-be51-eea53a7727d6", PermissionId = (int)PermissionEnum.ReadWeather });
    }
}
