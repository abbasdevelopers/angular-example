using System.Reflection;
using UpworkAssignment.Application.Common.Interfaces;
using UpworkAssignment.Infrastructure.Identity;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UpworkAssignment.Domain.Entities;

namespace UpworkAssignment.Infrastructure.Persistence;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTime _dateTime;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions,
        ICurrentUserService currentUserService,
        IDateTime dateTime) : base(options, operationalStoreOptions)
    {
        _currentUserService = currentUserService;
        _dateTime = dateTime;
    }

    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Appointment> Appointments => Set<Appointment>();

    public DbSet<AppointmentAddress> AppointmentAddresses => Set<AppointmentAddress>();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
