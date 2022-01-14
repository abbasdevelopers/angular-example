using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UpworkAssignment.Application.Common.Interfaces;

namespace UpworkAssignment.Application.Customers.Commands.DeleteCustomer;

public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCustomerCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Id)
            .MustAsync(BeGreaterThanZero)
            .WithMessage("Customer id must be greater than zero.");
    }

    public async Task<bool> BeGreaterThanZero(int id, CancellationToken cancellationToken)
    {
        return await Task.Run(() =>
        {
            return id > 0;
        });
    }
}
