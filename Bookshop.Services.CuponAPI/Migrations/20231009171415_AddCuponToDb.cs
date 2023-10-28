using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookshop.Services.CuponAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCuponToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cupons",
                columns: table => new
                {
                    CuponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoCupon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descuento = table.Column<double>(type: "float", nullable: false),
                    MinCanti = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupons", x => x.CuponId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cupons");
        }
    }
}
