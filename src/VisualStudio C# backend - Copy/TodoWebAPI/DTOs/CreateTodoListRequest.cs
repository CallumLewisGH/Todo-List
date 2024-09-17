namespace TodoWebAPI.DTOs
{
    public class CreateTodoListRequest
    {
        public int UserId { get; set; } = default;
        public string ListName { get; set; } = string.Empty;
    }
}
