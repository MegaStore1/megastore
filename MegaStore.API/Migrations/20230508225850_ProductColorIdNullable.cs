using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class ProductColorIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mspProduct_mspColor_colorId",
                table: "mspProduct");

            migrationBuilder.AlterColumn<int>(
                name: "colorId",
                table: "mspProduct",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_mspProduct_mspColor_colorId",
                table: "mspProduct",
                column: "colorId",
                principalTable: "mspColor",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mspProduct_mspColor_colorId",
                table: "mspProduct");

            migrationBuilder.AlterColumn<int>(
                name: "colorId",
                table: "mspProduct",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_mspProduct_mspColor_colorId",
                table: "mspProduct",
                column: "colorId",
                principalTable: "mspColor",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
