using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApp.Migrations
{
    /// <inheritdoc />
    public partial class IdentityRoleSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "daabdfda-a133-4124-b4b8-40b8a326ff28", null, "Admin", "ADMIN" },
                    { "dd9846a7-c6e0-4721-a1bb-9b603e3ede9c", null, "Editor", "EDITOR" },
                    { "ec4643b4-6386-486d-9cfa-241393d57ca4", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "daabdfda-a133-4124-b4b8-40b8a326ff28");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd9846a7-c6e0-4721-a1bb-9b603e3ede9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec4643b4-6386-486d-9cfa-241393d57ca4");
        }
    }
}
