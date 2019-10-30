using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microgreens.Migrations
{
    public partial class SowRatesL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostPerTray",
                table: "Yields");

            migrationBuilder.DropColumn(
                name: "DateIn",
                table: "Yields");

            migrationBuilder.DropColumn(
                name: "DateOut",
                table: "Yields");

            migrationBuilder.DropColumn(
                name: "DateIn",
                table: "SowRatesL");

            migrationBuilder.DropColumn(
                name: "DateOut",
                table: "SowRatesL");

            migrationBuilder.DropColumn(
                name: "DateIn",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DateOut",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CostPerTray",
                table: "Yields",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateIn",
                table: "Yields",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOut",
                table: "Yields",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateIn",
                table: "SowRatesL",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOut",
                table: "SowRatesL",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateIn",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOut",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
