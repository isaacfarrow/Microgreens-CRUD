using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microgreens.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "StaffNames");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ShippingPrice = table.Column<decimal>(nullable: false),
                    DateIn = table.Column<DateTime>(nullable: false),
                    DateOut = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yields",
                columns: table => new
                {
                    YieldId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Yield = table.Column<decimal>(nullable: false),
                    CostPerTray = table.Column<decimal>(nullable: false),
                    ProductsId = table.Column<int>(nullable: false),
                    DateIn = table.Column<DateTime>(nullable: false),
                    DateOut = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yields", x => x.YieldId);
                    table.ForeignKey(
                        name: "FK_Yields_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SowRatesL",
                columns: table => new
                {
                    SowRatesId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SowWeight = table.Column<decimal>(nullable: false),
                    TraysPerPack = table.Column<int>(nullable: false),
                    CostPerTray = table.Column<decimal>(nullable: false),
                    ProductsId = table.Column<int>(nullable: false),
                    DateIn = table.Column<DateTime>(nullable: false),
                    DateOut = table.Column<DateTime>(nullable: false),
                    YieldId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SowRatesL", x => x.SowRatesId);
                    table.ForeignKey(
                        name: "FK_SowRatesL_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SowRatesL_Yields_YieldId",
                        column: x => x.YieldId,
                        principalTable: "Yields",
                        principalColumn: "YieldId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SowRatesL_ProductsId",
                table: "SowRatesL",
                column: "ProductsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SowRatesL_YieldId",
                table: "SowRatesL",
                column: "YieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Yields_ProductsId",
                table: "Yields",
                column: "ProductsId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SowRatesL");

            migrationBuilder.DropTable(
                name: "Yields");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.CreateTable(
                name: "StaffNames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Department = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    VisitorCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Business = table.Column<string>(nullable: true),
                    DateIn = table.Column<DateTime>(nullable: false),
                    DateOut = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    StaffNameId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visitors_StaffNames_StaffNameId",
                        column: x => x.StaffNameId,
                        principalTable: "StaffNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_StaffNameId",
                table: "Visitors",
                column: "StaffNameId");
        }
    }
}
