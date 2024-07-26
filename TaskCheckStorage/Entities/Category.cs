using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskCheckStorage.Common;

namespace TaskCheckStorage.Entities
{
    [Table("Category", Schema = "TaskCheck")]
    public class Category : BaseEntity
    {

        [Required]
        public long UserId { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public ICollection<UserTask> Tasks {  get; set; }

        protected Category() { }

        public Category(long userId, string categoryName)
        {
            UserId = userId;
            CategoryName = categoryName;
        }
    }
}
