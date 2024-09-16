namespace TodoWebAPI.DTOs
{
    public class TaskDTO
    {
        public int Id { get; set; } = default;

        public int TodoListId { get; set; } = default;

        public string TaskName { get; set; } = string.Empty;

    }
}
