using TaskCheckStorage.Entities;

namespace TaskCheckStorage.Repository
{
    public interface ITaskRepository
    {
        IEnumerable<UserTask> GetUserTasks(long userId);
        UserTask GetUserTaskById(long taskId);


        IEnumerable<Category> GetCategories(long userId);
        Category GetCategoryById(long categoryId);


        void AddUserTask(UserTask userTask);

        void UpdateUserTask(UserTask userTask);

        void RemoveUserTask(long taskId);


        void AddCategory(Category category);

        void UpdateCategory(Category category);

        void RemoveCategory(long CategoryId);


        void AddUser(User user);

        void UpdateUser(User user);

    }
}
