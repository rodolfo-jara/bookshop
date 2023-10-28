using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bookshop.Services.CuponAPI.Migrations
{
    /// <inheritdoc />
    public partial class SetCuponToble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cupons",
                columns: new[] { "CuponId", "CodigoCupon", "Descuento", "MinCanti" },
                values: new object[,]
                {
                    { 1, "100FF", 10.0, 20 },
                    { 2, "200FF", 20.0, 40 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cupons",
                keyColumn: "CuponId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cupons",
                keyColumn: "CuponId",
                keyValue: 2);
        }
    }
}
