using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace sattec.Identity.Domain.Entities
{
    public class Company
    {
        /// <summary>
        /// آیدی
        /// </summary>
        [ForeignKey("ApplicationUser")]
        public string? UserId { get; set; }
        /// <summary>
        /// نام بانک
        /// </summary>
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
