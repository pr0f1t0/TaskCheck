using TaskCheckStorage.Repository;

namespace TaskCheckService.Command.Task.Remove
{
    public class RemoveTaskCommandHandler : ICommandHandler<RemoveTaskCommand>
    {
        private readonly ITaskRepository repository;

        public RemoveTaskCommandHandler(ITaskRepository repository)
        {
            this.repository = repository;
        }

        public Result Handle(RemoveTaskCommand command)
        {
            var task = repository.GetUserTaskById(command.Id);

            if (task is null)
                return Result.Fail("Task does not exist");

            repository.RemoveUserTask(task.Id);

            return Result.Ok();
        }
    }
}
