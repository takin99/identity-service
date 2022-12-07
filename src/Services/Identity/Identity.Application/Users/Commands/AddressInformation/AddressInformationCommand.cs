using MediatR;
using sattec.Identity.Application.Common.Interfaces;
using sattec.Identity.Application.Common.Models;

namespace sattec.Identity.Application.Users.Commands.AddressInformation
{
    public record AddressInformationCommand : IRequest<Result>
    {
        public Guid UserId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string Plaque { get; set; }
        public string Floor { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public string CityCode { get; set; }
    }
    public class AddressInformationCommandHandler : IRequestHandler<AddressInformationCommand, Result>
    {
        private readonly IApplicationDbContext _context;
        private readonly IIdentityService _identityService;

        public AddressInformationCommandHandler(IIdentityService identityService, IApplicationDbContext context)
        {
            _identityService = identityService;
            _context = context;
        }
        public async Task<Result> Handle(AddressInformationCommand request, CancellationToken cancellationToken)
        {
            var user =
                 _identityService.AddressInformation
                (request.UserId.ToString(),
                 request.Country,
                 request.City,
                 request.State,
                 request.Street,
                 request.Plaque,
                 request.Floor,
                 request.PhoneNumber,
                 request.CountryCode,
                 request.CityCode);

            await _context.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}
