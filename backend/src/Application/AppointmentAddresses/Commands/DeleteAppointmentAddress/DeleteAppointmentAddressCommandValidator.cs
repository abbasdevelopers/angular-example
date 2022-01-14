using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UpworkAssignment.Application.Common.Interfaces;

namespace UpworkAssignment.Application.AppointmentAddresses.Commands.DeleteAppointmentAddress;

public class DeleteAppointmentAddressCommandValidator : AbstractValidator<DeleteAppointmentAddressCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteAppointmentAddressCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Id)
            .MustAsync(BeGreaterThanZero)
            .WithMessage("Appointment Address id must be greater than zero.");
    }

    public async Task<bool> BeGreaterThanZero(int id, CancellationToken cancellationToken)
    {
        return await Task.Run(() =>
        {
            return id > 0;
        });
    }
}
