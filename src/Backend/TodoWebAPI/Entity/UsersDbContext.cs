using Microsoft.EntityFrameworkCore;
using TodoWebAPI.DTOs;


namespace TodoWebAPI.Entity
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }
        // Registered DB Model in OurHeroDbContext file
        public DbSet<UserDTO> UsersDb { get; set; }

        /*
         OnModelCreating mainly used to configured our EF model
         And insert master data if required
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting a primary key in OurHero model
            modelBuilder.Entity<UserDTO>().HasKey(x => x.Id);

            // Inserting record in OurHero table
            modelBuilder.Entity<UserDTO>().HasData(
                new UserDTO
                {
                    Salt = "SALT",
                    Id = 1,
                    Username = "Test",
                    Password = "Test"
                }
            );
        }
    }
}
