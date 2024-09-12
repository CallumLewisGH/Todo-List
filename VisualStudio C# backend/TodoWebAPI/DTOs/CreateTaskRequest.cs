namespace TodoWebAPI.DTOs
{
    public class CreateTaskRequest
    {
        public long todoListId { get; set; } = default;

        public string TaskName { get; set; } = string.Empty;

    }
}
