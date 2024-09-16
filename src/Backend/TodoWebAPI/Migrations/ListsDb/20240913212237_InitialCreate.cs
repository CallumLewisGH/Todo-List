using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoWebAPI.Migrations.ListsDb
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoListDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ListName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoListDb", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TodoListDb",
                columns: new[] { "Id", "ListName", "UserId" },
                values: new object[] { 1, "TestList", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoListDb");
        }
    }
}
