namespace TodoWebAPI.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; } //Primary Key
        public string Salt { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string hashedPassword { get; set; } = string.Empty;

        //EF Relationships
        public List<TodoListDTO> TodoLists { get; set;}

    }
}
