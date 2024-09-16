﻿namespace TodoWebAPI.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Salt { get; set; } = string.Empty;

    }
}
