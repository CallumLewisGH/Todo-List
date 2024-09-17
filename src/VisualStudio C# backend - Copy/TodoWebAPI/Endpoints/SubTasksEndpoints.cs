using TodoWebAPI.DTOs;
using TodoWebAPI.Entity;
using Microsoft.AspNetCore.Mvc;

namespace TodoWebAPI.Endpoints
{
    public static class SubTasksEndpoints
    {
        public static void MapSubTasksEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/user/todoList/task/subtask/", async (dbContext dbContext, [FromBody] CreateSubTaskRequest request) =>
            {
                var subTask = new SubTaskDTO() { SubTaskName = request.SubTaskName, TaskId = request.TaskId };
                await dbContext.SubTasks.AddAsync(subTask);

                await dbContext.SaveChangesAsync();

                return Results.Created($"/user/todoList/task/subtask/{subTask.Id}", subTask);
            });
        }
    }
}
