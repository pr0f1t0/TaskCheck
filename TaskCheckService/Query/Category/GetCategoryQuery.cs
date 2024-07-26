using TaskCheckService.Query.Dto;
using TaskCheckStorage.Entities;

namespace TaskCheckService.Query.Category
{
    public sealed class GetCategoryQuery : IQuery<CategoryDto>
    {
        public GetCategoryQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
