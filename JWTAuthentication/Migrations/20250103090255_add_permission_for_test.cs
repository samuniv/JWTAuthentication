using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JWTAuthentication.Migrations
{
    /// <inheritdoc />
    public partial class add_permission_for_test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "ViewWeather");

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "AccessTests" },
                    { 4, "ViewTests" },
                    { 5, "ViewTestById" },
                    { 6, "CreateTest" },
                    { 7, "UpdateTest" },
                    { 8, "DeleteTest" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 3, "15f636ea-7f79-49e0-be51-eea53a7727d6" },
                    { 4, "15f636ea-7f79-49e0-be51-eea53a7727d6" },
                    { 5, "15f636ea-7f79-49e0-be51-eea53a7727d6" },
                    { 6, "15f636ea-7f79-49e0-be51-eea53a7727d6" },
                    { 7, "15f636ea-7f79-49e0-be51-eea53a7727d6" },
                    { 8, "15f636ea-7f79-49e0-be51-eea53a7727d6" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 3, "15f636ea-7f79-49e0-be51-eea53a7727d6" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 4, "15f636ea-7f79-49e0-be51-eea53a7727d6" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 5, "15f636ea-7f79-49e0-be51-eea53a7727d6" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 6, "15f636ea-7f79-49e0-be51-eea53a7727d6" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 7, "15f636ea-7f79-49e0-be51-eea53a7727d6" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 8, "15f636ea-7f79-49e0-be51-eea53a7727d6" });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "ReadWeather");
        }
    }
}
