using Entity = TaskCheckStorage.Entities;
using TaskCheckStorage.Repository;

namespace TaskCheckService.Command.Category.Add
{
    public class AddCategoryCommandHandler : ICommandHandler<AddCategoryCommand>
    {
        private readonly ITaskRepository repository;

        public AddCategoryCommandHandler(ITaskRepository repository)
        {
            this.repository = repository;
        }

        public Result Handle(AddCategoryCommand command)
        {
            var validationResult = new AddCategoryCommandValidator().Validate(command);

            if (!validationResult.IsValid)
                return Result.Fail(validationResult);

            var category = new Entity.Category(command.UserId, command.Name);

            repository.AddCategory(category);

            return Result.Ok();
        }
    }
}
