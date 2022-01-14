using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UpworkAssignment.Application.Common.Interfaces;

namespace UpworkAssignment.Application.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCustomerCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.FullName)
            .NotEmpty().WithMessage("Fullname is required.")
            .MaximumLength(300).WithMessage("Fullname must not exceed 300 characters.");

        RuleFor(v => v.Email)
            .NotEmpty().WithMessage("Email is required.")
            .MaximumLength(300).WithMessage("Email must not exceed 200 characters.");

        RuleFor(v => v.Phone)
            .MaximumLength(20).WithMessage("Phone must not exceed 200 characters.");

        RuleFor(v => v.Id)
            .MustAsync(BeGreaterThanZero)
            .WithMessage("Customer id must be greater than zero.");
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
