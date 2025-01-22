using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingCompany.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "UniqueNumber",
                table: "orders",
                newName: "SenderResidenceNumber");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "orders",
                newName: "SenderPhone");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "orders",
                newName: "SenderName");

            migrationBuilder.AddColumn<string>(
                name: "ReciverCity",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReciverName",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReciverPhone",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReciverRegion",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReciverStreet",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderCity",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumberItem = table.Column<int>(type: "int", nullable: false),
                    Wieght = table.Column<float>(type: "real", nullable: false),
                    CostOfWieght = table.Column<float>(type: "real", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropColumn(
                name: "ReciverCity",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "ReciverName",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "ReciverPhone",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "ReciverRegion",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "ReciverStreet",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "SenderCity",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "SenderResidenceNumber",
                table: "orders",
                newName: "UniqueNumber");

            migrationBuilder.RenameColumn(
                name: "SenderPhone",
                table: "orders",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "SenderName",
                table: "orders",
                newName: "CustomerName");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
