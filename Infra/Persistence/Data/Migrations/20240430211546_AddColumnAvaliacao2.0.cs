using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Persistence.Data.Migrations
{
    public partial class AddColumnAvaliacao20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Avaliacao",
                table: "serie",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Avaliacao",
                table: "livro",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Avaliacao",
                table: "filme",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avaliacao",
                table: "serie");

            migrationBuilder.DropColumn(
                name: "Avaliacao",
                table: "livro");

            migrationBuilder.DropColumn(
                name: "Avaliacao",
                table: "filme");
        }
    }
}
