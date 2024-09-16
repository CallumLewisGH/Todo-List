using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoWebAPI.DTOs;
using TodoWebAPI.Entity;
using TodoWebAPI;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
// COMPLETE THE DELETES USING LINQ

var builder = WebApplication.CreateBuilder(args);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UsersDbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("TodoListConnectionString")), ServiceLifetime.Scoped);
builder.Services.AddDbContext<ListsDbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("TodoListConnectionString")), ServiceLifetime.Scoped);
builder.Services.AddDbContext<SubTasksDbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("TodoListConnectionString")), ServiceLifetime.Scoped);
builder.Services.AddDbContext<MainTasksDbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("TodoListConnectionString")), ServiceLifetime.Scoped);

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


//Converts Data into UserData
//recieves id from vue


//Route Handlers


//Users
app.MapGet("/user/input", (UsersDbContext dbContext, string Username, string Password) =>
{

    UserDTO? user = dbContext.UsersDb.FirstOrDefault(x => x.Username == Username);

    if (user?.Password == Hash.ToSHA256(Password + user?.Salt))
    {
        if (user != null)
        {
            return Results.Ok(user);
        }

        return Results.NotFound();
    }


    return Results.NotFound();

});
app.MapGet("/user/input/username", (UsersDbContext dbContext, string Username) =>
{

    UserDTO? user = dbContext.UsersDb.FirstOrDefault(x => x.Username == Username);
    {
        if (user != null)
        {
            return Results.Ok(user);
        }
    }

    return Results.NotFound();

});
app.MapGet("/user/{id}",  (UsersDbContext dbContext, [FromRoute] int id) =>
{
    UserDTO? user = dbContext.UsersDb.FirstOrDefault(x => x.Id == id);

    if (user == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(user);

});
app.MapGet("/user/data/{id}", ((ListsDbContext dbContextTD, MainTasksDbContext dbContextMT, SubTasksDbContext dbContextST, [FromRoute] int id) =>
{
    List<TodoListObjectDTO> ListDTO = TodoWebAPIDTO.MakesList(dbContextTD.TodoListDb.ToList(), dbContextMT.MainTasksDb.ToList(), dbContextST.SubTaskDb.ToList(), id);
    return ListDTO;
}));
app.MapPost("/user/", async (UsersDbContext dbContext, [FromBody] CreateUserRequest request) =>
{
    var salt = Guid.NewGuid().ToString();

    request.password = request.password + salt;

    var user = new UserDTO() {Password = Hash.ToSHA256(request.password), Username = request.username, Salt = salt};
    
    dbContext.UsersDb.Add(user);

    await dbContext.SaveChangesAsync();

    return Results.Created($"/user/{user.Id}", user);
});

//Todo Lists

app.MapPost("/user/todoList/", async (ListsDbContext dbContext, [FromBody] CreateTodoListRequest request) =>
{
    var list = new TodoListDTO() { UserId = request.UserId, ListName = request.ListName };

    dbContext.TodoListDb.Add(list);

    await dbContext.SaveChangesAsync();

    return Results.Created($"/user/todoList/{list.Id}", list);
});
app.MapDelete("/user/todoList/{id}", async (ListsDbContext dbContextTD, MainTasksDbContext dbContextMT, SubTasksDbContext dbContextST, [FromRoute] int id) =>
{
    TodoListDTO? todoList = dbContextTD.TodoListDb.FirstOrDefault(x => x.Id == id);

    if (todoList == null)
    {
        return Results.NotFound();
    }

    IEnumerable<TaskDTO> tasks =
        from task in dbContextMT.MainTasksDb
        where task.TodoListId == id
        select task;
    
    foreach (TaskDTO task in tasks)
    {
        IEnumerable<SubTaskDTO> SubTasks =
            from Subtask in dbContextST.SubTaskDb
            where Subtask.TaskId == task.Id
            select Subtask;

        foreach (SubTaskDTO subTask in SubTasks)
        {
            dbContextST.SubTaskDb.Remove(subTask);
        }

        dbContextMT.MainTasksDb.Remove(task);
    }


    dbContextTD.TodoListDb.Remove(todoList);

    await dbContextMT.SaveChangesAsync();
    await dbContextTD.SaveChangesAsync();
    await dbContextST.SaveChangesAsync();

    return Results.Accepted("Items Removed", todoList);

});

//Tasks

app.MapPost("/user/todoList/task/", async (MainTasksDbContext dbContext, [FromBody] CreateTaskRequest request) =>
{
    var task = new TaskDTO() {TaskName = request.TaskName, TodoListId = request.todoListId };

    dbContext.MainTasksDb.Add(task);

    await dbContext.SaveChangesAsync();

    return Results.Created($"/user/todoList/task/{task.Id}", task);
});
app.MapDelete("/user/todoList/task/{id}", async (MainTasksDbContext dbContextMT, SubTasksDbContext dbContextST, [FromRoute] int id) =>
{
    TaskDTO? task = dbContextMT.MainTasksDb.FirstOrDefault(x => x.Id == id);

    if (task == null)
    {
        return Results.NotFound();
    }


    IEnumerable<SubTaskDTO> subTasks =
        from subTask in dbContextST.SubTaskDb
        where subTask.TaskId == id
        select subTask;

    foreach (SubTaskDTO subTask in subTasks) 
    { 
        dbContextST.SubTaskDb.Remove(subTask); 
    }

    dbContextMT.MainTasksDb.Remove(task);

    await dbContextMT.SaveChangesAsync();
    await dbContextST.SaveChangesAsync();

    return Results.Accepted("Items DELETED", task);
});

//Sub Tasks

app.MapPost("/user/todoList/task/subtask/", async (SubTasksDbContext dbContext, [FromBody] CreateSubTaskRequest request) =>
{
    var subTask = new SubTaskDTO() { SubTaskName = request.SubTaskName, TaskId = request.TaskId };

    dbContext.SubTaskDb.Add(subTask);

    await dbContext.SaveChangesAsync();

    return Results.Created($"/user/todoList/task/subtask/{subTask.Id}", subTask);
});

// Running
app.Run();