using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo_EF.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStructure_Brand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Vrouvoum",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[,]
                {
                    { 1, null, "Lada" },
                    { 2, null, "Audi" }
                });

            migrationBuilder.UpdateData(
                table: "Vrouvoum",
                keyColumn: "Id",
                keyValue: 1,
                column: "BrandId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vrouvoum",
                keyColumn: "Id",
                keyValue: 2,
                column: "BrandId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Vrouvoum_BrandId",
                table: "Vrouvoum",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Brand_Name_Country",
                table: "Brand",
                columns: new[] { "Name", "Country" },
                unique: true,
                filter: "[Country] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Vrouvoum_Brand_BrandId",
                table: "Vrouvoum",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vrouvoum_Brand_BrandId",
                table: "Vrouvoum");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_Vrouvoum_BrandId",
                table: "Vrouvoum");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Vrouvoum");
        }
    }
}
