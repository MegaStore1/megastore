using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class CustomerFirstAndLastNamesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fullName",
                table: "mscCustomer");

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "mscCustomer",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "mscCustomer",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "firstName",
                table: "mscCustomer");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "mscCustomer");

            migrationBuilder.AddColumn<string>(
                name: "fullName",
                table: "mscCustomer",
                type: "TEXT",
                nullable: true);
        }
    }
}
