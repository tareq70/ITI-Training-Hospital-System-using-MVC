using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI_Training_Hospital_System.Migrations
{
    /// <inheritdoc />
    public partial class AddUserandAdminRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "441ace01-4c2d-4716-b17c-f8f367709c2d", "4f8bb54e-caf8-45e0-b547-9fe284b4f680", "Tarek", "TAREK" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "441ace01-4c2d-4716-b17c-f8f367709c2d");
        }
    }
}
