using TaskCheckStorage.Repository;

namespace TaskCheckService.Command.User.Login
{
    public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand>
    {
        private readonly IUserRepository repository;

        public LoginUserCommandHandler(IUserRepository repository)
        {
            this.repository = repository;   
        }

        public Result Handle(LoginUserCommand command)
        {
            var validationResult = new LoginUserCommandValidator().Validate(command);

            if (!validationResult.IsValid)
                return Result.Fail(validationResult);

            if (!repository.DoesUserExist(command.Username))
                return Result.Fail("The user does not exist", nameof(command.Username));

            if (!repository.IsPasswordCorrect(command.Username, command.Password))
                return Result.Fail("The password is incorrect", nameof(command.Password));

            return Result.Ok();
        }
    }
}
