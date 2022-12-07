﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using sattec.Identity.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace sattec.Identity.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    /// <summary>
    /// نام
    /// </summary>
    public string? FirstName { get; set; }
    /// <summary>
    /// نام خانوادگی
    /// </summary>
    public string? LastName { get; set; }
    /// <summary>
    /// آیدی ثبت نام
    /// </summary>
    public string? RegistrationId { get; set; }
    /// <summary>
    /// تاریخ انقضای ثبت نام
    /// </summary>
    public DateTime? RegistrationExpireTime { get; set; }
    /// <summary>
    /// نام پدر
    /// </summary>
    public string? FatherName { get; set; }
    /// <summary>
    /// کد ملی
    /// </summary>
    public string? NationalId { get; set; }
    /// <summary>
    ///نوع ایمیل
    /// </summary>
    public EmailType EmailType { get; set; }
    /// <summary>
    ///نوع کاربر
    /// </summary>
    public UserType UserType { get; set; }
    /// <summary>
    /// تکرار پسورد
    /// </summary>
    public string? ConfirmPassWord { get; set; }
    /// <summary>
    /// شماره سریال
    /// </summary>
    public string? IdentitySerialNumber { get; set; }
    /// <summary>
    /// تاریخ تولد
    /// </summary>
    public DateTime BirthDay { get; set; }
    /// <summary>
    /// محل تولد
    /// </summary>
    public string? BirthPlace { get; set; }
    /// <summary>
    /// تصویر کارت ملی
    /// </summary>
    [NotMapped]
    public IFormFile NationalCardFile { get; set; }
    /// <summary>
    /// تلفن ضروری
    /// </summary>
    public string? EssentialPhone { get; set; }
    /// <summary>
    /// کد پستی
    /// </summary>
    public string? PostalCode { get; set; }
    /// <summary>
    /// آدرس
    /// </summary>
    public Address Address { get; set; }
    /// <summary>
    /// کشور
    /// </summary>
    public string? Country { get; set; }
    /// <summary>
    /// استان
    /// </summary>
    public string? State { get; set; }
    /// <summary>
    /// شهر
    /// </summary>
    public string? City { get; set; }
    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// کد تایید موبایل
    /// </summary>
    public string? MobileVerificationCode { get; set; }
    /// <summary>
    /// تاریخ انقضای کد
    /// </summary>
    public DateTime MobileVerificationCodeExpireTime { get; set; }
    /// <summary>
    /// آیا کد تایید شده یا نه؟
    /// </summary>
    public bool MobileIsVerifed { get; set; }
   
    public List<Country> Countries { get; set; }
    public List<Address> Addresses { get; set; }
    public List<Company> Company { get; set; }
    public List<Brand> Brands { get; set; }
    public List<Organizations> Organization { get; set; }
    public List<OrganizationBranches> OrganizationBranches { get; set; }
    public List<BankAccount> BankAccounts { get; set; }
    public List<Documentation> Documentation { get; set; }
    public List<UserLogin> LoginLogs { get; set; }

    public bool IsValidRegistrationId()
    {
        return RegistrationExpireTime != null && RegistrationExpireTime <= DateTime.UtcNow;
    }
    public bool FailedLoginTry(DateTime date, int tryCount)
    {
        bool result = true;
        if (this.LoginLogs == null)
            return result;

        int maxCheck = tryCount;
        int failedAttempt = 0;
        var allLogin = this.LoginLogs.OrderByDescending(x => x.LoginDateTime).Where(x => x.LoginDateTime > date).ToList();
        foreach (var log in allLogin)
        {
            maxCheck--;
            if (maxCheck < 0)
                break;
            if (log.Success == false)
                failedAttempt++;
            if (failedAttempt == tryCount)
            {
                result = false;
                break;
            }
        }
        return result;
    }
    public void AddCompany(Company company)
    {
        if (this.Company == null) this.Company = new List<Company>();
        this.Company.Add(company);
    }
    public void AddCountry(Country country)
    {
        if (this.Countries == null) this.Countries = new List<Country>();
        this.Countries.Add(country);
    }  
    public void AddBrand(Brand brand)
    {
        if (this.Brands == null) this.Brands = new List<Brand>();
        this.Brands.Add(brand);
    }
    public void AddOrganization(Organizations organization)
    {
        if (this.Organization == null) this.Organization = new List<Organizations>();
        this.Organization.Add(organization);
    }
    public void AddOrganizationBranches(OrganizationBranches organizationBranches)
    {
        if (this.OrganizationBranches == null) this.OrganizationBranches = new List<OrganizationBranches>();
        this.OrganizationBranches.Add(organizationBranches);
    }
    public void AddAddress(Address address)
    {
        if (this.Addresses == null) this.Addresses = new List<Address>();
        this.Addresses.Add(address);
    } 
    public void AddBankAccount(BankAccount bankAccount)
    {
        if (this.BankAccounts == null) this.BankAccounts = new List<BankAccount>();
        this.BankAccounts.Add(bankAccount);
    }
    public void AddDocumentation(Documentation documentation)
    {
        if (this.Documentation == null) this.Documentation = new List<Documentation>();
        this.Documentation.Add(documentation);
    }  
    public bool IsValidMobileCode()
    {
        return MobileVerificationCode != null && MobileVerificationCodeExpireTime > DateTime.UtcNow;
    }
    public bool IsEnableDeafaultAccount(Guid bankId, bool isDefaultAccount)
    {
        this.BankAccounts.OrderByDescending(u => u.BankId == bankId).FirstOrDefault();

        return isDefaultAccount = true;
    }
}
