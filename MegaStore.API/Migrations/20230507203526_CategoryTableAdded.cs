using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class CategoryTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "msuUser",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "msuPhoto",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "msstCompany",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "mscState",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "mscModulePage",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "mscCountry",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "mspCategory",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    categoryName = table.Column<string>(type: "TEXT", nullable: false),
                    plantId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    status = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mspCategory", x => x.id);
                    table.ForeignKey(
                        name: "FK_mspCategory_msstPlant_plantId",
                        column: x => x.plantId,
                        principalTable: "msstPlant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mspCategory_plantId",
                table: "mspCategory",
                column: "plantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mspCategory");

            migrationBuilder.DropColumn(
                name: "status",
                table: "msuUser");

            migrationBuilder.DropColumn(
                name: "status",
                table: "msuPhoto");

            migrationBuilder.DropColumn(
                name: "status",
                table: "msstCompany");

            migrationBuilder.DropColumn(
                name: "status",
                table: "mscState");

            migrationBuilder.DropColumn(
                name: "status",
                table: "mscModulePage");

            migrationBuilder.DropColumn(
                name: "status",
                table: "mscCountry");
        }
    }
}
