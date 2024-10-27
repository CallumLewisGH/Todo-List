namespace TodoWebAPI.DTOs
{
    public class TodoListDTO
    {
        public int Id { get; set; } = default; //Primary Key

        public string ListName { get; set; } = string.Empty;

        public int UserId { get; set; }  // Foreign Key

    }
}
