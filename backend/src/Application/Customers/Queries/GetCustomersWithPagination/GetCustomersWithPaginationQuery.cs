using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using UpworkAssignment.Application.Common.Interfaces;
using UpworkAssignment.Application.Common.Mappings;
using UpworkAssignment.Application.Common.Models;
using UpworkAssignment.Application.Customers.Queries.GetCustomers;

namespace UpworkAssignment.Application.Customers.Queries.GetCustomersWithPagination;

public class GetCustomersWithPaginationQuery : IRequest<PaginatedList<CustomerDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 1000;
}

public class GetCustomersWithPaginationQueryHandler : IRequestHandler<GetCustomersWithPaginationQuery, PaginatedList<CustomerDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCustomersWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CustomerDto>> Handle(GetCustomersWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Customers
            .OrderBy(x => x.FullName)
            .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
