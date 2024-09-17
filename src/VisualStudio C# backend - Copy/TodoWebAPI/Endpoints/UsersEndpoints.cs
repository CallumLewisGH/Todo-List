using TodoWebAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using TodoWebAPI.Entity;
using Microsoft.AspNetCore.Mvc;

namespace TodoWebAPI.Endpoints
{
    public static class UsersEndpoints
    {
        public static void MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            var userGroup = app.MapGroup("/user/");
            //Users
            userGroup.MapGet("/input/", (dbContext dbContext, string Username, string Password) =>
            {

                UserDTO? user = dbContext.Users.FirstOrDefault(x => x.Username == Username);

                if (user?.hashedPassword == Hash.ToSHA256(Password + user?.Salt))
                {
                    if (user != null)
                    {
                        return Results.Ok(user);
                    }

                    return Results.NotFound();
                }


                return Results.NotFound();

            });

            userGroup.MapGet("/username/", (dbContext dbContext, string Username) =>
            {

                UserDTO? user = dbContext.Users.FirstOrDefault(x => x.Username == Username);
                {
                    if (user != null)
                    {
                        return Results.Ok(user);
                    }
                }

                return Results.NotFound();

            });

            userGroup.MapGet("{id}", (dbContext dbContext, [FromRoute] int id) =>
            {
                UserDTO? user = dbContext.Users.FirstOrDefault(x => x.Id == id);

                if (user == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(user);

            });

            userGroup.MapGet("data/{id}", async (dbContext dbContext, [FromRoute] int id) =>
            {
                // Ensure that TodoLists, Tasks, and SubTasks are loaded with the UserDTO
                var user = await dbContext.Users
                    .Include(u => u.TodoLists)
                    .ThenInclude(tl => tl.Tasks)
                    .ThenInclude(t => t.SubTasks)
                    .FirstOrDefaultAsync(u => u.Id == id);

                if (user == null)
                {
                    return Results.NotFound();
                }

                // Use the mapping method to return a DTO
                var userDataDTO = UserDataDTO.FromUser(user);

                return Results.Ok(userDataDTO.TodoLists.ToArray());

            }).Produces<List<UserDataDTO.TodoListObjectDTO>>();

            userGroup.MapPost("", async (dbContext dbContext, [FromBody] CreateUserRequest request) =>
            {
                var salt = Guid.NewGuid().ToString();

                request.password = request.password + salt;

                var user = new UserDTO() { hashedPassword = Hash.ToSHA256(request.password), Username = request.username, Salt = salt };

                await dbContext.Users.AddAsync(user);

                await dbContext.SaveChangesAsync();

                return Results.Created($"/user/{user.Id}", user);
            }).Produces<UserDTO>();
        }
    }
}
