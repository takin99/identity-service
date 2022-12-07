using Microsoft.EntityFrameworkCore;
using sattec.Identity.Domain.Entities;

namespace sattec.Identity.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Country> Country { get; }
    DbSet<City> City { get; }
    DbSet<Address> Address { get; }
    DbSet<BankAccount> BankAccounts { get; }
    DbSet<Organizations> Organization { get; }
    DbSet<Documentation> Documentation { get; }
    DbSet<Brand> Brand { get; }
    DbSet<Company> Company { get; }
    DbSet<OrganizationBranches> OrganizationBranches { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
