using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskCheckStorage.Common;

namespace TaskCheckStorage.Entities
{
    [Table("User", Schema = "TaskCheck")]
    public class User: BaseEntity
    {

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email {  get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<UserTask> Tasks { get; set; }

        public ICollection<Category> Categories { get; set; }

        protected User() { }

        public User(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }
    }
}
