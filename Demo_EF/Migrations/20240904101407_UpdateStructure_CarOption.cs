using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo_EF.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStructure_CarOption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOption", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Car__Car_Option",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car__Car_Option", x => new { x.CarId, x.OptionId });
                    table.ForeignKey(
                        name: "FK_Car__Car_Option_CarOption_OptionId",
                        column: x => x.OptionId,
                        principalTable: "CarOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car__Car_Option_Vrouvoum_CarId",
                        column: x => x.CarId,
                        principalTable: "Vrouvoum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CarOption",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Option 1" },
                    { 2, null, "Option 2" },
                    { 3, null, "Option 3" }
                });

            migrationBuilder.InsertData(
                table: "Car__Car_Option",
                columns: new[] { "CarId", "OptionId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car__Car_Option_OptionId",
                table: "Car__Car_Option",
                column: "OptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car__Car_Option");

            migrationBuilder.DropTable(
                name: "CarOption");
        }
    }
}
