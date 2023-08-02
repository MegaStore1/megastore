using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class UniqueConstraintAddedToCustomerAndUserEmailFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_msuUser_Email",
                table: "msuUser",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mscCustomer_email",
                table: "mscCustomer",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_msuUser_Email",
                table: "msuUser");

            migrationBuilder.DropIndex(
                name: "IX_mscCustomer_email",
                table: "mscCustomer");
        }
    }
}
