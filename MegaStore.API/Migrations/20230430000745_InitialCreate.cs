using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mscCountry",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    countryName = table.Column<string>(type: "TEXT", nullable: false),
                    countryCode = table.Column<string>(type: "TEXT", nullable: false),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mscCountry", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mscModule",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    moduleName = table.Column<string>(type: "TEXT", nullable: false),
                    status = table.Column<bool>(type: "INTEGER", nullable: false),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mscModule", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "msuUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msuUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mscState",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    stateCode = table.Column<string>(type: "TEXT", nullable: false),
                    stateName = table.Column<string>(type: "TEXT", nullable: false),
                    countryId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mscState", x => x.id);
                    table.ForeignKey(
                        name: "FK_mscState_mscCountry_countryId",
                        column: x => x.countryId,
                        principalTable: "mscCountry",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mscModulePage",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    pageName = table.Column<string>(type: "TEXT", nullable: false),
                    moduleId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mscModulePage", x => x.id);
                    table.ForeignKey(
                        name: "FK_mscModulePage_mscModule_moduleId",
                        column: x => x.moduleId,
                        principalTable: "mscModule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "msuPhoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    IsMain = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msuPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_msuPhoto_msuUser_UserId",
                        column: x => x.UserId,
                        principalTable: "msuUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mssUserRoles",
                columns: table => new
                {
                    userId = table.Column<int>(type: "INTEGER", nullable: false),
                    pageId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mssUserRoles", x => new { x.pageId, x.userId });
                    table.ForeignKey(
                        name: "FK_mssUserRoles_mscModulePage_pageId",
                        column: x => x.pageId,
                        principalTable: "mscModulePage",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mssUserRoles_msuUser_userId",
                        column: x => x.userId,
                        principalTable: "msuUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mscModulePage_moduleId",
                table: "mscModulePage",
                column: "moduleId");

            migrationBuilder.CreateIndex(
                name: "IX_mscState_countryId",
                table: "mscState",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_mssUserRoles_userId",
                table: "mssUserRoles",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_msuPhoto_UserId",
                table: "msuPhoto",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mscState");

            migrationBuilder.DropTable(
                name: "mssUserRoles");

            migrationBuilder.DropTable(
                name: "msuPhoto");

            migrationBuilder.DropTable(
                name: "mscCountry");

            migrationBuilder.DropTable(
                name: "mscModulePage");

            migrationBuilder.DropTable(
                name: "msuUser");

            migrationBuilder.DropTable(
                name: "mscModule");
        }
    }
}
