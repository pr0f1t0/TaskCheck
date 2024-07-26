using TaskCheckService.Query.Dto;
using TaskCheckStorage.Repository;

namespace TaskCheckService.Query.Task
{
    public class GetTaskQueryHandler : IQueryHandler<GetTaskQuery, TaskDetailsDto>
    {
        private readonly ITaskRepository taskRepository;

        public GetTaskQueryHandler(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public TaskDetailsDto Handle(GetTaskQuery query)
        {
            var task = taskRepository.GetUserTaskById(query.Id)
                ?? throw new NullReferenceException("This task does not exist.");

            return new TaskDetailsDto(task.UserId, task.CategoryId, task.Title, task.Description, task.IsImportant, task.IsCompleted, 
                task.DueDate);

        }
    }
}
