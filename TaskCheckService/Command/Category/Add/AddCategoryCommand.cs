namespace TaskCheckService.Command.Category.Add
{
    public class AddCategoryCommand : ICommand
    {
        public long UserId { get; set; }

        public string Name { get; set; }
    }
}
