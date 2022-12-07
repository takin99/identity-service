using sattec.Identity.Application.Common.Mappings;
using sattec.Identity.Domain.Entities;

namespace sattec.Identity.Application.Users.Queries.OrganizationBranchesInformation
{
    public class OrganizationBranchesInformationDto : IMapFrom<OrganizationBranches>
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
