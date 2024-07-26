using TaskCheckService.Query.Dto;

namespace TaskCheckService.Query.Task
{
    public sealed class GetAllTasksQuery : IQuery<IEnumerable<TaskDto>>
    {
    }
}
