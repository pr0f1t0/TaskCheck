using TaskCheckStorage.Entities;

namespace TaskCheckStorage.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskCheckDbContext context;

        public UserRepository(TaskCheckDbContext context)
        {
            this.context = context;
        }

        public void RegisterUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            
        }

        public bool IsPasswordCorrect(string username, string password)
        {
            return (context.Users.Single(u => u.Username == username).Password) == password;
        }

        public bool IsUsernameTaken(string username)
        {
            return context.Users.Any(u => u.Username == username);
        }

        public bool DoesUserExist(string username)
        {
            return context.Users.Any(u => u.Username == username);
        }

        public User LoginUser(string username, string password)
        {
            User loginUser = context.Users.SingleOrDefault(u => u.Username == username);

            if(password == loginUser.Password)
                return loginUser;

            return null;
        }

        public void UpdatePassword(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
        }
    }
}
