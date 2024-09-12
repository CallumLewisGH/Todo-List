namespace TodoWebAPI.DTOs
{
    public class TodoListDTO
    {
        public long Id { get; set; } = default;
        public long UserId { get; set; } = default;
        public string ListName { get; set; } = string.Empty;

    }
}
