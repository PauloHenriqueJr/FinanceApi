using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiStone.Migrations
{
    public partial class Iniciando3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "Accounts",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Accounts");
        }
    }
}
