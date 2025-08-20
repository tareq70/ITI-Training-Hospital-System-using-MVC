using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITI_Training_Hospital_System.Migrations
{
    /// <inheritdoc />
    public partial class AddUserandAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "441ace01-4c2d-4716-b17c-f8f367709c2d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "391285b2-ad38-49bf-b202-d3e55d8122dd", "2bee5f4e-d73c-43d6-8657-94c052c89c9e", "User", "USER" },
                    { "6cc2f622-1e16-4693-a51e-0d66c098788a", "778a17d0-c534-4e7d-bdf5-3410466bd498", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "391285b2-ad38-49bf-b202-d3e55d8122dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cc2f622-1e16-4693-a51e-0d66c098788a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "441ace01-4c2d-4716-b17c-f8f367709c2d", "4f8bb54e-caf8-45e0-b547-9fe284b4f680", "Tarek", "TAREK" });
        }
    }
}
