using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using sattec.Identity.Application.Common.Interfaces;

namespace sattec.Identity.Application.Users.Queries.CountryInformation
{
    public record GetCountryInformationQuery : IRequest<CountryInformation>;

    public class GetCompanyInformationQueryHandler : IRequestHandler<GetCountryInformationQuery, CountryInformation>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCompanyInformationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CountryInformation> Handle(GetCountryInformationQuery request, CancellationToken cancellationToken)
        {
            return new CountryInformation
            {
                Lists = await _context.Country
                    .AsNoTracking()
                    .ProjectTo<CountryInformationDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Name)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
