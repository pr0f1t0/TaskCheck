namespace TaskCheckService.Command.Task.Remove
{
    public class RemoveTaskCommand : ICommand
    {
        public long Id { get; set; }

        public RemoveTaskCommand(long id)
        {
            Id = id;
        }
    }
}
