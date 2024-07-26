using TaskCheckStorage.Repository;

namespace TaskCheckService.Command.Category.Remove
{
    public class RemoveCategoryCommandHandler : ICommandHandler<RemoveCategoryCommand>
    {
        private readonly ITaskRepository repository;

        public RemoveCategoryCommandHandler(ITaskRepository repository)
        {
            this.repository = repository;
        }

        public Result Handle(RemoveCategoryCommand command)
        {
            var category = repository.GetCategoryById(command.Id);

            if (category is null)
                return Result.Fail("There is no such category");

            repository.RemoveCategory(command.Id);

            return Result.Ok();
        }
    }
}
