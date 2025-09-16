using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAutomoviles.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Automoviles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fabricacion = table.Column<int>(type: "int", nullable: false),
                    NumeroMotor = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumeroChasis = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automoviles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automoviles_NumeroChasis",
                table: "Automoviles",
                column: "NumeroChasis",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Automoviles_NumeroMotor",
                table: "Automoviles",
                column: "NumeroMotor",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automoviles");
        }
    }
}
