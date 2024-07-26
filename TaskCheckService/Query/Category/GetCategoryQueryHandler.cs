using TaskCheckService.Query.Dto;
using TaskCheckStorage.Repository;

namespace TaskCheckService.Query.Category
{
    public class GetCategoryQueryHandler : IQueryHandler<GetCategoryQuery, CategoryDto>
    {

        private readonly ITaskRepository taskRepository;

        public GetCategoryQueryHandler(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public CategoryDto Handle(GetCategoryQuery query)
        {
            var category = taskRepository.GetCategoryById(query.Id)
                ?? throw new NullReferenceException("This category does not exist.");

            return new CategoryDto(category.UserId, category.Id, category.CategoryName, category.Tasks);

        }
    }
}
