using TaskCheckStorage.Repository;

namespace TaskCheckService.Command.Task.Update
{
    public class UpdateTaskCommandHandler : ICommandHandler<UpdateTaskCommand>
    {
        private readonly TaskRepository repository;

        public UpdateTaskCommandHandler(TaskRepository repository)
        {
            this.repository = repository;
        }

        public Result Handle(UpdateTaskCommand command)
        {
            var validationResult = new UpdateTaskCommandValidator().Validate(command);

            if (!validationResult.IsValid)
                return Result.Fail(validationResult);

            var task = repository.GetUserTaskById(command.Id);

            if (task is null)
                return Result.Fail("Task does not exist");

            task.Title = command.Title;
            task.Description = command.Description;
            task.CategoryId = command.CategoryId;
            task.IsImportant = command.IsImportant;
            task.IsCompleted = command.IsCompleted;
            task.DueDate = command.DueDate;

            repository.UpdateUserTask(task);

            return Result.Ok();

            
        }
    }
}
