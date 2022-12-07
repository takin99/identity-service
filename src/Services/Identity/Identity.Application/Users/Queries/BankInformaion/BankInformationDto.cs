using sattec.Identity.Application.Common.Mappings;
using sattec.Identity.Domain.Entities;


namespace sattec.Identity.Application.Users.Queries.BankInformaion
{
    public class BankInformationDto : IMapFrom<BankAccount>
    {
        /// <summary>
        /// نام بانک
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// شماره حساب
        /// </summary>
        public string? AccountNo { get; set; }
        /// <summary>
        /// شماره کارت
        /// </summary>
        public string? CardNo { get; set; }
        /// <summary>
        /// شماره شبا
        /// </summary>
        public string? IBAN { get; set; }
        /// <summary>
        /// نام صاحب حساب
        /// </summary>
        public string? AccountName { get; set; }
        /// <summary>
        /// توضیح
        /// </summary>
        public string? Description { get; set; }
    }
}
