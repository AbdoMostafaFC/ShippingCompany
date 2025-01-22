using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingCompany.Migrations
{
    /// <inheritdoc />
    public partial class lastt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_orders_OrderId",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "orderItems");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_OrderId",
                table: "orderItems",
                newName: "IX_orderItems_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderItems",
                table: "orderItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItems_orders_OrderId",
                table: "orderItems",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItems_orders_OrderId",
                table: "orderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderItems",
                table: "orderItems");

            migrationBuilder.RenameTable(
                name: "orderItems",
                newName: "OrderItem");

            migrationBuilder.RenameIndex(
                name: "IX_orderItems_OrderId",
                table: "OrderItem",
                newName: "IX_OrderItem_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_orders_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
