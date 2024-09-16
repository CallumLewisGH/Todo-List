using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SubTasksCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubTaskDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    SubTaskName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTaskDb", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SubTaskDb",
                columns: new[] { "Id", "SubTaskName", "TaskId" },
                values: new object[] { 1, "TestList", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubTaskDb");
        }
    }
}
