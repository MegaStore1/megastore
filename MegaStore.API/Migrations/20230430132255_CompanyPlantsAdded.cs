using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class CompanyPlantsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "msstCompany",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    companyName = table.Column<string>(type: "TEXT", nullable: false),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msstCompany", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "msstPlant",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    plantName = table.Column<string>(type: "TEXT", nullable: false),
                    lat = table.Column<long>(type: "INTEGER", nullable: false),
                    lng = table.Column<long>(type: "INTEGER", nullable: false),
                    compnayId = table.Column<int>(type: "INTEGER", nullable: false),
                    companyid = table.Column<int>(type: "INTEGER", nullable: false),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msstPlant", x => x.id);
                    table.ForeignKey(
                        name: "FK_msstPlant_msstCompany_companyid",
                        column: x => x.companyid,
                        principalTable: "msstCompany",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_msstPlant_companyid",
                table: "msstPlant",
                column: "companyid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "msstPlant");

            migrationBuilder.DropTable(
                name: "msstCompany");
        }
    }
}
