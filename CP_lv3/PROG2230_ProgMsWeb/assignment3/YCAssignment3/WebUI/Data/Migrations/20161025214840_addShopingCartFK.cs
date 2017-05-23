using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebUI.Data.Migrations
{
    public partial class addShopingCartFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Customers_CustomerscustomerID",
                table: "ShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Orders_OrdersorderID",
                table: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_CustomerscustomerID",
                table: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_OrdersorderID",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "CustomerscustomerID",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "OrdersorderID",
                table: "ShoppingCart");

            migrationBuilder.AddColumn<string>(
                name: "OrderEmail",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustEmail",
                table: "Customers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "ShoppingCart",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_CartId",
                table: "ShoppingCart",
                column: "CartId",
                unique: true);

            migrationBuilder.AlterColumn<int>(
                name: "orderID",
                table: "Orders",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_orderID",
                table: "Orders",
                column: "orderID",
                unique: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Orders_ShoppingCart_orderID",
            //    table: "Orders",
            //    column: "orderID",
            //    principalTable: "ShoppingCart",
            //    principalColumn: "CartId",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ShoppingCart_Customers_CartId",
            //    table: "ShoppingCart",
            //    column: "CartId",
            //    principalTable: "Customers",
            //    principalColumn: "customerID",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShoppingCart_orderID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Customers_CartId",
                table: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_CartId",
                table: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_Orders_orderID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderEmail",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustEmail",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerscustomerID",
                table: "ShoppingCart",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrdersorderID",
                table: "ShoppingCart",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "ShoppingCart",
                nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_CustomerscustomerID",
                table: "ShoppingCart",
                column: "CustomerscustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_OrdersorderID",
                table: "ShoppingCart",
                column: "OrdersorderID");

            migrationBuilder.AlterColumn<int>(
                name: "orderID",
                table: "Orders",
                nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Customers_CustomerscustomerID",
                table: "ShoppingCart",
                column: "CustomerscustomerID",
                principalTable: "Customers",
                principalColumn: "customerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Orders_OrdersorderID",
                table: "ShoppingCart",
                column: "OrdersorderID",
                principalTable: "Orders",
                principalColumn: "orderID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
