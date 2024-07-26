using FluentValidation;

namespace TaskCheckService.Command.Task.Add
{
    public class AddTaskCommandValidator: AbstractValidator<AddTaskCommand>
    {
        public AddTaskCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.DueDate).GreaterThan(DateTime.UtcNow);
            RuleFor(x => x.Description).Length(10, 100);
        }
    }
}
