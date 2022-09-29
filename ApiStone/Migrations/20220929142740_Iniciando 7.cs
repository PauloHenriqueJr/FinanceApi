using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiStone.Migrations
{
    public partial class Iniciando7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Withdraws_Balances_BalanceId",
                table: "Withdraws");

            migrationBuilder.DropIndex(
                name: "IX_Withdraws_BalanceId",
                table: "Withdraws");

            migrationBuilder.DropColumn(
                name: "BalanceId",
                table: "Withdraws");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BalanceId",
                table: "Withdraws",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Withdraws_BalanceId",
                table: "Withdraws",
                column: "BalanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Withdraws_Balances_BalanceId",
                table: "Withdraws",
                column: "BalanceId",
                principalTable: "Balances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
