using FluentValidation;

namespace sattec.Identity.Application.Users.Commands.EmailConfirm
{
    public class EmailConfirmCommandValidator : AbstractValidator<EmailConfirmCommand>
    {
        public EmailConfirmCommandValidator()
        {
            RuleFor(v => v.Code)
               .NotEmpty()
               .Length(6);
        }
    }
}
