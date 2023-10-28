using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bookshop.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class addProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Autor", "CategoriaName", "ImageUrl", "Name", "Precio" },
                values: new object[,]
                {
                    { 1, "León Tolstói ", "Clásicos", "https://th.bing.com/th/id/OIP.5s7sgEWKFdXkyfeb9AAFRgAAAA?pid=ImgDet&rs=1/602*402", "Guerra y paz (1864)", 99.0 },
                    { 2, "Julio Verne y Peter Holeinone ", "Aventura", "https://th.bing.com/th/id/R.a4f0e9791c5e8cd4420a166c458236c6?rik=wZALMIra17zTYA&riu=http%3a%2f%2f2.bp.blogspot.com%2f-0j8TFs-A-5s%2fUPaCPHWTtyI%2fAAAAAAAAAmo%2f473HjvPPjkk%2fs1600%2fLA-VUELTA-AL-MUNDO-EN-80-D%c3%8d.jpg&ehk=o7YW8POWHmb1qbAIwjxB4q%2bS4mldeJdS3DLqix4cpW8%3d&risl=&pid=ImgRaw&r=0/602*402", "La vuelta al mundo en ochenta días (1872)", 99.900000000000006 },
                    { 3, "J. R. R. Tolkien", "Fantasía", "https://archive.is/zxd7Q/3899704ff0b9fac95ed4a3513aab081f999c1565.jpg", "El señor de los anillos (1954)", 89.900000000000006 },
                    { 4, "Indro Montanelli y Roberto Gervaso", "Historia ", "https://infolibros.org/wp-content/uploads/2020/07/Historia-de-la-Edad-Media.jpg", "Breve historia del mundo (1936)", 90.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
