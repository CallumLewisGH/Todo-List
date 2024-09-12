namespace TodoWebAPI.DTOs
{
    public class CreateSubTaskRequest
    {
        public long TaskId { get; set; } = default;

        public string SubTaskName { get; set; } = string.Empty;

    }
}
