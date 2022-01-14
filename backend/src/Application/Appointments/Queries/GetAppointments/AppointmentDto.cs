using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using UpworkAssignment.Application.Common.Mappings;
using UpworkAssignment.Application.Customers.Queries.GetCustomers;
using UpworkAssignment.Domain.Entities;

namespace UpworkAssignment.Application.Appointments.Queries.GetAppointments;

public class AppointmentDto : IMapFrom<Appointment>
{
    public string? Title { get; set; }
    public string? Note { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public int CustomerId { get; set; }

    public AppointmentAddress? AppointmentAddress { get; set; }

    public CustomerDto? Customer { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Appointment, AppointmentDto>();
    }
}
