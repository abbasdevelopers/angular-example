using UpworkAssignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace UpworkAssignment.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Customer> Customers { get; }

    DbSet<Appointment> Appointments { get; }

    DbSet<AppointmentAddress> AppointmentAddresses { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
