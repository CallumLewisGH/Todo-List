namespace TodoWebAPI.DTOs
{
    public class TaskDTO
    {
        public int Id { get; set; } = default;

        public string TaskName { get; set; } = string.Empty;

        public int TodoListId { get; set; }  // Foreign Key
    }
}
