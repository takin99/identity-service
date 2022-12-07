using sattec.Identity.Application.Common.Mappings;
using sattec.Identity.Domain.Entities;

namespace sattec.Identity.Application.Users.Queries.AddressInformation
{
    public class AddressInformationDto : IMapFrom<Address>
    {
        /// <summary>
        /// کشور
        /// </summary>
        public string? Country { get; set; }
        /// <summary>
        /// شهر
        /// </summary>
        public string? City { get; set; }
        /// <summary>
        /// استان
        /// </summary>
        public string? State { get; set; }
        /// <summary>
        /// خیابان
        /// </summary>
        public string? Street { get; set; }
        /// <summary>
        /// پلاک
        /// </summary>
        public string? Plaque { get; set; }
        /// <summary>
        /// طبقه
        /// </summary>
        public string? Floor { get; set; }
        /// <summary>
        /// شماره تماس
        /// </summary>
        public string? PhoneNumber { get; set; }
        /// <summary>
        /// کد کشور
        /// </summary>
        public string? CountryCode { get; set; }
        /// <summary>
        /// کد شهر
        /// </summary>
        public string? CityCode { get; set; }
    }
}
