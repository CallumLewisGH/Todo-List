namespace TodoWebAPI.DTOs
{
    public class CreateTodoListRequest
    {
        public long UserId { get; set; } = default;
        public string ListName { get; set; } = string.Empty;
    }
}
