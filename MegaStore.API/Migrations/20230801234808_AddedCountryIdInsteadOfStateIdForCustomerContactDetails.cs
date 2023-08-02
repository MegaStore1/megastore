using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedCountryIdInsteadOfStateIdForCustomerContactDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mscCustomerContactDetail_mscState_stateId",
                table: "mscCustomerContactDetail");

            migrationBuilder.RenameColumn(
                name: "stateId",
                table: "mscCustomerContactDetail",
                newName: "countryId");

            migrationBuilder.RenameIndex(
                name: "IX_mscCustomerContactDetail_stateId",
                table: "mscCustomerContactDetail",
                newName: "IX_mscCustomerContactDetail_countryId");

            migrationBuilder.AddForeignKey(
                name: "FK_mscCustomerContactDetail_mscCountry_countryId",
                table: "mscCustomerContactDetail",
                column: "countryId",
                principalTable: "mscCountry",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mscCustomerContactDetail_mscCountry_countryId",
                table: "mscCustomerContactDetail");

            migrationBuilder.RenameColumn(
                name: "countryId",
                table: "mscCustomerContactDetail",
                newName: "stateId");

            migrationBuilder.RenameIndex(
                name: "IX_mscCustomerContactDetail_countryId",
                table: "mscCustomerContactDetail",
                newName: "IX_mscCustomerContactDetail_stateId");

            migrationBuilder.AddForeignKey(
                name: "FK_mscCustomerContactDetail_mscState_stateId",
                table: "mscCustomerContactDetail",
                column: "stateId",
                principalTable: "mscState",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
