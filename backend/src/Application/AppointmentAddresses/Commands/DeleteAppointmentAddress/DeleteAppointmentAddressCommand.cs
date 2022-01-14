using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UpworkAssignment.Application.Common.Interfaces;
using UpworkAssignment.Domain.Entities;

namespace UpworkAssignment.Application.AppointmentAddresses.Commands.DeleteAppointmentAddress;

public class DeleteAppointmentAddressCommand : IRequest<int>
{
    public int Id { get; set; }
}

public class DeleteAppointmentAddressCommandHandler : IRequestHandler<DeleteAppointmentAddressCommand, int>
{
    private readonly IApplicationDbContext _context;

    public DeleteAppointmentAddressCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(DeleteAppointmentAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = _context.AppointmentAddresses.FirstOrDefault(x => x.Id == request.Id);

        if(entity != null)
        {
            _context.AppointmentAddresses.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        return request.Id;
    }
}
