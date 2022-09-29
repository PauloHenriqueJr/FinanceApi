using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiStone.Migrations
{
    public partial class Iniciando2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balances_Accounts_AccountId1",
                table: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_Balances_AccountId1",
                table: "Balances");

            migrationBuilder.DropColumn(
                name: "AccountId1",
                table: "Balances");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Accounts");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_AccountId",
                table: "Balances",
                column: "AccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Balances_Accounts_AccountId",
                table: "Balances",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balances_Accounts_AccountId",
                table: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_Balances_AccountId",
                table: "Balances");

            migrationBuilder.AddColumn<int>(
                name: "AccountId1",
                table: "Balances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "Accounts",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Balances_AccountId1",
                table: "Balances",
                column: "AccountId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Balances_Accounts_AccountId1",
                table: "Balances",
                column: "AccountId1",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
