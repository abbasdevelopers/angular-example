using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UpworkAssignment.Application.Common.Interfaces;
using UpworkAssignment.Domain.Entities;

namespace UpworkAssignment.Application.Customers.Commands.DeleteCustomer;

public class DeleteCustomerCommand : IRequest<int>
{
    public int Id { get; set; }
}

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, int>
{
    private readonly IApplicationDbContext _context;

    public DeleteCustomerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = _context.Customers.FirstOrDefault(x => x.Id == request.Id);

        if(entity != null)
        {
            _context.Customers.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        return request.Id;
    }
}
