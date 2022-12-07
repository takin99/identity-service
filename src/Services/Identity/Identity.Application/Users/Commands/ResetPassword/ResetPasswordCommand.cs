using MediatR;
using sattec.Identity.Application.Common.Interfaces;
using sattec.Identity.Application.Common.Exceptions;
using sattec.Identity.Application.Common.Models;

namespace sattec.Identity.Application.Users.Commands.ResetPassword
{
    public record ResetPasswordCommand : IRequest<Result>
    {
        public Guid UserId { get; set; }
        public string NewPassword { get; set; }
        public string RepeatPassword { get; set; }
    }
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Result>
    {
        private readonly IApplicationDbContext _context;
        private readonly IIdentityService _identityService;

        public ResetPasswordCommandHandler(IIdentityService identityService, IApplicationDbContext context)
        {
            _identityService = identityService;
            _context = context; 
        }
        public async Task<Result> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user= _identityService.ResetPassword(request.UserId.ToString(), request.RepeatPassword,request.NewPassword);

            if (user == null)
                throw new NotFoundException("User not found");

            await _context.SaveChangesAsync(cancellationToken);
                
            return Result.Success();       
        }
    }
}
