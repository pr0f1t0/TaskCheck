namespace TaskCheckService.Command.Task.Add
{
    public class AddTaskCommand : ICommand
    {
        public AddTaskCommand(long userId, long categoryId, string title, string? description, bool isImportant,
            bool isCompleted, DateTime createDate, DateTime dueDate)
        {
            UserId = userId;
            CategoryId = categoryId;
            Title = title;
            Description = description;
            this.isImportant = isImportant;
            this.isCompleted = isCompleted;
            CreateDate = createDate;
            DueDate = dueDate;
        }

        public long UserId { get; set; }
        public long CategoryId { get; set; }


        public string Title { get; set; }

        public string? Description { get; set; }

        public bool isImportant { get; set; } = false;

        public bool isCompleted { get; set; } = false;

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public DateTime DueDate { get; set; }

    }
}
