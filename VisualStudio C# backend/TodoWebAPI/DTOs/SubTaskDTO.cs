namespace TodoWebAPI.DTOs
{
    public class SubTaskDTO
    {
        public long Id { get; set; } = default;

        public long TaskId { get; set; } = default;

        public string SubTaskName { get; set; } = string.Empty;

    }
}
