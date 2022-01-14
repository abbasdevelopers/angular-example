using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UpworkAssignment.Application.Common.Interfaces;
using UpworkAssignment.Domain.Entities;

namespace UpworkAssignment.Application.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommand : IRequest<int>
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateCustomerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = _context.Customers.FirstOrDefault(c => c.Id == request.Id);
        if(entity != null)
        {
            entity.FullName = request.FullName;
            entity.Email = request.Email;
            entity.Phone = request.Phone;

            await _context.SaveChangesAsync(cancellationToken);
        }

        return request.Id;
    }
}
