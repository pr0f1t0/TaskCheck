using TaskCheckService.Query.Dto;
using TaskCheckStorage.Repository;
using Entity = TaskCheckStorage.Entities;

namespace TaskCheckService.Query.Category
{
    public class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly ITaskRepository taskRepository;
        private readonly long userId;

        public GetAllCategoriesQueryHandler(ITaskRepository taskRepository, Entity.User user)
        {
            this.taskRepository = taskRepository;
            this.userId = user.Id;
        }

        public IEnumerable<CategoryDto> Handle(GetAllCategoriesQuery query)
        {
            return taskRepository.GetCategories(userId).Select(t => new CategoryDto(t.UserId, t.Id, t.CategoryName, t.Tasks));
        }
    }
}
