using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UpworkAssignment.Application.Common.Interfaces;

namespace UpworkAssignment.Application.Appointments.Queries.GetAppointments;

public class GetAppointmentsQuery : IRequest<List<AppointmentDto>>
{

}

public class GetAppointmentsQueryHandler : IRequestHandler<GetAppointmentsQuery, List<AppointmentDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAppointmentsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AppointmentDto>> Handle(GetAppointmentsQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .Appointments
            .Include(x => x.Customer)
            .Include(x => x.AppointmentAddress)
            .AsNoTracking()
            .ProjectTo<AppointmentDto>(_mapper.ConfigurationProvider)
            .OrderBy(c => c.StartDateTime)
            .ToListAsync(cancellationToken);
    }
}

