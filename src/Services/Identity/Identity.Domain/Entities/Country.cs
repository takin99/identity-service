using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sattec.Identity.Domain.Entities
{
    public class Country
    {
        /// <summary>
        /// آیدی
        /// </summary>
        [ForeignKey("ApplicationUser")]
        public string? UserId { get; set; }
        /// <summary>
        /// کد ISO
        /// </summary>
        [Key]
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
        public List<City> Cities { get; set; }
        public void AddCity(City city)
        {
            if (this.Cities == null) this.Cities = new List<City>();
            this.Cities.Add(city);
        }
    }
}
