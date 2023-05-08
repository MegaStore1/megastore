using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class PlantColorRelationAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "plantId",
                table: "mspColor",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_mspColor_plantId",
                table: "mspColor",
                column: "plantId");

            migrationBuilder.AddForeignKey(
                name: "FK_mspColor_msstPlant_plantId",
                table: "mspColor",
                column: "plantId",
                principalTable: "msstPlant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mspColor_msstPlant_plantId",
                table: "mspColor");

            migrationBuilder.DropIndex(
                name: "IX_mspColor_plantId",
                table: "mspColor");

            migrationBuilder.DropColumn(
                name: "plantId",
                table: "mspColor");
        }
    }
}
