using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectEmployeeManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Email", "Name", "Phone", "PhotoPath", "department" },
                values: new object[,]
                {
                    { 1, "Example20@gmail.com", "Rami", "774574645", "", 0 },
                    { 2, "Example21@gmail.com", "Ali", "772451639", "", 2 },
                    { 3, "Example22@gmail.com", "Doha", "774574222", "", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
