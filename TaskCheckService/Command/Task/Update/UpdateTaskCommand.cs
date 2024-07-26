namespace TaskCheckService.Command.Task.Update
{
    public class UpdateTaskCommand : ICommand
    {
        public long Id { get; set; }

        public long CategoryId { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public bool IsImportant { get; set; } = false;

        public bool IsCompleted { get; set; } = false;

        public DateTime DueDate { get; set; }

    }
}
