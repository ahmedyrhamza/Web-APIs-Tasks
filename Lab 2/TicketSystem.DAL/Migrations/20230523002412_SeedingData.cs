using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Web App Development Department" },
                    { 2, "Mobile App Development Department" }
                });

            migrationBuilder.InsertData(
                table: "developers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Developer 1" },
                    { 2, "Developer 2" },
                    { 3, "Developer 3" },
                    { 4, "Developer 4" },
                    { 5, "Developer 5" },
                    { 6, "Developer 6" },
                    { 7, "Developer 7" },
                    { 8, "Developer 8" },
                    { 9, "Developer 9" },
                    { 10, "Developer 10" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "DepartmentId", "Description", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Very cool ticket", "Ticket 1 Title" },
                    { 2, 1, "weird bug", "Ticket 2 Title" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
