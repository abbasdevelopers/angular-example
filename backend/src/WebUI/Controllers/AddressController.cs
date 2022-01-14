using UpworkAssignment.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UpworkAssignment.Application.Customers.Queries.GetCustomersWithPagination;
using UpworkAssignment.Application.Customers.Queries.GetCustomers;
using UpworkAssignment.Application.Customers.Commands.CreateCustomer;
using UpworkAssignment.Application.Customers.Commands.UpdateCustomer;
using UpworkAssignment.Application.Customers.Commands.DeleteCustomer;
using UpworkAssignment.Application.AppointmentAddresses.Queries.GetAppointmentAddresses;
using UpworkAssignment.Application.AppointmentAddresses.Queries.GetAppointmentAddressesWithPagination;
using UpworkAssignment.Application.AppointmentAddresses.Commands.CreateAppointmentAddresse;
using UpworkAssignment.Application.AppointmentAddresses.Commands.UpdateAppointmentAddress;
using UpworkAssignment.Application.AppointmentAddresses.Commands.DeleteAppointmentAddress;

namespace UpworkAssignment.WebApi.Controllers;


public class AddressController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<AppointmentAddressDto>>> GetCustomersWithPagination([FromQuery] GetAppointmentAddressesWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateAppointmentAddressCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateAppointmentAddressCommand command)
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
        await Mediator.Send(new DeleteAppointmentAddressCommand { Id = id });

        return NoContent();
    }
}
