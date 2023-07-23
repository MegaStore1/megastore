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
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
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
                    status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mscModule", x => x.id);
                });

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
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msstCompany", x => x.id);
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
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
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
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
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
                name: "mscCustomer",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fullName = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    passwordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    passwordSalt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    companyId = table.Column<int>(type: "INTEGER", nullable: true),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mscCustomer", x => x.id);
                    table.ForeignKey(
                        name: "FK_mscCustomer_msstCompany_companyId",
                        column: x => x.companyId,
                        principalTable: "msstCompany",
                        principalColumn: "id");
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
                    stateId = table.Column<int>(type: "INTEGER", nullable: false),
                    companyId = table.Column<int>(type: "INTEGER", nullable: false),
                    status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msstPlant", x => x.id);
                    table.ForeignKey(
                        name: "FK_msstPlant_mscState_stateId",
                        column: x => x.stateId,
                        principalTable: "mscState",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_msstPlant_msstCompany_companyId",
                        column: x => x.companyId,
                        principalTable: "msstCompany",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "msoOrder",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    customerId = table.Column<int>(type: "INTEGER", nullable: false),
                    plantId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msoOrder", x => x.id);
                    table.ForeignKey(
                        name: "FK_msoOrder_mscCustomer_customerId",
                        column: x => x.customerId,
                        principalTable: "mscCustomer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_msoOrder_msstPlant_plantId",
                        column: x => x.plantId,
                        principalTable: "msstPlant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mspCategory",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    categoryName = table.Column<string>(type: "TEXT", nullable: false),
                    plantId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
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

            migrationBuilder.CreateTable(
                name: "mspColor",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    colorName = table.Column<string>(type: "TEXT", nullable: false),
                    plantId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mspColor", x => x.id);
                    table.ForeignKey(
                        name: "FK_mspColor_msstPlant_plantId",
                        column: x => x.plantId,
                        principalTable: "msstPlant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    plantId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msuUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_msuUser_msstPlant_plantId",
                        column: x => x.plantId,
                        principalTable: "msstPlant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mspProduct",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    productName = table.Column<string>(type: "TEXT", nullable: false),
                    categoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    colorId = table.Column<int>(type: "INTEGER", nullable: true),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mspProduct", x => x.id);
                    table.ForeignKey(
                        name: "FK_mspProduct_mspCategory_categoryId",
                        column: x => x.categoryId,
                        principalTable: "mspCategory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mspProduct_mspColor_colorId",
                        column: x => x.colorId,
                        principalTable: "mspColor",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "mssUserRoles",
                columns: table => new
                {
                    userId = table.Column<int>(type: "INTEGER", nullable: false),
                    pageId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
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
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
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
                name: "mspProductFile",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fileName = table.Column<string>(type: "TEXT", nullable: false),
                    fileType = table.Column<string>(type: "TEXT", nullable: false),
                    fileLength = table.Column<long>(type: "INTEGER", nullable: false),
                    contentType = table.Column<string>(type: "TEXT", nullable: false),
                    productId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mspProductFile", x => x.id);
                    table.ForeignKey(
                        name: "FK_mspProductFile_mspProduct_productId",
                        column: x => x.productId,
                        principalTable: "mspProduct",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mspProductLine",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    amount = table.Column<int>(type: "INTEGER", nullable: false),
                    price = table.Column<double>(type: "REAL", nullable: false),
                    salePrice = table.Column<double>(type: "REAL", nullable: false),
                    productId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mspProductLine", x => x.id);
                    table.ForeignKey(
                        name: "FK_mspProductLine_mspProduct_productId",
                        column: x => x.productId,
                        principalTable: "mspProduct",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "msoOrderLine",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    price = table.Column<double>(type: "REAL", nullable: false),
                    discount = table.Column<double>(type: "REAL", nullable: false),
                    amount = table.Column<int>(type: "INTEGER", nullable: false),
                    orderId = table.Column<int>(type: "INTEGER", nullable: false),
                    productLineId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msoOrderLine", x => x.id);
                    table.ForeignKey(
                        name: "FK_msoOrderLine_msoOrder_orderId",
                        column: x => x.orderId,
                        principalTable: "msoOrder",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_msoOrderLine_mspProductLine_productLineId",
                        column: x => x.productLineId,
                        principalTable: "mspProductLine",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mscCustomer_companyId",
                table: "mscCustomer",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_mscModulePage_moduleId",
                table: "mscModulePage",
                column: "moduleId");

            migrationBuilder.CreateIndex(
                name: "IX_mscState_countryId",
                table: "mscState",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_msoOrder_customerId",
                table: "msoOrder",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_msoOrder_plantId",
                table: "msoOrder",
                column: "plantId");

            migrationBuilder.CreateIndex(
                name: "IX_msoOrderLine_orderId",
                table: "msoOrderLine",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_msoOrderLine_productLineId",
                table: "msoOrderLine",
                column: "productLineId");

            migrationBuilder.CreateIndex(
                name: "IX_mspCategory_plantId",
                table: "mspCategory",
                column: "plantId");

            migrationBuilder.CreateIndex(
                name: "IX_mspColor_plantId",
                table: "mspColor",
                column: "plantId");

            migrationBuilder.CreateIndex(
                name: "IX_mspProduct_categoryId",
                table: "mspProduct",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_mspProduct_colorId",
                table: "mspProduct",
                column: "colorId");

            migrationBuilder.CreateIndex(
                name: "IX_mspProductFile_productId",
                table: "mspProductFile",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_mspProductLine_productId",
                table: "mspProductLine",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_msstPlant_companyId",
                table: "msstPlant",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_msstPlant_stateId",
                table: "msstPlant",
                column: "stateId");

            migrationBuilder.CreateIndex(
                name: "IX_mssUserRoles_userId",
                table: "mssUserRoles",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_msuPhoto_UserId",
                table: "msuPhoto",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_msuUser_plantId",
                table: "msuUser",
                column: "plantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "msoOrderLine");

            migrationBuilder.DropTable(
                name: "mspProductFile");

            migrationBuilder.DropTable(
                name: "mssUserRoles");

            migrationBuilder.DropTable(
                name: "msuPhoto");

            migrationBuilder.DropTable(
                name: "msoOrder");

            migrationBuilder.DropTable(
                name: "mspProductLine");

            migrationBuilder.DropTable(
                name: "mscModulePage");

            migrationBuilder.DropTable(
                name: "msuUser");

            migrationBuilder.DropTable(
                name: "mscCustomer");

            migrationBuilder.DropTable(
                name: "mspProduct");

            migrationBuilder.DropTable(
                name: "mscModule");

            migrationBuilder.DropTable(
                name: "mspCategory");

            migrationBuilder.DropTable(
                name: "mspColor");

            migrationBuilder.DropTable(
                name: "msstPlant");

            migrationBuilder.DropTable(
                name: "mscState");

            migrationBuilder.DropTable(
                name: "msstCompany");

            migrationBuilder.DropTable(
                name: "mscCountry");
        }
    }
}
