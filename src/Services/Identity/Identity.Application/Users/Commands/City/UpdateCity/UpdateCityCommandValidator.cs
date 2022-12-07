using FluentValidation;

namespace sattec.Identity.Application.Users.Commands.City.UpdateCity
{
    public class UpdateCityCommandValidator : AbstractValidator<UpdateCityCommand>
    {
        public UpdateCityCommandValidator()
        {
            RuleFor(c => c.Code)
               .NotEmpty()
               .Length(3);
        }
    }
}
