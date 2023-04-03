using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class CountryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mscCountry",
                columns: table => new
                {
                    mscId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    mscCountryName = table.Column<string>(type: "TEXT", nullable: false),
                    mscCountryCode = table.Column<string>(type: "TEXT", nullable: false),
                    mscCreationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    mscCreationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mscCountry", x => x.mscId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mscCountry");
        }
    }
}
