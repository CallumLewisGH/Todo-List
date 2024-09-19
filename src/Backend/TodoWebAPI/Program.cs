using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoWebAPI.DTOs;
using TodoWebAPI.Entity;
using TodoWebAPI;
using TodoWebAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adds Database connection
builder.Services.AddDbContext<dbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("TodoListConnectionString")), ServiceLifetime.Scoped);


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

//Endpoints

app.MapUsersEndpoints();
app.MapTodoListEndpoints();
app.MapTasksEndpoints();
app.MapSubTasksEndpoints();

// Running
app.Run();