using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using UpworkAssignment.Application.Appointments.Queries.GetAppointments;
using UpworkAssignment.Application.Common.Mappings;
using UpworkAssignment.Domain.Entities;

namespace UpworkAssignment.Application.AppointmentAddresses.Queries.GetAppointmentAddresses;

public class AppointmentAddressDto : IMapFrom<AppointmentAddress>
{
    public string? Address { get; set; }
    public string? Country { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string? Zip { get; set; }
    public int AppointmentId { get; set; }

    public AppointmentDto? Appointment { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<AppointmentAddress, AppointmentAddressDto>();
    }
}
