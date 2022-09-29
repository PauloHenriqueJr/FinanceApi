using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiStone.Migrations
{
    public partial class Iniciando6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalanceId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Saldo",
                table: "Accounts");

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedAt",
                table: "Deposits",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosedAt",
                table: "Deposits");

            migrationBuilder.AddColumn<int>(
                name: "BalanceId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Saldo",
                table: "Accounts",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
