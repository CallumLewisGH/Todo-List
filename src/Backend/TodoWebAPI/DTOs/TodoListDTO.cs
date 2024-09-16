namespace TodoWebAPI.DTOs
{
    public class TodoListDTO
    {
        public int Id { get; set; } = default;
        public int UserId { get; set; } = default;
        public string ListName { get; set; } = string.Empty;

    }
}
