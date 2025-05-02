using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace all_the_beans.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPrimaryKeyAndAutoIncrementUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CoffeeBean",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(24)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Index = table.Column<int>(type: "int", nullable: false),
                    IsBeanOfTheDay = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Colour = table.Column<string>(type: "varchar(128)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(128)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "varchar(128)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeBean", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeBean_Colour",
                table: "CoffeeBean",
                column: "Colour");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeBean_Country",
                table: "CoffeeBean",
                column: "Country");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeBean_Index",
                table: "CoffeeBean",
                column: "Index",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeBean_Name",
                table: "CoffeeBean",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoffeeBean");
        }
    }
}
