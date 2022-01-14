using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UpworkAssignment.Application.Common.Interfaces;
using UpworkAssignment.Domain.Entities;

namespace UpworkAssignment.Application.Appointments.Commands.DeleteAppointment;

public class DeleteAppointmentCommand : IRequest<int>
{
    public int Id { get; set; }
}

public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, int>
{
    private readonly IApplicationDbContext _context;

    public DeleteAppointmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
    {
        var entity = _context.Appointments.FirstOrDefault(x => x.Id == request.Id);

        if(entity != null)
        {
            _context.Appointments.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        return request.Id;
    }
}
