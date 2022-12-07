using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sattec.Identity.Domain.Entities
{
    public class OrganizationBranches
    {
        /// <summary>
        /// آیدی
        /// </summary>
        [ForeignKey("ApplicationUser")]
        public string? UserId { get; set; }
        /// <summary>
        /// کد شعبه
        /// </summary>
        [Key]
        public string Code { get; set; }
        /// <summary>
        /// نام شعبه
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// آدرس
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// شماره تماس
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// ایمیل
        /// </summary>
        public string Email { get; set; }
    }
}
