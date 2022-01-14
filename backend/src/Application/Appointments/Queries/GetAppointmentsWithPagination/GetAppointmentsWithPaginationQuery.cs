using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UpworkAssignment.Application.Appointments.Queries.GetAppointments;
using UpworkAssignment.Application.Common.Interfaces;
using UpworkAssignment.Application.Common.Mappings;
using UpworkAssignment.Application.Common.Models;
using UpworkAssignment.Application.Customers.Queries.GetCustomers;

namespace UpworkAssignment.Application.Appointments.Queries.GetAppointmentsWithPagination;

public class GetAppointmentsWithPaginationQuery : IRequest<PaginatedList<AppointmentDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 1000;
}

public class GetAppointmentsWithPaginationQueryHandler : IRequestHandler<GetAppointmentsWithPaginationQuery, PaginatedList<AppointmentDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAppointmentsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<AppointmentDto>> Handle(GetAppointmentsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .Appointments
            .Include(x => x.Customer)
            .Include(x => x.AppointmentAddress)
            .OrderBy(x => x.StartDateTime)
            .ProjectTo<AppointmentDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
