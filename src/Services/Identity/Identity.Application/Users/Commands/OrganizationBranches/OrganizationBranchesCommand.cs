using MediatR;
using sattec.Identity.Application.Common.Interfaces;
using sattec.Identity.Application.Common.Models;

namespace sattec.Identity.Application.Users.Commands.OrganizationBranches
{
    public record OrganizationBranchesCommand : IRequest<Result>
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
    public class OrganizationBranchesCommandHandler : IRequestHandler<OrganizationBranchesCommand, Result>
    {
        private readonly IApplicationDbContext _context;
        private readonly IIdentityService _identityService;

        public OrganizationBranchesCommandHandler(IIdentityService identityService, IApplicationDbContext context)
        {
            _identityService = identityService;
            _context = context;
        }
        public async Task<Result> Handle(OrganizationBranchesCommand request, CancellationToken cancellationToken)
        {
            var user =
                _identityService.CreateOrganizationBranches
               (request.UserId.ToString(),
               request.Name,
               request.Code,
               request.Address,
               request.PhoneNumber,
               request.Email
            );

            //ToDo fileUpload

            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
