using FluentValidation;

namespace TaskCheckService.Command.User.Login
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty().Length(5, 20);
            RuleFor(x => x.Password).NotEmpty().Length(8, 30);
        }
    }
}
