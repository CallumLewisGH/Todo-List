namespace TodoWebAPI.DTOs
{
    public class CreateSubTaskRequest
    {
        public int TaskId { get; set; } = default;

        public string SubTaskName { get; set; } = string.Empty;

    }
}
