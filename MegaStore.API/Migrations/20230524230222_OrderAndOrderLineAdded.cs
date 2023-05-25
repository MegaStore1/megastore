using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class OrderAndOrderLineAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Orders_orderId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_mspProductLine_productLineId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_msstPlant_plantId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderLines",
                table: "OrderLines");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "msoOrder");

            migrationBuilder.RenameTable(
                name: "OrderLines",
                newName: "msoOrderLine");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_plantId",
                table: "msoOrder",
                newName: "IX_msoOrder_plantId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLines_productLineId",
                table: "msoOrderLine",
                newName: "IX_msoOrderLine_productLineId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLines_orderId",
                table: "msoOrderLine",
                newName: "IX_msoOrderLine_orderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_msoOrder",
                table: "msoOrder",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_msoOrderLine",
                table: "msoOrderLine",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_msoOrder_msstPlant_plantId",
                table: "msoOrder",
                column: "plantId",
                principalTable: "msstPlant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_msoOrderLine_msoOrder_orderId",
                table: "msoOrderLine",
                column: "orderId",
                principalTable: "msoOrder",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_msoOrderLine_mspProductLine_productLineId",
                table: "msoOrderLine",
                column: "productLineId",
                principalTable: "mspProductLine",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_msoOrder_msstPlant_plantId",
                table: "msoOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_msoOrderLine_msoOrder_orderId",
                table: "msoOrderLine");

            migrationBuilder.DropForeignKey(
                name: "FK_msoOrderLine_mspProductLine_productLineId",
                table: "msoOrderLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_msoOrderLine",
                table: "msoOrderLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_msoOrder",
                table: "msoOrder");

            migrationBuilder.RenameTable(
                name: "msoOrderLine",
                newName: "OrderLines");

            migrationBuilder.RenameTable(
                name: "msoOrder",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_msoOrderLine_productLineId",
                table: "OrderLines",
                newName: "IX_OrderLines_productLineId");

            migrationBuilder.RenameIndex(
                name: "IX_msoOrderLine_orderId",
                table: "OrderLines",
                newName: "IX_OrderLines_orderId");

            migrationBuilder.RenameIndex(
                name: "IX_msoOrder_plantId",
                table: "Orders",
                newName: "IX_Orders_plantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderLines",
                table: "OrderLines",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Orders_orderId",
                table: "OrderLines",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_mspProductLine_productLineId",
                table: "OrderLines",
                column: "productLineId",
                principalTable: "mspProductLine",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_msstPlant_plantId",
                table: "Orders",
                column: "plantId",
                principalTable: "msstPlant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
