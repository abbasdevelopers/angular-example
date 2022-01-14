using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UpworkAssignment.Application.Common.Interfaces;
using UpworkAssignment.Domain.Entities;

namespace UpworkAssignment.Application.Appointments.Commands.CreateAppointment;

public class CreateAppointmentCommand : IRequest<int>
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Note { get; set; }
    public DateTime? StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
    public int CustomerId { get; set; }
}

public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAppointmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var entity = new Appointment()
        {
            CustomerId = request.CustomerId,
            EndDateTime = request.EndDateTime ?? DateTime.UtcNow.AddMinutes(15),
            Note = request.Note,
            StartDateTime = request.StartDateTime ?? DateTime.UtcNow,
            Title = request.Title
        };

        _context.Appointments.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
