using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class NullStateAcceptableForCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mscCustomer_mscState_stateId",
                table: "mscCustomer");

            migrationBuilder.AlterColumn<int>(
                name: "stateId",
                table: "mscCustomer",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_mscCustomer_mscState_stateId",
                table: "mscCustomer",
                column: "stateId",
                principalTable: "mscState",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mscCustomer_mscState_stateId",
                table: "mscCustomer");

            migrationBuilder.AlterColumn<int>(
                name: "stateId",
                table: "mscCustomer",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_mscCustomer_mscState_stateId",
                table: "mscCustomer",
                column: "stateId",
                principalTable: "mscState",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
