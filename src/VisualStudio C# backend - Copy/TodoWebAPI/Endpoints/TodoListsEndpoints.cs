using TodoWebAPI.DTOs;
using TodoWebAPI.Entity;
using Microsoft.AspNetCore.Mvc;

namespace TodoWebAPI.Endpoints
{
    public static class TodoListsEndpoints
    {
        public static void MapTodoListEndpoints(this IEndpointRouteBuilder app)
        {
            var todoListGroup = app.MapGroup("/user/todoList");
            todoListGroup.MapPost("", async (dbContext dbContext, [FromBody] CreateTodoListRequest request) =>
            {
                var list = new TodoListDTO() { UserId = request.UserId, ListName = request.ListName };

                await dbContext.TodoLists.AddAsync(list);

                await dbContext.SaveChangesAsync();

                return Results.Created($"{list.Id}", list);
            });
            todoListGroup.MapDelete("{id}", async (dbContext dbContext, [FromRoute] int id) =>
            {
                TodoListDTO? todoList = dbContext.TodoLists.FirstOrDefault(x => x.Id == id);

                if (todoList == null)
                {
                    return Results.NotFound();
                }

                dbContext.TodoLists.Remove(todoList);

                await dbContext.SaveChangesAsync();


                return Results.Accepted("Items Removed", todoList);

            });

        }
    }
}
