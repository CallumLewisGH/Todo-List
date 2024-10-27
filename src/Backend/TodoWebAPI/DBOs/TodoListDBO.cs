namespace TodoWebAPI.DTOs
{
    public class TodoListDBO
    {
        public int Id { get; set; } = default; //Primary Key
        public string ListName { get; set; } = string.Empty;

        //EF Relationships
        public int UserId { get; set; }  // Foreign Key
        public List<TaskDBO> Tasks { get; set; }

    }
}
