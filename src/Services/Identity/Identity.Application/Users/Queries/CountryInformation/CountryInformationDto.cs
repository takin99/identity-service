using sattec.Identity.Application.Common.Mappings;
using sattec.Identity.Domain.Entities;

namespace sattec.Identity.Application.Users.Queries.CountryInformation
{
    public class CountryInformationDto : IMapFrom<Country>
    {
        /// <summary>
        /// کد ISO
        /// </summary>
        public string? IsoCode { get; set; }
        /// <summary>
        /// کد دو رقمی کشور
        /// </summary>
        public string? Alpha2Code { get; set; }
        /// <summary>
        /// عنوان کشور
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// قاره
        /// </summary>
        public string? Region { get; set; }
    }
}
