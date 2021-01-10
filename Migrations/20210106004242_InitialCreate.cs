using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaLoco.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    PizzaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Ingredients = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.PizzaId);
                });

            migrationBuilder.CreateTable(
                name: "PizzaBase",
                columns: table => new
                {
                    PizzaBaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaBase", x => x.PizzaBaseId);
                });

            migrationBuilder.CreateTable(
                name: "PizzaSize",
                columns: table => new
                {
                    PizzaSizeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaSize", x => x.PizzaSizeId);
                });

            migrationBuilder.CreateTable(
                name: "PizzaOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(nullable: false),
                    PizzaId = table.Column<int>(nullable: false),
                    PizzaBaseId = table.Column<int>(nullable: false),
                    PizzaSizeId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaOrder_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaOrder_PizzaBase_PizzaBaseId",
                        column: x => x.PizzaBaseId,
                        principalTable: "PizzaBase",
                        principalColumn: "PizzaBaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaOrder_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaOrder_PizzaSize_PizzaSizeId",
                        column: x => x.PizzaSizeId,
                        principalTable: "PizzaSize",
                        principalColumn: "PizzaSizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaOrder_ClientId",
                table: "PizzaOrder",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaOrder_PizzaBaseId",
                table: "PizzaOrder",
                column: "PizzaBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaOrder_PizzaId",
                table: "PizzaOrder",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaOrder_PizzaSizeId",
                table: "PizzaOrder",
                column: "PizzaSizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaOrder");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "PizzaBase");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "PizzaSize");
        }
    }
}
