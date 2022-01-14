using UpworkAssignment.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UpworkAssignment.Application.Customers.Queries.GetCustomersWithPagination;
using UpworkAssignment.Application.Customers.Queries.GetCustomers;
using UpworkAssignment.Application.Customers.Commands.CreateCustomer;
using UpworkAssignment.Application.Customers.Commands.UpdateCustomer;
using UpworkAssignment.Application.Customers.Commands.DeleteCustomer;
using UpworkAssignment.Application.Appointments.Queries.GetAppointments;
using UpworkAssignment.Application.Appointments.Queries.GetAppointmentsWithPagination;
using UpworkAssignment.Application.Appointments.Commands.CreateAppointment;
using UpworkAssignment.Application.Appointments.Commands.UpdateAppointment;
using UpworkAssignment.Application.Appointments.Commands.DeleteAppointment;

namespace UpworkAssignment.WebApi.Controllers;


public class AppointmentsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<AppointmentDto>>> GetAppointmentsWithPagination([FromQuery] GetAppointmentsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateAppointmentCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateAppointmentCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteAppointmentCommand { Id = id });

        return NoContent();
    }
}
