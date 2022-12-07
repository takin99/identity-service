using FluentValidation;

namespace sattec.Identity.Application.Users.Commands.CompanyInformation
{
    public class CreateCompanyInformationCommandValidator : AbstractValidator<CreateCompanyInformationCommand>
    {
        public CreateCompanyInformationCommandValidator()
        {
            RuleFor(v => v.NationalId)
           .Length(10)
           .NotEmpty();
        }
    }
}
