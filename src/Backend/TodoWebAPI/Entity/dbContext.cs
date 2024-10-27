using Microsoft.EntityFrameworkCore;
using TodoWebAPI.DTOs;

namespace TodoWebAPI.Entity
{

    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }

        // Define DbSets for your entities
        public DbSet<UserDBO> Users { get; set; }
        public DbSet<TodoListDBO> TodoLists { get; set; }
        public DbSet<TaskDBO> Tasks { get; set; }
        public DbSet<SubTaskDBO> SubTasks { get; set; }
        

        // Configure relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure one-to-many relationship between User and TodoList
            modelBuilder.Entity<UserDBO>()
                .HasMany(user => user.TodoLists)       // User has many TodoLists
                .WithOne()            // TodoList has one User
                .HasForeignKey(todoList => todoList.UserId)  // ForeignKey in TodoList entity is UserId
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TodoListDBO>()
               .HasMany(todoList => todoList.Tasks)       // TodoList has many Tasks
               .WithOne()            // Task has one TodoList
               .HasForeignKey(task => task.TodoListId)   // ForeignKey in Task entity is TodoListId
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TaskDBO>()
               .HasMany(task => task.SubTasks)       // Task has many SubTask
               .WithOne()            // SubTask has one TodoList
               .HasForeignKey(subTask => subTask.TaskId)   // ForeignKey in SubTask entity is TaskId
               .OnDelete(DeleteBehavior.Cascade);

        }
    }

}
