using Microsoft.AspNetCore.Http;
using sattec.Identity.Application.Common.Mappings;
using sattec.Identity.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;


namespace sattec.Identity.Application.Users.Queries.BrandInformation
{
    public class BrandInformationDto : IMapFrom<Brand>
    {
        /// <summary>
        /// شماره ثبت
        /// </summary>
        public string? RegistrationNumber { get; set; }
        /// <summary>
        /// نام برند
        /// </summary>
        public string? BrandName { get; set; }
        /// <summary>
        /// آدرس
        /// </summary>
        public string? Address { get; set; }
        /// <summary>
        /// شماره تلفن
        /// </summary>
        public string? PhoneNumber { get; set; }
        /// <summary>
        /// لوگو
        /// </summary>
        [NotMapped]
        public IFormFile? Logo { get; set; }
        /// <summary>
        /// صاحب برند
        /// </summary>
        public string? BrandOwner { get; set; }
    }
}
