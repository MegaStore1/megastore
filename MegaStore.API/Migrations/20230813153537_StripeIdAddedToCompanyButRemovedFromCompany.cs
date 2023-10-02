using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class StripeIdAddedToCompanyButRemovedFromCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "stripeId",
                table: "msstCompany");

            migrationBuilder.AddColumn<string>(
                name: "stripeId",
                table: "msstPlant",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "stripeId",
                table: "msstPlant");

            migrationBuilder.AddColumn<string>(
                name: "stripeId",
                table: "msstCompany",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
