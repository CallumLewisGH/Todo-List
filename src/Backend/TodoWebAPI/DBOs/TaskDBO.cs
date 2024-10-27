namespace TodoWebAPI.DTOs
{
    public class TaskDBO
    {
        public int Id { get; set; } = default;

        public string TaskName { get; set; } = string.Empty;

        //EF Relationships
        public int TodoListId { get; set; }  // Foreign Key
        public List<SubTaskDBO> SubTasks { get; set; }
    }
}
