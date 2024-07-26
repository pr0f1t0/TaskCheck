using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskCheckStorage.Common;

namespace TaskCheckStorage.Entities
{
    [Table("UserTask", Schema = "TaskCheck")]
    public class UserTask: BaseEntity
    {
        [Required]
        public long UserId {  get; set; }

        [Required]
        public long CategoryId { get; set; }

        [Required]
        public bool IsImportant { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Category Category { get; set; }

        protected UserTask() { }
        public UserTask(long userId, long categoryId, bool isImportant, bool isCompleted, string title, string? description, 
            DateTime createDate, DateTime dueDate)
        {
            UserId = userId;
            CategoryId = categoryId;
            IsImportant = isImportant;
            IsCompleted = isCompleted;
            Title = title;
            Description = description;
            CreateDate = createDate;
            DueDate = dueDate;
        }
    }
}
