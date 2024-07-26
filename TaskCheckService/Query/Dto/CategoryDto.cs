using TaskCheckStorage.Entities;

namespace TaskCheckService.Query.Dto
{
    public class CategoryDto
    {
        public CategoryDto(long userId, long id, string name, IEnumerable<UserTask> userTasks)
        {
            UserId = userId;
            Id = id;
            Name = name;
            UserTasks = userTasks;
        }

        public long UserId { get; set; }

        public long Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<UserTask> UserTasks { get; set; }
    }
}
