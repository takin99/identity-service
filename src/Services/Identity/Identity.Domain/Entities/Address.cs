using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sattec.Identity.Domain.Entities
{
    public class Address
    {
        /// <summary>
        /// آیدی
        /// </summary>
        [ForeignKey("Country")]
        /// <summary>
        /// آیدی
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// کشور
        /// </summary>
        [Key]
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
