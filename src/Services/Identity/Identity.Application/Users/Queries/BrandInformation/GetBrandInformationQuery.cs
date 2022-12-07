using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using sattec.Identity.Application.Common.Interfaces;

namespace sattec.Identity.Application.Users.Queries.BrandInformation
{
    public record GetBrandInformationQuery : IRequest<BrandInformation>;

    public class BrandInformationQueryHandler : IRequestHandler<GetBrandInformationQuery, BrandInformation>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        public BrandInformationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<BrandInformation> Handle(GetBrandInformationQuery request, CancellationToken cancellationToken)
        {
            return new BrandInformation
            {
                Lists = await _context.Brand
                 .AsNoTracking()
                 .ProjectTo<BrandInformationDto>(_mapper.ConfigurationProvider)
                 .OrderBy(t => t.BrandName)
                 .ToListAsync(cancellationToken)
            };
        }
    }
}
