using static TodoWebAPI.DTOs.UserDataDTO;
using TodoWebAPI.DTOs;
using Microsoft.Identity.Client;

namespace TodoWebAPI.ObjectMaps
{
    public static class Maps
    {
        public static UserDataDTO UserData(UserDBO user)
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

        public static UserDTO User(UserDBO dbUser)
        {
            UserDTO user = new UserDTO
            {
                Id = dbUser.Id,
                Username = dbUser.Username,
            };
            return user;
        }

        public static TodoListDTO TodoList(TodoListDBO dbTodoList)
        {
            TodoListDTO todoList = new TodoListDTO
            {
                Id= dbTodoList.Id,
                ListName = dbTodoList.ListName,
            };
            return todoList;
        }

        public static TaskDTO Task(TaskDBO dbTask)
        {
            TaskDTO task = new TaskDTO
            {
                Id = dbTask.Id,
                TaskName = dbTask.TaskName,
            };
            return task;
        }

        public static SubTaskDTO SubTask(SubTaskDBO dbSubTask)
        {
            SubTaskDTO subTask = new SubTaskDTO
            {
                Id = dbSubTask.Id,
                SubTaskName = dbSubTask.SubTaskName,
                TaskId = dbSubTask.TaskId,
            };
            return subTask;
        }
    }
}
