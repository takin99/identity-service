using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using sattec.Identity.Application.Common.Interfaces;

namespace sattec.Identity.Application.Users.Queries.OrganizationBranchesInformation
{
    public record GetOrganizationBranchesInformationQuery : IRequest<OrganizationBranchesInfromation>;

    public class GetOrganizationBranchesQueryHandler : IRequestHandler<GetOrganizationBranchesInformationQuery, OrganizationBranchesInfromation>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        public GetOrganizationBranchesQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<OrganizationBranchesInfromation> Handle(GetOrganizationBranchesInformationQuery request, CancellationToken cancellationToken)
        {
            return new OrganizationBranchesInfromation
            {
                Lists = await _context.OrganizationBranches
                .AsNoTracking()
                .ProjectTo<OrganizationBranchesInformationDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
            };
        }
    }
}
