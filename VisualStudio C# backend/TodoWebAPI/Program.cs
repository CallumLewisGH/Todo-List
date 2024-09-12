using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using TodoWebAPI.DTOs;
using System.Linq;
using System.Threading.Tasks;




var builder = WebApplication.CreateBuilder(args);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:5173")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

// Enable CORS
app.UseCors("AllowSpecificOrigin");

List<UserDTO> users = new List<UserDTO>();
users.Add(new UserDTO { Id = 0, Username = "Callum", Password = "PASSWORD" });
users.Add(new UserDTO { Id = 1, Username = "NotCallum", Password = "NotPASSWORD" });

List<TodoListDTO> todoLists = new List<TodoListDTO>();


List<TaskDTO> taskLists = new List<TaskDTO>();


List<SubTaskDTO> subTaskList = new List<SubTaskDTO>();


//Converts Data into UserData
//recieves id from vue



//Route Handlers

//Users
app.MapGet("/user/input", (string Username, string Password) =>
{
    foreach (UserDTO user in users)
    {
        if (user.Username == Username && user.Password == Password)
        {
            return Results.Ok(user);
        }
    }
    return Results.NotFound();

});

app.MapGet("/user/input/username", (string Username) =>
{
    foreach (UserDTO user in users)
    {
        if (user.Username == Username)
        {
            return Results.Ok(user);
        }
    }
    return Results.NotFound();

});



app.MapGet("/user/{id}", ([FromRoute] long id) =>
{
    if (users.FindIndex(x => x.Id == id) == -1)
    {
        return Results.NotFound();
    }
    var returnUserObejct = users[users.FindIndex(x => x.Id == id)];

    return Results.Ok(returnUserObejct);

});
app.MapGet("/user/data/{id}", ([FromRoute] long id) => 
{ 
    List<TodoListObjectDTO> ListDTO = TodoWebAPIDTO.MakesList(todoLists, taskLists, subTaskList, id);
    return ListDTO;
});
app.MapPut("/user/{id}", ([FromRoute] long id, UserDTO request) =>
{
    if (users.FindIndex(x => x.Id == id) == -1)
    {
        return Results.NotFound();
    }
    users[users.FindIndex(x => x.Id == id)] =  request;

    return Results.Accepted();

});
app.MapPost("/user/", ([FromBody] CreateUserRequest request) => users.Add(new UserDTO() { Id = users.Count(), Password = request.password, Username = request.username}));
app.MapDelete("/user/{id}", ([FromRoute]long id) =>
{
    if (users.FindIndex(x => x.Id == id) == -1)
    {
        return Results.NotFound();
    }

    foreach (UserDTO user in users.FindAll(x => x.Id == id))
    {
        foreach(TodoListDTO todoList in todoLists.FindAll(x => x.UserId == user.Id)) 
        {
            foreach (TaskDTO task in taskLists.FindAll(x => x.TodoListId == todoList.Id))
            {
                subTaskList.RemoveAll(x => x.TaskId == task.Id);
            }

            todoLists.RemoveAll(x => x.UserId == user.Id);
        }
        users.Remove(user);
    }


    return Results.Accepted();

    
});

//Todo Lists

app.MapPut("/user/todoList/{id}", ([FromRoute] long id, TodoListDTO request) =>
{
    if (todoLists.FindIndex(x => x.Id == id) == -1)
    {
        return Results.NotFound();
    }
    todoLists[todoLists.FindIndex(x => x.Id == id)] = request;

    return Results.Accepted();

});
app.MapPost("/user/todoList/", ([FromBody] CreateTodoListRequest request) => todoLists.Add(new TodoListDTO() { Id = todoLists.Count(), UserId = request.UserId, ListName = request.ListName }));
app.MapDelete("/user/todoList/{id}", ([FromRoute] long id) =>
{
    if (todoLists.FindIndex(x => x.Id == id) == -1)
    {
        return Results.NotFound();
    }
    foreach (TodoListDTO todoList in todoLists.FindAll(x => x.Id == id))
    {
        foreach (TaskDTO task in taskLists.FindAll(x => x.TodoListId == todoList.Id))
        {
            subTaskList.RemoveAll(x => x.TaskId == task.Id);
        }

        taskLists.RemoveAll(x => x.TodoListId == todoList.Id);
        
        todoLists.Remove(todoList);
    }


    return Results.Accepted();

});

//Tasks

app.MapPut("/user/todoList/task/{id}", ([FromRoute] long id, TaskDTO request) =>
{
    if (taskLists.FindIndex(x => x.Id == id) == -1)
    {
        return Results.NotFound();
    }
    taskLists[taskLists.FindIndex(x => x.Id == id)] = request;

    return Results.Accepted();

});
app.MapPost("/user/todoList/task/", ([FromBody] CreateTaskRequest request) => taskLists.Add(new TaskDTO() { Id = taskLists.Count(), TodoListId = request.todoListId, TaskName = request.TaskName }));
app.MapDelete("/user/todoList/task/{id}", ([FromRoute] long id) =>
{
    if (taskLists.FindIndex(x => x.Id == id) == -1)
    {
        return Results.NotFound();
    }
    foreach (TaskDTO task in taskLists.FindAll(x => x.Id == id))
    {
        subTaskList.RemoveAll(x => x.TaskId == task.Id);

        taskLists.Remove(task);

    }

    return Results.Accepted();
});

//Sub Tasks

app.MapPut("/user/todoList/task/subtask/{id}", ([FromRoute] long id, SubTaskDTO request) =>
{
    if (subTaskList.FindIndex(x => x.Id == id) == -1)
    {
        return Results.NotFound();
    }
    subTaskList[subTaskList.FindIndex(x => x.Id == id)] = request;

    return Results.Accepted();

});
app.MapPost("/user/todoList/task/subtask/", ([FromBody] CreateSubTaskRequest request) => subTaskList.Add(new SubTaskDTO() { Id = subTaskList.Count(), TaskId = request.TaskId, SubTaskName = request.SubTaskName }));
app.MapDelete("/user/todoList/task/subtask/{id}", ([FromRoute] long id) =>
{
    if (subTaskList.FindIndex(x => x.Id == id) == -1)
    {
        return Results.NotFound();
    }
    subTaskList.RemoveAt(subTaskList.FindIndex(x => x.Id == id));

    return Results.Accepted();

});

// Running
app.Run();