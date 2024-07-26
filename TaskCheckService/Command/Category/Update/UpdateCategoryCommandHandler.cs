using TaskCheckStorage.Repository;

namespace TaskCheckService.Command.Category.Update
{
    public class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand>
    {
        private readonly ITaskRepository repository;

        public UpdateCategoryCommandHandler(ITaskRepository repository)
        {
            this.repository = repository;
        }

        public Result Handle(UpdateCategoryCommand command)
        {
            var validationResult = new UpdateCategoryCommandValidator().Validate(command);

            if (!validationResult.IsValid)
                return Result.Fail(validationResult);

            var category = repository.GetCategoryById(command.Id);

            if (category is null)
                return Result.Fail("There is no such category");

            category.CategoryName = command.Name;

            repository.UpdateCategory(category);

            return Result.Ok();
        }

    }
}
