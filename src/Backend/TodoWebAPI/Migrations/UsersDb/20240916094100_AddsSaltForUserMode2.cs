using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoWebAPI.Migrations.UsersDb
{
    /// <inheritdoc />
    public partial class AddsSaltForUserMode2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "salt",
                table: "UsersDb",
                newName: "Salt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Salt",
                table: "UsersDb",
                newName: "salt");
        }
    }
}
