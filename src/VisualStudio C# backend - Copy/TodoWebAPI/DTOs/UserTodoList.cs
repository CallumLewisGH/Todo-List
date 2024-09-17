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

        public static UserDataDTO FromUser(UserDTO user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return new UserDataDTO
            {
                TodoLists = user.TodoLists?.Select(todoList => new TodoListObjectDTO
                {
                    ListName = todoList.ListName ?? string.Empty,
                    ListId = todoList.Id,
                    TodoListObject = todoList.Tasks?.Select(task => new TodoListObject
                    {
                        MainItem = task.TaskName ?? string.Empty,
                        TaskId = task.Id,
                        SubItemList = task.SubTasks?.Select(subTask => subTask.SubTaskName ?? string.Empty).ToList() ?? new List<string>()
                    }).ToList() ?? new List<TodoListObject>()
                }).ToList() ?? new List<TodoListObjectDTO>()
            };
        }
    }
}