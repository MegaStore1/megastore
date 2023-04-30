using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class StateStatusAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "msstPlant",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "msstPlant");
        }
    }
}
