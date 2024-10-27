namespace TodoWebAPI.DTOs
{
    public class SubTaskDTO
    {
        public int Id { get; set; }
        public string SubTaskName { get; set; } = string.Empty;
        public int TaskId { get; set; }  // Foreign Key
    }
}
