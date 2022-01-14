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

namespace UpworkAssignment.Application.AppointmentAddresses.Queries.GetAppointmentAddresses;

public class GetAppointmentAddressesQuery : IRequest<List<AppointmentAddressDto>>
{

}

public class GetAppointmentAddressesQueryHandler : IRequestHandler<GetAppointmentAddressesQuery, List<AppointmentAddressDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAppointmentAddressesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AppointmentAddressDto>> Handle(GetAppointmentAddressesQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .AppointmentAddresses
            .Include(x => x.Appointment)
            .AsNoTracking()
            .ProjectTo<AppointmentAddressDto>(_mapper.ConfigurationProvider)
            .OrderBy(c => c.Address)
            .ToListAsync(cancellationToken);
    }
}

