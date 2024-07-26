
namespace TaskCheckService.Query.Dto
{
    public class RegisterDto
    {
        public RegisterDto(string username, string password, string passwordRepeat, string email)
        {
            Username = username;
            Password = password;
            PasswordRepeat = passwordRepeat;
            Email = email;
        }

        public RegisterDto() { }

        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
        public string Email { get; set; }
    }
}
