using sattec.Identity.Application.Users.Queries.CompanyInformation;

namespace sattec.Identity.Application.Users.Queries.CountryInformation
{
    public class CountryInformation
    {
        public IList<CountryInformationDto> Lists { get; set; } = new List<CountryInformationDto>();
    }
}
