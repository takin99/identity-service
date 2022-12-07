using AutoMapper;
using MediatR;
using sattec.Identity.Application.Common.Interfaces;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace sattec.Identity.Application.Users.Queries.CompanyInformation
{
    public record GetCompanyInformationQuery : IRequest<CompanyInformation>;

    public class GetCompanyInformationQueryHandler : IRequestHandler<GetCompanyInformationQuery, CompanyInformation>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCompanyInformationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CompanyInformation> Handle(GetCompanyInformationQuery request, CancellationToken cancellationToken)
        {
            return new CompanyInformation
            {
                Lists = await _context.Company
                    .AsNoTracking()
                    .ProjectTo<CompanyInformationDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Name)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}

