using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using UpworkAssignment.Application.Common.Mappings;
using UpworkAssignment.Domain.Entities;

namespace UpworkAssignment.Application.Customers.Queries.GetCustomers;

public class CustomerDto : IMapFrom<Customer>
{
    public int Id { get; set; }
    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Customer, CustomerDto>();
    }
}
