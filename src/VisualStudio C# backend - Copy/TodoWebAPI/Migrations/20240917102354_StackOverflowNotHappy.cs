using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class StackOverflowNotHappy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubTasks_Tasks_TaskDTOId",
                table: "SubTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TodoLists_TodoListDTOId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoLists_Users_UserDTOId",
                table: "TodoLists");

            migrationBuilder.DropIndex(
                name: "IX_TodoLists_UserDTOId",
                table: "TodoLists");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TodoListDTOId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_SubTasks_TaskDTOId",
                table: "SubTasks");

            migrationBuilder.DropColumn(
                name: "UserDTOId",
                table: "TodoLists");

            migrationBuilder.DropColumn(
                name: "TodoListDTOId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskDTOId",
                table: "SubTasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserDTOId",
                table: "TodoLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TodoListDTOId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskDTOId",
                table: "SubTasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoLists_UserDTOId",
                table: "TodoLists",
                column: "UserDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TodoListDTOId",
                table: "Tasks",
                column: "TodoListDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTasks_TaskDTOId",
                table: "SubTasks",
                column: "TaskDTOId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubTasks_Tasks_TaskDTOId",
                table: "SubTasks",
                column: "TaskDTOId",
                principalTable: "Tasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TodoLists_TodoListDTOId",
                table: "Tasks",
                column: "TodoListDTOId",
                principalTable: "TodoLists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoLists_Users_UserDTOId",
                table: "TodoLists",
                column: "UserDTOId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
