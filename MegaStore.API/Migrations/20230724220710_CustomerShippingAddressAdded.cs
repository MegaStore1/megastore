using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class CustomerShippingAddressAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "stateId",
                table: "mscCustomer",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "mscCustomerShippingAddress",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    firstName = table.Column<string>(type: "TEXT", nullable: false),
                    lastName = table.Column<string>(type: "TEXT", nullable: false),
                    address = table.Column<string>(type: "TEXT", nullable: false),
                    apartmentOrSuite = table.Column<string>(type: "TEXT", nullable: false),
                    city = table.Column<string>(type: "TEXT", nullable: false),
                    stateid = table.Column<int>(type: "INTEGER", nullable: false),
                    postalCode = table.Column<string>(type: "TEXT", nullable: false),
                    customerId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    creationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    updateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mscCustomerShippingAddress", x => x.id);
                    table.ForeignKey(
                        name: "FK_mscCustomerShippingAddress_mscCustomer_customerId",
                        column: x => x.customerId,
                        principalTable: "mscCustomer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mscCustomerShippingAddress_mscState_stateid",
                        column: x => x.stateid,
                        principalTable: "mscState",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mscCustomer_stateId",
                table: "mscCustomer",
                column: "stateId");

            migrationBuilder.CreateIndex(
                name: "IX_mscCustomerShippingAddress_customerId",
                table: "mscCustomerShippingAddress",
                column: "customerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mscCustomerShippingAddress_stateid",
                table: "mscCustomerShippingAddress",
                column: "stateid");

            migrationBuilder.AddForeignKey(
                name: "FK_mscCustomer_mscState_stateId",
                table: "mscCustomer",
                column: "stateId",
                principalTable: "mscState",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mscCustomer_mscState_stateId",
                table: "mscCustomer");

            migrationBuilder.DropTable(
                name: "mscCustomerShippingAddress");

            migrationBuilder.DropIndex(
                name: "IX_mscCustomer_stateId",
                table: "mscCustomer");

            migrationBuilder.DropColumn(
                name: "stateId",
                table: "mscCustomer");
        }
    }
}
