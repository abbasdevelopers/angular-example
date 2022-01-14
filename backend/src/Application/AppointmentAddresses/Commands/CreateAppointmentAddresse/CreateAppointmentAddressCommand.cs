using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UpworkAssignment.Application.Common.Interfaces;
using UpworkAssignment.Domain.Entities;

namespace UpworkAssignment.Application.AppointmentAddresses.Commands.CreateAppointmentAddresse;

public class CreateAppointmentAddressCommand : IRequest<int>
{
    public int Id { get; set; }
    public string? Address { get; set; }
    public string? Country { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string? Zip { get; set; }
    public int AppointmentId { get; set; }
}

public class CreateAppointmentAddressCommandHandler : IRequestHandler<CreateAppointmentAddressCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAppointmentAddressCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAppointmentAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = new AppointmentAddress()
        {
            AppointmentId = request.AppointmentId,
            Address = request.Address,
            City = request.City,
            Country = request.Country,
            State = request.State,
            Zip = request.Zip,
        };

        _context.AppointmentAddresses.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
