using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebUI.Data.Migrations
{
    public partial class addCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerscustomerID = table.Column<int>(nullable: true),
                    OrdersorderID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_Customers_CustomerscustomerID",
                        column: x => x.CustomerscustomerID,
                        principalTable: "Customers",
                        principalColumn: "customerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_Orders_OrdersorderID",
                        column: x => x.OrdersorderID,
                        principalTable: "Orders",
                        principalColumn: "orderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartCartId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShoppingCartCartId",
                table: "Products",
                column: "ShoppingCartCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_CustomerscustomerID",
                table: "ShoppingCart",
                column: "CustomerscustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_OrdersorderID",
                table: "ShoppingCart",
                column: "OrdersorderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShoppingCart_ShoppingCartCartId",
                table: "Products",
                column: "ShoppingCartCartId",
                principalTable: "ShoppingCart",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShoppingCart_ShoppingCartCartId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShoppingCartCartId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShoppingCartCartId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingCart");
        }
    }
}
