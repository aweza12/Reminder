using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reminder.DL.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "GuardName", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 8, 19, 8, 9, 12, DateTimeKind.Local).AddTicks(7098), "SuperAdmin", "SuperAdmin", null },
                    { 2, new DateTime(2023, 7, 8, 19, 8, 9, 12, DateTimeKind.Local).AddTicks(7132), "Admin", "Admin", null },
                    { 3, new DateTime(2023, 7, 8, 19, 8, 9, 12, DateTimeKind.Local).AddTicks(7133), "User", "User", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CreatedAt", "DeletedAt", "Email", "FirstName", "IsDeleted", "LastName", "PasswordChangedAt", "PasswordHash", "PasswordSalt", "RoleId", "UpdatedAt", "Username", "Uuid" },
                values: new object[] { 1, (byte)1, new DateTime(2023, 7, 8, 19, 8, 9, 12, DateTimeKind.Local).AddTicks(7223), null, "aweza12@gmail.com", "SuperAdmin", false, "SuperAdmin", null, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 1, null, "SuperAdmin", new Guid("0914bb1a-f02c-40b9-b514-bb11a7efb546") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
