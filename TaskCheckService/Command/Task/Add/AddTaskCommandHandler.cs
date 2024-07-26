using TaskCheckStorage.Entities;
using TaskCheckStorage.Repository;

namespace TaskCheckService.Command.Task.Add
{
    public class AddTaskCommandHandler : ICommandHandler<AddTaskCommand>
    {
        private readonly ITaskRepository repository;

        public AddTaskCommandHandler(ITaskRepository repository)
        {
            this.repository = repository;
        }

        public Result Handle(AddTaskCommand command)
        {
            var validationResult = new AddTaskCommandValidator().Validate(command);

            if (!validationResult.IsValid)
                return Result.Fail(validationResult);

            var Task = new UserTask(command.UserId, command.CategoryId, command.isImportant, command.isCompleted, command.Title, command.Description, 
                command.CreateDate, command.DueDate);

            repository.AddUserTask(Task);

            return Result.Ok();

        }
    }
}
