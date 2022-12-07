using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using sattec.Identity.Application.Common.Interfaces;

namespace sattec.Identity.Application.Users.Queries.AddressInformation
{
    public record GetAddressInformationQuery : IRequest<AddressInformation>;
    public class GetBankInformationQueryHandler : IRequestHandler<GetAddressInformationQuery, AddressInformation>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        public GetBankInformationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<AddressInformation> Handle(GetAddressInformationQuery request, CancellationToken cancellationToken)
        {
            return new AddressInformation
            {
                Lists = await _context.Address
                .AsNoTracking()
                .ProjectTo<AddressInformationDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.City)
                .ToListAsync(cancellationToken)
            };
        }
    }
}

