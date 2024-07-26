using FluentValidation;

namespace TaskCheckService.Command.User.Add
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty().Length(5, 20).WithMessage("Username must be between 5 and 20 characters long");
            RuleFor(x => x.Password).NotEmpty().Length(8, 30).WithMessage("Password must be between 8 and 30 characters long");
            RuleFor(x => x.Password).Matches(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,30}$").WithMessage("Password must contain at least one " +
                "uppercase letter and one digit");
            RuleFor(x => x.PasswordRepeat).Equal(x => x.Password).WithMessage("Passwords do not match");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("This is not a real email address");
        }
    }
}
