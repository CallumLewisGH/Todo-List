using Microsoft.EntityFrameworkCore;
using TodoWebAPI.DTOs;

namespace TodoWebAPI.Entity
{

    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }

        // Define DbSets for your entities
        public DbSet<UserDTO> Users { get; set; }
        public DbSet<TodoListDTO> TodoLists { get; set; }
        public DbSet<TaskDTO> Tasks { get; set; }
        public DbSet<SubTaskDTO> SubTasks { get; set; }

        // Configure relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure one-to-many relationship between User and TodoList
            modelBuilder.Entity<UserDTO>()
                .HasMany(user => user.TodoLists)       // User has many TodoLists
                .WithOne()            // TodoList has one User
                .HasForeignKey(todoList => todoList.UserId)  // ForeignKey in TodoList entity is UserId
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TodoListDTO>()
               .HasMany(todoList => todoList.Tasks)       // TodoList has many Tasks
               .WithOne()            // Task has one TodoList
               .HasForeignKey(task => task.TodoListId)   // ForeignKey in Task entity is TodoListId
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TaskDTO>()
               .HasMany(task => task.SubTasks)       // Task has many SubTask
               .WithOne()            // SubTask has one TodoList
               .HasForeignKey(subTask => subTask.TaskId)   // ForeignKey in SubTask entity is TaskId
               .OnDelete(DeleteBehavior.Cascade);

        }
    }

}
