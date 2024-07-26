using TaskCheckStorage.Entities;

namespace TaskCheckStorage.Repository
{
    public interface IUserRepository
    {
        void RegisterUser(User user);

        void UpdatePassword(User user); 

        bool DoesUserExist(string username);

        bool IsUsernameTaken (string username);

        bool IsPasswordCorrect (string username, string password);

        User LoginUser(string username, string password);

    }
}
