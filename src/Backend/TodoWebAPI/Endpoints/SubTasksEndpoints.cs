using TodoWebAPI.DTOs;
using TodoWebAPI.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoWebAPI.ObjectMaps;

namespace TodoWebAPI.Endpoints
{
    public static class SubTasksEndpoints
    {
        public static void MapSubTasksEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/user/todoList/task/subtask/", async (dbContext dbContext, [FromBody] CreateSubTaskRequest request) =>
            {
                var subTask = new SubTaskDBO() { SubTaskName = request.SubTaskName, TaskId = request.TaskId };

                await dbContext.SubTasks.AddAsync(subTask);

                await dbContext.SaveChangesAsync();

                var retSubTask = Maps.SubTask(subTask);

                return Results.Created($"/user/todoList/task/subtask/{retSubTask.Id}", subTask);
            });
        }
    }
}
