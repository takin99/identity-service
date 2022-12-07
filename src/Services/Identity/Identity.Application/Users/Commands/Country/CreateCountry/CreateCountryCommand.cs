using MediatR;
using sattec.Identity.Application.Common.Interfaces;
using sattec.Identity.Application.Common.Models;

namespace sattec.Identity.Application.Users.Commands.Country.CreateCountry
{
    public record CreateCountryCommand : IRequest<Result>
    {
        public Guid UserId { get; set; }
        public string CountryIso { get; set; }
        public string Alpha2Code { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
    }
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Result>
    {
        private readonly IApplicationDbContext _context;
        private readonly IIdentityService _identityService;
        public CreateCountryCommandHandler(IApplicationDbContext context, IIdentityService identityService)
        {
            _context = context;
            _identityService = identityService;
        }
        public async Task<Result> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var user = _identityService.CreateCountry
                (request.UserId.ToString(),
                 request.CountryIso,
                 request.Alpha2Code,
                 request.Name,
                 request.Region
                );

            await _context.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}
