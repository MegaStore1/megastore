using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class UserAndPlantExtendedToSupportStripe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "msuUser",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "msuUser",
                newName: "postalCode");

            migrationBuilder.RenameIndex(
                name: "IX_msuUser_Email",
                table: "msuUser",
                newName: "IX_msuUser_email");

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "msuUser",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "msuUser",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "line1",
                table: "msuUser",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "line2",
                table: "msuUser",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "stateId",
                table: "msuUser",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "line2",
                table: "msstPlant",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "registrationNumber",
                table: "msstPlant",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_msuUser_stateId",
                table: "msuUser",
                column: "stateId");

            migrationBuilder.AddForeignKey(
                name: "FK_msuUser_mscState_stateId",
                table: "msuUser",
                column: "stateId",
                principalTable: "mscState",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_msuUser_mscState_stateId",
                table: "msuUser");

            migrationBuilder.DropIndex(
                name: "IX_msuUser_stateId",
                table: "msuUser");

            migrationBuilder.DropColumn(
                name: "firstName",
                table: "msuUser");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "msuUser");

            migrationBuilder.DropColumn(
                name: "line1",
                table: "msuUser");

            migrationBuilder.DropColumn(
                name: "line2",
                table: "msuUser");

            migrationBuilder.DropColumn(
                name: "stateId",
                table: "msuUser");

            migrationBuilder.DropColumn(
                name: "registrationNumber",
                table: "msstPlant");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "msuUser",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "postalCode",
                table: "msuUser",
                newName: "Username");

            migrationBuilder.RenameIndex(
                name: "IX_msuUser_email",
                table: "msuUser",
                newName: "IX_msuUser_Email");

            migrationBuilder.AlterColumn<string>(
                name: "line2",
                table: "msstPlant",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
