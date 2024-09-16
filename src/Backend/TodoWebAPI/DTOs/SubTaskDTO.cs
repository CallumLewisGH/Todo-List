namespace TodoWebAPI.DTOs
{
    public class SubTaskDTO
    {
        public int Id { get; set; } = default;

        public int TaskId { get; set; } = default;

        public string SubTaskName { get; set; } = string.Empty;

    }
}
