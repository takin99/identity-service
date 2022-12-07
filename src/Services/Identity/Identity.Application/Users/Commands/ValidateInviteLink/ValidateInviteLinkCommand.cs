using MediatR;
using sattec.Identity.Application.Common.Interfaces;

namespace sattec.Identity.Application.Users.Commands.ValidateInviteLink
{
    public record ValidateInviteLinkCommand : IRequest<ValidateInviteLinkResponse>
    {
        public string RegisterationId { get; set; }
    }
    public class ValidateInviteLinkResponse
    {
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
    public class ValidateInviteLinkCommandHandler : IRequestHandler<ValidateInviteLinkCommand, ValidateInviteLinkResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IIdentityService _identityService;
        public ValidateInviteLinkCommandHandler(IApplicationDbContext context, IIdentityService identityService)
        {
            _context = context;
            _identityService = identityService;
        }
        public async Task<ValidateInviteLinkResponse> Handle(ValidateInviteLinkCommand request, CancellationToken cancellationToken)
        {
            var user =  _identityService.GeRegistrationId(request.RegisterationId);

            await _context.SaveChangesAsync(cancellationToken);

            return new ValidateInviteLinkResponse() {Email = user, IsActive = true};
        }
    }
}
