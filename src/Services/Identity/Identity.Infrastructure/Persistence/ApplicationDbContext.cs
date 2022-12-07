﻿using System.Reflection;
using sattec.Identity.Application.Common.Interfaces;
using sattec.Identity.Infrastructure.Persistence.Interceptors;
using Duende.IdentityServer.EntityFramework.Options;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using sattec.Identity.Domain.Entities;
using ApplicationUser = sattec.Identity.Infrastructure.Identity.ApplicationUser;

namespace sattec.Identity.Infrastructure.Persistence;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
{
    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;


    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions,
        IMediator mediator,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) 
        : base(options, operationalStoreOptions)
    {
        _mediator = mediator;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }
    public DbSet<Country> Country => Set<Country>();
    public DbSet<City> City => Set<City>();
    public DbSet<Address> Address => Set<Address>();
    public DbSet<BankAccount> BankAccounts => Set<BankAccount>();
    public DbSet<Organizations> Organization => Set<Organizations>();
    public DbSet<Documentation> Documentation => Set<Documentation>();
    public DbSet<Brand> Brand => Set<Brand>();
    public DbSet<Company> Company => Set<Company>();
    public DbSet<OrganizationBranches> OrganizationBranches => Set<OrganizationBranches>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }
}
