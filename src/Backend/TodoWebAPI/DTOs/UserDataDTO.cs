using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace TodoWebAPI.DTOs
{
    public static class TodoWebAPIDTO
    {
        public static List<TodoListObjectDTO> MakesList(List<TodoListDTO> inputTodoLists, List<TaskDTO >inputTasks, List<SubTaskDTO> inputSubTasks, long inputId)
        {
            List<TodoListObjectDTO> returnList = [];

            foreach (TodoListDTO todoList in inputTodoLists)
            {


                if (todoList.UserId == inputId)
                {
                    TodoListObjectDTO TodoListObjectDTO = new TodoListObjectDTO();

                    TodoListObjectDTO.ListId = todoList.Id;
                    TodoListObjectDTO.ListName = todoList.ListName;
                    TodoListObjectDTO.TodoListObject = [];

                    foreach (TaskDTO task in inputTasks)
                    {
                        if (task.TodoListId == todoList.Id)
                        {
                            TodoListObject actTask = new TodoListObject();

                            actTask.TaskId = task.Id;
                            actTask.MainItem = task.TaskName;

                            foreach (SubTaskDTO subTask in inputSubTasks)
                            {
                                if (subTask.TaskId == task.Id)
                                {
                                    actTask.SubItemList.Add(subTask.SubTaskName);

                                }
                            }

                            TodoListObjectDTO.TodoListObject.Add(actTask);
                        }
                    }

                    returnList.Add(TodoListObjectDTO);
                }
            }
            return returnList;
        }
    }

    public class TodoListObjectDTO
    {
        public string ListName { get; set; } = string.Empty;

        public long ListId { get; set; } = default;
        public List<TodoListObject> TodoListObject { get; set; } = [];
    }

    public class TodoListObject
    {
        public string MainItem { get; set; } = string.Empty;

        public long TaskId { get; set; } = default;

        public List<string> SubItemList { get; set; } = [];
    }
}
