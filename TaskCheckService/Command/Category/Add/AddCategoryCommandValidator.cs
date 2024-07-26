using FluentValidation;

namespace TaskCheckService.Command.Category.Add
{
    public class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
    {
        public AddCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(5, 100);
        }

    }
}
