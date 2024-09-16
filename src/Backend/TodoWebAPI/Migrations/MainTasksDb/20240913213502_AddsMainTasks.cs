using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoWebAPI.Migrations.MainTasksDb
{
    /// <inheritdoc />
    public partial class AddsMainTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainTasksDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TodoListId = table.Column<int>(type: "int", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainTasksDb", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MainTasksDb",
                columns: new[] { "Id", "TaskName", "TodoListId" },
                values: new object[] { 1, "TestTask", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainTasksDb");
        }
    }
}
