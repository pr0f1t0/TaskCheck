namespace TaskCheckService.Command.Category.Remove
{
    public class RemoveCategoryCommand : ICommand
    {
        public long Id { get; set; }

        public RemoveCategoryCommand(long id) 
        {
            Id = id;
        }
    }
}
