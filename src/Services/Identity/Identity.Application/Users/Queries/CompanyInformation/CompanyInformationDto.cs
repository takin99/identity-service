using sattec.Identity.Application.Common.Mappings;
using sattec.Identity.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace sattec.Identity.Application.Users.Queries.CompanyInformation
{
    public class CompanyInformationDto : IMapFrom<Company>
    {
        public string? Name { get; set; }
        /// <summary>
        /// نوع شرکت
        /// </summary>
        public CompanyType CompanyType { get; set; }
        /// <summary>
        /// کد ملی
        /// </summary>
        [Key]
        public string? NationalId { get; set; }
        /// <summary>
        /// کد اقتصادی
        /// </summary>
        public string? EconomicCode { get; set; }
    }
}
