using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class UserExtended : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "role",
                table: "msuUser",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "accountNumber",
                table: "msstPlant",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "msstPlant",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "currency",
                table: "msstPlant",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "industry",
                table: "msstPlant",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "line1",
                table: "msstPlant",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "line2",
                table: "msstPlant",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "phoneNumber",
                table: "msstPlant",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "postalCode",
                table: "msstPlant",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "routingNumber",
                table: "msstPlant",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "taxId",
                table: "msstPlant",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "website",
                table: "msstPlant",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "msuUser");

            migrationBuilder.DropColumn(
                name: "accountNumber",
                table: "msstPlant");

            migrationBuilder.DropColumn(
                name: "city",
                table: "msstPlant");

            migrationBuilder.DropColumn(
                name: "currency",
                table: "msstPlant");

            migrationBuilder.DropColumn(
                name: "industry",
                table: "msstPlant");

            migrationBuilder.DropColumn(
                name: "line1",
                table: "msstPlant");

            migrationBuilder.DropColumn(
                name: "line2",
                table: "msstPlant");

            migrationBuilder.DropColumn(
                name: "phoneNumber",
                table: "msstPlant");

            migrationBuilder.DropColumn(
                name: "postalCode",
                table: "msstPlant");

            migrationBuilder.DropColumn(
                name: "routingNumber",
                table: "msstPlant");

            migrationBuilder.DropColumn(
                name: "taxId",
                table: "msstPlant");

            migrationBuilder.DropColumn(
                name: "website",
                table: "msstPlant");
        }
    }
}
