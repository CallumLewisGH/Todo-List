namespace TodoWebAPI.DTOs
{
    public class UserDataDTO
    {
        public class TodoListObjectDTO
        {
            public string ListName { get; set; } = string.Empty;
            public long ListId { get; set; } = default;
            public List<TodoListObject> TodoListObject { get; set; } = new List<TodoListObject>();
        }

        public class TodoListObject
        {
            public string MainItem { get; set; } = string.Empty;
            public long TaskId { get; set; } = default;
            public List<string> SubItemList { get; set; } = new List<string>();
        }

        public List<TodoListObjectDTO> TodoLists { get; set; } = new List<TodoListObjectDTO>();

    }
}