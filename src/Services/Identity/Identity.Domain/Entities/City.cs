using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sattec.Identity.Domain.Entities
{
    public class City
    {
        /// <summary>
        /// آیدی
        /// </summary>
        [ForeignKey("ApplicationUser")]
        public string? UserId { get; set; }
        /// <summary>
        /// کد 
        /// </summary>
        [Key]
        public string? Code { get; set; }
        /// <summary>
        /// نام شهر
        /// </summary>
        public string? Name { get; set; }
        public Country Country { get; set; }
    }
}
