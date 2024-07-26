using FluentValidation;

namespace TaskCheckService.Command.Task.Update
{
    public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskCommandValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Title).NotEmpty().Length(5, 100);
            RuleFor(x => x.Description).Length(10, 100);
            RuleFor(x => x.DueDate).GreaterThan(DateTime.UtcNow);
        }
    }
}
