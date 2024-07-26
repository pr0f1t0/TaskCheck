using Microsoft.EntityFrameworkCore;
using TaskCheckStorage.Entities;

namespace TaskCheckStorage.Repository
{
    public class TaskRepository: ITaskRepository
    {
        private readonly TaskCheckDbContext context;

        public TaskRepository(TaskCheckDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<UserTask> GetUserTasks(long userId)
        {
            return context.Tasks
                .Where(t => t.UserId == userId)
                .ToList();
        }

        public UserTask GetUserTaskById(long taskId)
        {
            return context.Tasks
                .Include(t => t.CategoryId)
                .SingleOrDefault(t => t.Id == taskId);
        }

        public IEnumerable<Category> GetCategories(long userId)
        {
            return context.Categories
                .Where(c => c.UserId == userId)
                .ToList();
        }

        public Category GetCategoryById(long categoryId)
        {
            return context.Categories
                .Include(c => c.Id)
                .SingleOrDefault(c => c.Id == categoryId);
        }

        public void AddUserTask(UserTask userTask)
        {
            context.Tasks.Add(userTask);
            context.SaveChanges();
        }

        public void UpdateUserTask(UserTask userTask)
        {
            context.Tasks.Update(userTask);
            context.SaveChanges();
        }

        public void RemoveUserTask(long id)
        {
            UserTask userTask = context.Tasks.FirstOrDefault(t => t.Id == id);
            context.Remove(userTask);
            context.SaveChanges();
        }

        public void AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges(); 
        }

        public void UpdateCategory(Category category)
        {
            context.Categories.Update(category);
            context.SaveChanges();
        }

        public void RemoveCategory(long id)
        {
            Category category = context.Categories.FirstOrDefault(c => c.Id == id);
            context.Remove(category);
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
        }
    }
}
