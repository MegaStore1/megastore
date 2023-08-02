using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class ShippingAddressStateIDAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mscCustomerShippingAddress_mscState_stateid",
                table: "mscCustomerShippingAddress");

            migrationBuilder.RenameColumn(
                name: "stateid",
                table: "mscCustomerShippingAddress",
                newName: "stateId");

            migrationBuilder.RenameIndex(
                name: "IX_mscCustomerShippingAddress_stateid",
                table: "mscCustomerShippingAddress",
                newName: "IX_mscCustomerShippingAddress_stateId");

            migrationBuilder.AddForeignKey(
                name: "FK_mscCustomerShippingAddress_mscState_stateId",
                table: "mscCustomerShippingAddress",
                column: "stateId",
                principalTable: "mscState",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mscCustomerShippingAddress_mscState_stateId",
                table: "mscCustomerShippingAddress");

            migrationBuilder.RenameColumn(
                name: "stateId",
                table: "mscCustomerShippingAddress",
                newName: "stateid");

            migrationBuilder.RenameIndex(
                name: "IX_mscCustomerShippingAddress_stateId",
                table: "mscCustomerShippingAddress",
                newName: "IX_mscCustomerShippingAddress_stateid");

            migrationBuilder.AddForeignKey(
                name: "FK_mscCustomerShippingAddress_mscState_stateid",
                table: "mscCustomerShippingAddress",
                column: "stateid",
                principalTable: "mscState",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
