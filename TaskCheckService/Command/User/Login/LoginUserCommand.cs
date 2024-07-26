namespace TaskCheckService.Command.User.Login
{
    public class LoginUserCommand : ICommand
    {
        public LoginUserCommand(long userId, string username, string password)
        {
            UserId = userId;
            Username = username;
            Password = password;
        }

        public long UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

    }
}
