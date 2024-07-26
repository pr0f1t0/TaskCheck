namespace TaskCheckService.Query.Dto
{
    public class UserDto
    {
        public UserDto(long userId, string username, string password)
        {
            UserId = userId;
            Username = username;
            Password = password;
        }

        public UserDto() { }

        public long UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

    }
}
