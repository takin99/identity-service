using FluentValidation;

namespace sattec.Identity.Application.Users.Commands.City.CreateCity
{
    public class CreateCityCommandValidatior : AbstractValidator<CreateCityCommand>
    {
        public CreateCityCommandValidatior()
        {
            RuleFor(c => c.Code)
                .NotEmpty()
                .Length(3);
        }
    }
}
