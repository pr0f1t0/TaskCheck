using TaskCheckService.Query.Dto;
using Entity = TaskCheckStorage.Entities;
using TaskCheckStorage.Repository;

namespace TaskCheckService.Query.Task
{
    public class GetAllTasksQueryHandler : IQueryHandler<GetAllTasksQuery, IEnumerable<TaskDto>>
    {
        private readonly ITaskRepository taskRepository;
        private readonly long userId;

        public GetAllTasksQueryHandler(ITaskRepository taskRepository, Entity.User user)
        {
            this.taskRepository = taskRepository;
            userId = user.Id;
        }

        public IEnumerable<TaskDto> Handle(GetAllTasksQuery query)
        {
            return taskRepository.GetUserTasks(userId).Select(t => new TaskDto(t.Id, t.Title, t.Description, t.DueDate.ToLongDateString(), t.IsImportant, t.IsCompleted));
        }

    }
}
