using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class PlantAddedToCustomerInsteadOfCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mscCustomer_msstCompany_companyId",
                table: "mscCustomer");

            migrationBuilder.RenameColumn(
                name: "companyId",
                table: "mscCustomer",
                newName: "plantId");

            migrationBuilder.RenameIndex(
                name: "IX_mscCustomer_companyId",
                table: "mscCustomer",
                newName: "IX_mscCustomer_plantId");

            migrationBuilder.AddForeignKey(
                name: "FK_mscCustomer_msstPlant_plantId",
                table: "mscCustomer",
                column: "plantId",
                principalTable: "msstPlant",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mscCustomer_msstPlant_plantId",
                table: "mscCustomer");

            migrationBuilder.RenameColumn(
                name: "plantId",
                table: "mscCustomer",
                newName: "companyId");

            migrationBuilder.RenameIndex(
                name: "IX_mscCustomer_plantId",
                table: "mscCustomer",
                newName: "IX_mscCustomer_companyId");

            migrationBuilder.AddForeignKey(
                name: "FK_mscCustomer_msstCompany_companyId",
                table: "mscCustomer",
                column: "companyId",
                principalTable: "msstCompany",
                principalColumn: "id");
        }
    }
}
