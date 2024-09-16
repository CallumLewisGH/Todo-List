using Microsoft.EntityFrameworkCore;
using TodoWebAPI.DTOs;


namespace TodoWebAPI.Entity
{
    public class MainTasksDbContext : DbContext
    {
        public MainTasksDbContext(DbContextOptions<MainTasksDbContext> options) : base(options)
        {
        }
        // Registered DB Model in OurHeroDbContext file
        public DbSet<TaskDTO> MainTasksDb { get; set; }

        /*
         OnModelCreating mainly used to configured our EF model
         And insert master data if required
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting a primary key in OurHero model
            modelBuilder.Entity<TaskDTO>().HasKey(x => x.Id);

            // Inserting record in OurHero table
            modelBuilder.Entity<TaskDTO>().HasData(
                new TaskDTO
                {
                    Id = 1,
                    TodoListId = 1,
                    TaskName = "TestTask"

                }
            );
        }
    }
}
