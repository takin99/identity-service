using MediatR;
using sattec.Identity.Application.Common.Interfaces;
using sattec.Identity.Application.Common.Models;

namespace sattec.Identity.Application.Users.Commands.City.UpdateCity
{
    public record UpdateCityCommand : IRequest<Result>
    {
        public Guid UserId { get; set; }
        public Guid CountryId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, Result>
    {
        private readonly IApplicationDbContext _context;
        private readonly IIdentityService _identityService;
        public UpdateCityCommandHandler(IApplicationDbContext context, IIdentityService identityService)
        {
            _context = context;
            _identityService = identityService;
        }
        public async Task<Result> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var user = _identityService.UpdateCity
                (request.UserId.ToString(),
                request.Code,
                request.Name
                );

            await _context.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}
