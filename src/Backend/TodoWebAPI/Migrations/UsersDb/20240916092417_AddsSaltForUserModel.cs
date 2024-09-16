using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoWebAPI.Migrations.UsersDb
{
    /// <inheritdoc />
    public partial class AddsSaltForUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "salt",
                table: "UsersDb",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "UsersDb",
                keyColumn: "Id",
                keyValue: 1,
                column: "salt",
                value: "SALT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "salt",
                table: "UsersDb");
        }
    }
}
