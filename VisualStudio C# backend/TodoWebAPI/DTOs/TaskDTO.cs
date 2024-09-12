namespace TodoWebAPI.DTOs
{
    public class TaskDTO
    {
        public long Id { get; set; } = default;

        public long TodoListId { get; set; } = default;

        public string TaskName { get; set; } = string.Empty;

    }
}
