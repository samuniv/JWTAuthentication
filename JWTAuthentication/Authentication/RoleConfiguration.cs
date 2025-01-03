using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JWTAuthentication.Authentication;

internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");

        /*builder.Property(x => x.Name)
            .HasColumnName("Name")
            .IsRequired();*/

        builder.HasMany(x => x.Permissions)
            .WithMany()
            .UsingEntity<RolePermission>();

        /* builder.HasMany(x => x.Users)
             .WithMany(x => x.Roles);*/

        builder.HasData(
            new Role("15f636ea-7f79-49e0-be51-eea53a7727d6", "Registered"));
    }
}
