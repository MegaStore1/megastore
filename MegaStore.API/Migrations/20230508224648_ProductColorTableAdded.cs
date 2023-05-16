using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class ProductColorTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "colorId",
                table: "mspProduct",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "mspColor",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    colorName = table.Column<string>(type: "TEXT", nullable: false),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mspColor", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mspProduct_colorId",
                table: "mspProduct",
                column: "colorId");

            migrationBuilder.AddForeignKey(
                name: "FK_mspProduct_mspColor_colorId",
                table: "mspProduct",
                column: "colorId",
                principalTable: "mspColor",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mspProduct_mspColor_colorId",
                table: "mspProduct");

            migrationBuilder.DropTable(
                name: "mspColor");

            migrationBuilder.DropIndex(
                name: "IX_mspProduct_colorId",
                table: "mspProduct");

            migrationBuilder.DropColumn(
                name: "colorId",
                table: "mspProduct");
        }
    }
}
