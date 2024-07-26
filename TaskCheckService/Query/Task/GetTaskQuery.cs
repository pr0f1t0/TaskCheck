using TaskCheckService.Query.Dto;

namespace TaskCheckService.Query.Task
{
    public sealed class GetTaskQuery : IQuery<TaskDetailsDto>
    {
        public GetTaskQuery(long id)
        {
            Id = id;
        }


        public long Id { get; set; }
    }
}
