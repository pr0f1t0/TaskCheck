namespace TaskCheckService.Query.Dto
{
    public class TaskDto
    {
        public TaskDto(long id, string title, string? description, string duedate, bool isImportant, bool isCompleted)
        {
            Id = id;
            Title = title;
            Description = description;
            DueDate = duedate;
            IsCompleted = isCompleted;
            IsImportant = isImportant;
        }

        public long Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public bool IsImportant { get; set; }

        public string DueDate { get; set; }

        public bool IsCompleted { get; set; }

    }
}
