using Microsoft.AspNetCore.Http;
using sattec.Identity.Application.Common.Models;
using sattec.Identity.Domain.Entities;

namespace sattec.Identity.Application.Common.Interfaces;

public interface IIdentityService 
{
    Task<string> GetUserNameAsync(string userId);
    string GeRegistrationId(string registrationId);
    Task<bool> IsInRoleAsync(string userId, string role);
    Task<bool> AuthorizeAsync(string userId, string policyName);
    Task<string> CreateUserAsync(string firstName, string lastName, string userName, string email, string PhoneNumber, string password);
    Result GetByMobileVerificationCode(string verifiCode);
    Result GetByEmailVerification(string code);
    string GetByPhoneNumber(string phoneNumber, string email);
    Result UpdateUserType(string userId, UserType userType);
    Result CreateCountry(string userId, string isoCode, string alpha2Code, string name, string region);
    Result UpdateCountry(string userId, string isoCode, string alpha2Code, string name, string region);
    Result CreateCity(string userId, string code, string name);
    Result UpdateCity(string userId, string code, string name);
    Result FindByPhoneNumber(string phoneNumber);
    Task<Result> DeleteUserAsync(string userId);
    Task<(string token, string userId)> LoginByUserPassAsync(string phoneNumber, string password);
    Result ResetPassword(string userId, string newPassword, string repeatPassword);
    Task<Result> CreateUserIdentityInfo(Guid id, string firstName, string lastName, string fatherName, string nationalId, string identitySerialNumber, DateTime birthday, string birthPlace, IFormFile NationalCardFile);
    Result AddressInformation(string userId, string country, string city, string state, string street, string plaque, string floor, string phoneNumber, string countryCode, string cityCode);
    Task<Result> CreateContactInformation(Guid id, string essentialPhone, string phoneNumber, string postalCode, string address, string country, string state, string city, string description);
    Result CreateInsuranceInfo(string userId, string name, string InsuranceNumber);
    Result CreateCompanyInformation(string userId, string Name, CompanyType CompanyType, string nationalId, string economicCode);
    Result CreateOrganizationBranches(string userId, string Name, string code, string address, string phoneNumber, string email);
    Result UpdateInsuranceInfo(string userId, string name, string InsuranceNumber);
    Result CreateBankInfo (string userId, bool isDefaultAccount, Guid? bankId, string title, string accountNo, string cardNo, string iban, string accountName, string description);
    Result UpdateBankInfo(string userId, bool isDefaultAccount, Guid bankId, string title, string accountNo, string cardNo, string iban, string accountName, string description);
    Result CreateDocument(string userId, string description, IFormFile file);
    Result UpdateDocument(string userId, string description, IFormFile file);
    Result CreateBrandInformation(string userId, string brandName, string address, string phoneNumber, string registrationNumber, IFormFile logo, string brandOwner);
    Result UpdateBrandInformation(string userId, string brandName, string address, string phoneNumber, string registrationNumber, IFormFile logo, string brandOwner);

    Task<Result> CheckVerificationAsync(string phoneNumber, string code);
    Task<string> StartVerificationAsync(string phoneNumber);
}
