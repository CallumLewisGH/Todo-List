namespace TodoWebAPI.DTOs
{
    public class UserDTO
    {
        public long Id { get; set; } = default;

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;


    }
}
