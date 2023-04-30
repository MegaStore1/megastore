using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class StatePlantAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "stateId",
                table: "msstPlant",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_msstPlant_stateId",
                table: "msstPlant",
                column: "stateId");

            migrationBuilder.AddForeignKey(
                name: "FK_msstPlant_mscState_stateId",
                table: "msstPlant",
                column: "stateId",
                principalTable: "mscState",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_msstPlant_mscState_stateId",
                table: "msstPlant");

            migrationBuilder.DropIndex(
                name: "IX_msstPlant_stateId",
                table: "msstPlant");

            migrationBuilder.DropColumn(
                name: "stateId",
                table: "msstPlant");
        }
    }
}
