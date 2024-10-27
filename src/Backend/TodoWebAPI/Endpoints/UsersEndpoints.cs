using TodoWebAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using TodoWebAPI.Entity;
using Microsoft.AspNetCore.Mvc;
using TodoWebAPI.ObjectMaps;

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

                UserDBO? user = dbContext.Users.FirstOrDefault(x => x.Username == Username);

                if (user?.hashedPassword == Hash.ToSHA256(Password + user?.Salt))
                {
                    if (user != null)
                    {
                        var retUser = Maps.User(user);
                        return Results.Ok(retUser);
                    }

                    return Results.NotFound();
                }


                return Results.NotFound();

            });

            userGroup.MapGet("/username/", (dbContext dbContext, string Username) =>
            {

                UserDBO? user = dbContext.Users.FirstOrDefault(x => x.Username == Username);
                
                 if (user != null)
                 {
                    var retUser = Maps.User(user);
                    return Results.Ok(retUser);
                 }


                return Results.NotFound();

            });

            userGroup.MapGet("{id}", (dbContext dbContext, [FromRoute] int id) =>
            {
                UserDBO? user = dbContext.Users.FirstOrDefault(x => x.Id == id);

                if (user == null)
                {
                    return Results.NotFound();
                }
                var retUser = Maps.User(user);

                return Results.Ok(retUser);

            });

            userGroup.MapGet("data/{id}", async (dbContext dbContext, [FromRoute] int id) =>
            {
                var user = await dbContext.Users
                    .Include(u => u.TodoLists)
                    .ThenInclude(tl => tl.Tasks)
                    .ThenInclude(t => t.SubTasks)
                    .FirstOrDefaultAsync(u => u.Id == id);

                if (user == null)
                {
                    return Results.NotFound();
                }

                var retUser = Maps.UserData(user);

                return Results.Ok(retUser.TodoLists.ToArray());

            }).Produces<List<UserDataDTO.TodoListObjectDTO>>();

            userGroup.MapPost("", async (dbContext dbContext, [FromBody] CreateUserRequest request) =>
            {
                var salt = Guid.NewGuid().ToString();

                request.password = request.password + salt;

                var user = new UserDBO() { hashedPassword = Hash.ToSHA256(request.password), Username = request.username, Salt = salt };

                await dbContext.Users.AddAsync(user);

                await dbContext.SaveChangesAsync();

                var retUser = Maps.User(user);

                return Results.Created($"/user/{retUser.Id}", retUser);

            }).Produces<UserDBO>();
        }
    }
}
