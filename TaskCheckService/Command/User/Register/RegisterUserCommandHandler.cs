using Entity = TaskCheckStorage.Entities;
using TaskCheckStorage.Repository;

namespace TaskCheckService.Command.User.Add
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IUserRepository repository;
        
        public RegisterUserCommandHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public Result Handle(RegisterUserCommand command)
        {
            var validationResult = new RegisterUserCommandValidator().Validate(command);

            if (!validationResult.IsValid)
                return Result.Fail(validationResult);

            if (repository.IsUsernameTaken(command.Username))
                return Result.Fail("Username is already taken", nameof(command.Username));

            Entity.User user = new Entity.User(command.Username, command.Email, command.Password);
            
            repository.RegisterUser(user);

            return Result.Ok();
            
        }
    }
}
