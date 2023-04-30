using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class DropedCompnayIdFromPlantTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_msstPlant_msstCompany_companyid",
                table: "msstPlant");

            migrationBuilder.DropColumn(
                name: "compnayId",
                table: "msstPlant");

            migrationBuilder.RenameColumn(
                name: "companyid",
                table: "msstPlant",
                newName: "companyId");

            migrationBuilder.RenameIndex(
                name: "IX_msstPlant_companyid",
                table: "msstPlant",
                newName: "IX_msstPlant_companyId");

            migrationBuilder.AddForeignKey(
                name: "FK_msstPlant_msstCompany_companyId",
                table: "msstPlant",
                column: "companyId",
                principalTable: "msstCompany",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_msstPlant_msstCompany_companyId",
                table: "msstPlant");

            migrationBuilder.RenameColumn(
                name: "companyId",
                table: "msstPlant",
                newName: "companyid");

            migrationBuilder.RenameIndex(
                name: "IX_msstPlant_companyId",
                table: "msstPlant",
                newName: "IX_msstPlant_companyid");

            migrationBuilder.AddColumn<int>(
                name: "compnayId",
                table: "msstPlant",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_msstPlant_msstCompany_companyid",
                table: "msstPlant",
                column: "companyid",
                principalTable: "msstCompany",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
