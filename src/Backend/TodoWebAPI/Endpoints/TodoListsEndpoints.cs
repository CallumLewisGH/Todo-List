using TodoWebAPI.DTOs;
using TodoWebAPI.Entity;
using Microsoft.AspNetCore.Mvc;
using TodoWebAPI.ObjectMaps;
using System.Collections.Generic;

namespace TodoWebAPI.Endpoints
{
    public static class TodoListsEndpoints
    {
        public static void MapTodoListEndpoints(this IEndpointRouteBuilder app)
        {
            var todoListGroup = app.MapGroup("/user/todoList");
            todoListGroup.MapPost("", async (dbContext dbContext, [FromBody] CreateTodoListRequest request) =>
            {
                var list = new TodoListDBO() { UserId = request.UserId, ListName = request.ListName };

                await dbContext.TodoLists.AddAsync(list);

                await dbContext.SaveChangesAsync();

                var retList = Maps.TodoList(list);

                return Results.Created($"{retList.Id}", retList);
            });
            todoListGroup.MapDelete("{id}", async (dbContext dbContext, [FromRoute] int id) =>
            {
                TodoListDBO? todoList = dbContext.TodoLists.FirstOrDefault(x => x.Id == id);


                if (todoList == null)
                {
                    return Results.NotFound();
                }

                dbContext.TodoLists.Remove(todoList);

                await dbContext.SaveChangesAsync();

                var retList = Maps.TodoList(todoList);

                return Results.Accepted("Items Removed", retList);

            });

        }
    }
}
