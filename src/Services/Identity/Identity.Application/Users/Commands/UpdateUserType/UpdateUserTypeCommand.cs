using MediatR;
using sattec.Identity.Application.Common.Exceptions;
using sattec.Identity.Application.Common.Interfaces;
using sattec.Identity.Application.Common.Models;
using sattec.Identity.Domain.Entities;


namespace sattec.Identity.Application.Users.Commands.UpdateUserType
{
    public record UpdateUserTypeCommand : IRequest<Result>
    {
        public Guid UserId { get; set; }
        public UserType UserType { get; set; }
    }
    public class UpdateUserTypeCommandHandler : IRequestHandler<UpdateUserTypeCommand, Result>
    {
        private readonly IApplicationDbContext _context;
        private readonly IIdentityService _identityService;


        public UpdateUserTypeCommandHandler(IApplicationDbContext context, IIdentityService identityService)
        {
            _context = context;
            _identityService = identityService;
        }
        public async Task<Result> Handle(UpdateUserTypeCommand request, CancellationToken cancellationToken)
        {
            var user = _identityService.UpdateUserType(request.UserId.ToString(), request.UserType);

            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
