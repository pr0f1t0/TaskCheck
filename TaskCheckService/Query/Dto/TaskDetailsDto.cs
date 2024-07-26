namespace TaskCheckService.Query.Dto
{
    public class TaskDetailsDto
    {
        public TaskDetailsDto(long userId, long categoryId, string title, string? description, bool isImportant, bool isCompleted,
            DateTime dueDate)
        {
            UserId = userId;
            CategoryId = categoryId;
            Title = title;
            Description = description;
            IsImportant = isImportant;
            IsCompleted = isCompleted;
            DueDate = dueDate;
        }
        public TaskDetailsDto() { }

        public long UserId { get; set; }
        public long CategoryId { get; set; }


        public string Title { get; set; }

        public string? Description { get; set; }

        public bool IsImportant { get; set; } = false;

        public bool IsCompleted { get; set; } = false;

        public DateTime CreateDate { get; } = DateTime.Now;

        public DateTime DueDate { get; set; }
    }
}
