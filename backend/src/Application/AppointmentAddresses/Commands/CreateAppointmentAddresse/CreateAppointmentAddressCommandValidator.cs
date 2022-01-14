using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UpworkAssignment.Application.Common.Interfaces;

namespace UpworkAssignment.Application.AppointmentAddresses.Commands.CreateAppointmentAddresse;

public class CreateAppointmentAddressCommandValidator : AbstractValidator<CreateAppointmentAddressCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateAppointmentAddressCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Address)
            .NotEmpty().WithMessage("Address is required.")
            .MaximumLength(255).WithMessage("Address must not exceed 255 characters.");

        RuleFor(v => v.Country)
            .MaximumLength(255).WithMessage("Country must not exceed 255 characters.");

        RuleFor(v => v.State)
            .MaximumLength(50).WithMessage("State must not exceed 50 characters.");

        RuleFor(v => v.City)
            .MaximumLength(50).WithMessage("City must not exceed 50 characters.");

        RuleFor(v => v.Zip)
            .MaximumLength(50).WithMessage("Zip must not exceed 50 characters.");

        RuleFor(v => v.AppointmentId)
            .MustAsync(BeGreaterThanZero).WithMessage("Appointment Id is required.");
    }

    public async Task<bool> BeGreaterThanZero(int id, CancellationToken cancellationToken)
    {
        return await Task.Run(() =>
        {
            return id > 0;
        });
    }
}
