using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UpworkAssignment.Application.AppointmentAddresses.Queries.GetAppointmentAddresses;
using UpworkAssignment.Application.Common.Interfaces;
using UpworkAssignment.Application.Common.Mappings;
using UpworkAssignment.Application.Common.Models;
using UpworkAssignment.Application.Customers.Queries.GetCustomers;

namespace UpworkAssignment.Application.AppointmentAddresses.Queries.GetAppointmentAddressesWithPagination;

public class GetAppointmentAddressesWithPaginationQuery : IRequest<PaginatedList<AppointmentAddressDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetAppointmentAddressesWithPaginationQueryHandler : IRequestHandler<GetAppointmentAddressesWithPaginationQuery, PaginatedList<AppointmentAddressDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAppointmentAddressesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<AppointmentAddressDto>> Handle(GetAppointmentAddressesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.AppointmentAddresses
            .Include(x => x.Appointment)
            .OrderBy(x => x.Address)
            .ProjectTo<AppointmentAddressDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
