using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace all_the_beans.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLastBeanOfTheDayColumnAndIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ulong>(
                name: "LastBeanOfTheDayTime",
                table: "CoffeeBean",
                type: "bigint unsigned",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastBeanOfTheDayTime",
                table: "CoffeeBean");
        }
    }
}
