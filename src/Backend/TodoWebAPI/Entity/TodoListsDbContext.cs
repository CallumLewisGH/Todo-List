using Microsoft.EntityFrameworkCore;
using TodoWebAPI.DTOs;


namespace TodoWebAPI.Entity
{
    public class ListsDbContext : DbContext
    {
        public ListsDbContext(DbContextOptions<ListsDbContext> options) : base(options)
        {
        }
        // Registered DB Model in OurHeroDbContext file
        public DbSet<TodoListDTO> TodoListDb { get; set; }

        /*
         OnModelCreating mainly used to configured our EF model
         And insert master data if required
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting a primary key in OurHero model
            modelBuilder.Entity<TodoListDTO>().HasKey(x => x.Id);

            // Inserting record in OurHero table
            modelBuilder.Entity<TodoListDTO>().HasData(
                new TodoListDTO
                {
                    Id = 1,
                    UserId = 1,
                    ListName = "TestList"
                    
                }
            );
        }
    }
}