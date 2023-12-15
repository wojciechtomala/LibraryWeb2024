using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryWeb2024.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addProductsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price50 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price100 = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Stanisław Wyspiański", "Dramat autorstwa Stanisława Wyspiańskiego, wystawiony po raz pierwszy w Teatrze Miejskim w Krakowie 16 marca 1901 roku w reżyserii Adolfa Walewskiego. Dramat ten uważany jest za jedno z najważniejszych dzieł epoki Młodej Polski; przyniósł on autorowi wielką sławę", "2847284301", 30m, 25m, 15m, 20m, "Wesele" },
                    { 2, "Stanisław Wyspiański", "Dramat autorstwa Stanisława Wyspiańskiego, wystawiony po raz pierwszy w Teatrze Miejskim w Krakowie 16 marca 1901 roku w reżyserii Adolfa Walewskiego. Dramat ten uważany jest za jedno z najważniejszych dzieł epoki Młodej Polski; przyniósł on autorowi wielką sławę", "2847284301", 30m, 25m, 15m, 20m, "Pan Tadeusz" },
                    { 3, "Stanisław Wyspiański", "Dramat autorstwa Stanisława Wyspiańskiego, wystawiony po raz pierwszy w Teatrze Miejskim w Krakowie 16 marca 1901 roku w reżyserii Adolfa Walewskiego. Dramat ten uważany jest za jedno z najważniejszych dzieł epoki Młodej Polski; przyniósł on autorowi wielką sławę", "2847284301", 30m, 25m, 15m, 20m, "Dziady cz III" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);
        }
    }
}
