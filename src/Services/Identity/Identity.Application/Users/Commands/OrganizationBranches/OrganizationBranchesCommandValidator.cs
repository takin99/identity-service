using FluentValidation;

namespace sattec.Identity.Application.Users.Commands.OrganizationBranches
{
    public class OrganizationBranchesCommandValidator : AbstractValidator<OrganizationBranchesCommand>
    {
        public OrganizationBranchesCommandValidator()
        {
            RuleFor(v => v.Email)
               .NotEmpty()
               .WithMessage("Email address is required.")

              .EmailAddress()
               .WithMessage("A valid email address is required.");
        }
    }
}
