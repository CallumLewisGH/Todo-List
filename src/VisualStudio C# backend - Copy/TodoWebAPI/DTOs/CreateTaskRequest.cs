namespace TodoWebAPI.DTOs
{
    public class CreateTaskRequest
    {
        public int todoListId { get; set; } = default;

        public string TaskName { get; set; } = string.Empty;

    }
}
