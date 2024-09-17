using TodoWebAPI.DTOs;
using TodoWebAPI.Entity;
using Microsoft.AspNetCore.Mvc;

namespace TodoWebAPI.Endpoints
{
    public static class TasksEndpoints
    {
        public static void MapTasksEndpoints(this IEndpointRouteBuilder app)
        {
            var taskGroup = app.MapGroup("/user/todoList/task/");

            taskGroup.MapPost("", async (dbContext dbContext, [FromBody] CreateTaskRequest request) =>
            {
                var task = new TaskDTO() { TaskName = request.TaskName, TodoListId = request.todoListId };

                await dbContext.Tasks.AddAsync(task);

                await dbContext.SaveChangesAsync();

                return Results.Created($"{task.Id}", task);
            });
            taskGroup.MapDelete("{id}", async (dbContext dbContext, [FromRoute] int id) =>
            {
                TaskDTO? task = dbContext.Tasks.FirstOrDefault(x => x.Id == id);

                if (task == null)
                {
                    return Results.NotFound();
                }

                dbContext.Tasks.Remove(task);

                await dbContext.SaveChangesAsync();


                return Results.Accepted("Items DELETED", task);
            });
        }

    }
}