using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class UserPlantAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "plantId",
                table: "msuUser",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_msuUser_plantId",
                table: "msuUser",
                column: "plantId");

            migrationBuilder.AddForeignKey(
                name: "FK_msuUser_msstPlant_plantId",
                table: "msuUser",
                column: "plantId",
                principalTable: "msstPlant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_msuUser_msstPlant_plantId",
                table: "msuUser");

            migrationBuilder.DropIndex(
                name: "IX_msuUser_plantId",
                table: "msuUser");

            migrationBuilder.DropColumn(
                name: "plantId",
                table: "msuUser");
        }
    }
}
