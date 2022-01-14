using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UpworkAssignment.Application.Common.Interfaces;
using UpworkAssignment.Domain.Entities;

namespace UpworkAssignment.Application.AppointmentAddresses.Commands.UpdateAppointmentAddress;

public class UpdateAppointmentAddressCommand : IRequest<int>
{
    public int Id { get; set; }
    public string? Address { get; set; }
    public string? Country { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string? Zip { get; set; }
    public int AppointmentId { get; set; }
}

public class UpdateAppointmentAddressCommandHandler : IRequestHandler<UpdateAppointmentAddressCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateAppointmentAddressCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateAppointmentAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = _context.AppointmentAddresses.FirstOrDefault(c => c.Id == request.Id);
        if(entity != null)
        {
            entity.City = request.City;
            entity.Zip = request.Zip;
            entity.State = request.State;
            entity.Country = request.Country;
            entity.AppointmentId = request.AppointmentId;
            entity.Address = request.Address;

            await _context.SaveChangesAsync(cancellationToken);
        }

        return request.Id;
    }
}
