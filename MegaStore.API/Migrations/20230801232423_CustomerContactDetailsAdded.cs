using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class CustomerContactDetailsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mscCustomerContactDetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    stateId = table.Column<int>(type: "INTEGER", nullable: false),
                    customerId = table.Column<int>(type: "INTEGER", nullable: false),
                    contact = table.Column<string>(type: "TEXT", nullable: false),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mscCustomerContactDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_mscCustomerContactDetail_mscCustomer_customerId",
                        column: x => x.customerId,
                        principalTable: "mscCustomer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mscCustomerContactDetail_mscState_stateId",
                        column: x => x.stateId,
                        principalTable: "mscState",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mscCustomerContactDetail_customerId",
                table: "mscCustomerContactDetail",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_mscCustomerContactDetail_stateId",
                table: "mscCustomerContactDetail",
                column: "stateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mscCustomerContactDetail");
        }
    }
}
