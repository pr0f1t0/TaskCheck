namespace TaskCheckService.Command.User.Add
{
    public class RegisterUserCommand : ICommand
    {
        public RegisterUserCommand(string username, string password, string passwordRepeat, string email)
        {
            Username = username;
            Password = password;
            PasswordRepeat = passwordRepeat;
            Email = email;
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string PasswordRepeat { get; set; }

        public string Email { get; set; }

    }
}
