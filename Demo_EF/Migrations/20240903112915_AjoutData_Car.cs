using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo_EF.Migrations
{
    /// <inheritdoc />
    public partial class AjoutData_Car : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vrouvoum",
                columns: new[] { "Id", "Model", "Price", "RegistrationDate", "State" },
                values: new object[,]
                {
                    { 1, "Samara", 199.99m, new DateTime(1987, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "R8 Spyder", 1930.5m, null, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vrouvoum",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vrouvoum",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
