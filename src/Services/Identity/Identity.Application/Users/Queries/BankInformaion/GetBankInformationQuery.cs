using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using sattec.Identity.Application.Common.Interfaces;

namespace sattec.Identity.Application.Users.Queries.BankInformaion
{
    public record GetBankInformationQuery : IRequest<BankInformation>;
    public class GetBankInformationQueryHandler : IRequestHandler<GetBankInformationQuery, BankInformation>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        public GetBankInformationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<BankInformation> Handle(GetBankInformationQuery request, CancellationToken cancellationToken)
        {
            return new BankInformation
            {
                Lists = await _context.BankAccounts
                .AsNoTracking()
                .ProjectTo<BankInformationDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Title)
                .ToListAsync(cancellationToken)
            };
        }
    }
}
