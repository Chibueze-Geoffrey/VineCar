using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VineCar.Migrations
{
    /// <inheritdoc />
    public partial class seeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    BrandId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cars_brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "brands",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "A BRAND THAT DOES IT ALL", "Mercedes" },
                    { 2, "A BRAND THAT HAS ALL THE REQUIREMENTS", "BMW" },
                    { 3, "A BRAND JUST FOR YOU", "HONDA" },
                    { 4, "A BRAND THAT REPRESENTS", "TOYOTA" }
                });

            migrationBuilder.InsertData(
                table: "cars",
                columns: new[] { "Id", "BrandId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 100, 1, "A Car with essential requirements", "GLK350", 20000000m },
                    { 101, 1, "Durable and efficient", "Mercedes100", 1500000m },
                    { 102, 2, "A Car Known for its uniqueness", "X6", 19000000m },
                    { 103, 2, "Exotic with distinct properties", "X7", 23000000m },
                    { 104, 3, "A Car with essentials", "Honda200", 1000000m },
                    { 105, 3, "A Car That is efficient and worthy", "Honda-Civic", 1500000m },
                    { 106, 4, "A Car with Robust features", "Camry200", 0m },
                    { 107, 4, "A Car with a pocket friendly price", "Corolla112", 900000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_BrandId",
                table: "cars",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "brands");
        }
    }
}
