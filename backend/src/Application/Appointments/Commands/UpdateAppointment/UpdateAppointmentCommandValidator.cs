using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UpworkAssignment.Application.Common.Interfaces;

namespace UpworkAssignment.Application.Appointments.Commands.UpdateAppointment;

public class UpdateAppointmentCommandValidator : AbstractValidator<UpdateAppointmentCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateAppointmentCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(255).WithMessage("Title must not exceed 255 characters.");

        RuleFor(v => v.Note)
            .NotEmpty().WithMessage("Note is required.")
            .MaximumLength(300).WithMessage("Note must not exceed 300 characters.");

        RuleFor(v => v.CustomerId)
            .MustAsync(BeGreaterThanZero).WithMessage("Customer id is required.");

        RuleFor(v => v.Id)
            .MustAsync(BeGreaterThanZero).WithMessage("Appointment id is required.");
    }

    public async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
    {
        return await _context.Customers
            .AllAsync(l => l.Email != email, cancellationToken);
    }
    public async Task<bool> BeGreaterThanZero(int id, CancellationToken cancellationToken)
    {
        return await Task.Run(() =>
        {
            return id > 0;
        });
    }
}
