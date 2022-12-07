using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using sattec.Identity.Application.Common.Interfaces;


namespace sattec.Identity.Application.Users.Queries.CityInformation
{
    public record GetCityInformationQuery : IRequest<CityInformation>;

    public class GetCompanyInformationQueryHandler : IRequestHandler<GetCityInformationQuery, CityInformation>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCompanyInformationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CityInformation> Handle(GetCityInformationQuery request, CancellationToken cancellationToken)
        {
            return new CityInformation
            {
                Lists = await _context.City
                    .AsNoTracking()
                    .ProjectTo<CityInformationDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Name)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
