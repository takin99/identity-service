using MediatR;
using sattec.Identity.Application.Common.Interfaces;
using sattec.Identity.Application.Common.Models;
using sattec.Identity.Domain.Entities;

namespace sattec.Identity.Application.Users.Commands.CompanyInformation
{
    public record CreateCompanyInformationCommand : IRequest<Result>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public CompanyType CompanyType { get; set; }
        public string NationalId { get; set; }
        public string EconomicCode { get; set; }
    }

    public class CreateCompanyInformationCommandHandler : IRequestHandler<CreateCompanyInformationCommand, Result>
    {
        private readonly IApplicationDbContext _context;
        private readonly IIdentityService _identityService;

        public CreateCompanyInformationCommandHandler(IIdentityService identityService, IApplicationDbContext context)
        {
            _identityService = identityService;
            _context = context;
        }
        public async Task<Result> Handle(CreateCompanyInformationCommand request, CancellationToken cancellationToken)
        {
            var user =
             _identityService.CreateCompanyInformation(
                 request.UserId.ToString(),
                 request.Name,
                 request.CompanyType,
                 request.NationalId,
                 request.EconomicCode
                 );

            await _context.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}
