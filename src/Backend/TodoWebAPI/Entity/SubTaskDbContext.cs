using Microsoft.EntityFrameworkCore;
using TodoWebAPI.DTOs;


namespace TodoWebAPI.Entity
{
    public class SubTasksDbContext : DbContext
    {
        public SubTasksDbContext(DbContextOptions<SubTasksDbContext> options) : base(options)
        {
        }
        // Registered DB Model in OurHeroDbContext file
        public DbSet<SubTaskDTO> SubTaskDb { get; set; }

        /*
         OnModelCreating mainly used to configured our EF model
         And insert master data if required
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting a primary key in OurHero model
            modelBuilder.Entity<SubTaskDTO>().HasKey(x => x.Id);

            // Inserting record in OurHero table
            modelBuilder.Entity<SubTaskDTO>().HasData(
                new SubTaskDTO
                {
                    Id = 1,
                    TaskId = 1,
                    SubTaskName = "TestList"

                }
            );
        }
    }
}
