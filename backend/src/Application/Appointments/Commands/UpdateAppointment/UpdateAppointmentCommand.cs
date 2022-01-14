using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UpworkAssignment.Application.Common.Interfaces;
using UpworkAssignment.Domain.Entities;

namespace UpworkAssignment.Application.Appointments.Commands.UpdateAppointment;

public class UpdateAppointmentCommand : IRequest<int>
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Note { get; set; }
    public DateTime? StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
    public int CustomerId { get; set; }
}

public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateAppointmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var entity = _context.Appointments.FirstOrDefault(c => c.Id == request.Id);
        if(entity != null)
        {
            entity.CustomerId = request.CustomerId;
            entity.Title = request.Title;
            entity.Note = request.Note;
            entity.StartDateTime = request.StartDateTime ?? DateTime.UtcNow;
            entity.EndDateTime = request.EndDateTime ?? DateTime.UtcNow.AddMinutes(15);
            entity.CustomerId = request.CustomerId;

            await _context.SaveChangesAsync(cancellationToken);
        }

        return request.Id;
    }
}
