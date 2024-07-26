namespace TaskCheckService.Command.Category.Update
{
    public class UpdateCategoryCommand : ICommand
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
