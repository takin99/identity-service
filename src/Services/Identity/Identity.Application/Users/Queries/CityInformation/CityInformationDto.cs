using sattec.Identity.Application.Common.Mappings;
using sattec.Identity.Domain.Entities;

namespace sattec.Identity.Application.Users.Queries.CityInformation
{
    public class CityInformationDto : IMapFrom<City>
    {
         /// <summary>
        /// کد 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// نام شهر
        /// </summary>
        public string? Name { get; set; }
    }
}
