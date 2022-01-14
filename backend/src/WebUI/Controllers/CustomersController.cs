using UpworkAssignment.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UpworkAssignment.Application.Customers.Queries.GetCustomersWithPagination;
using UpworkAssignment.Application.Customers.Queries.GetCustomers;
using UpworkAssignment.Application.Customers.Commands.CreateCustomer;
using UpworkAssignment.Application.Customers.Commands.UpdateCustomer;
using UpworkAssignment.Application.Customers.Commands.DeleteCustomer;
using UpworkAssignment.WebUI.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace UpworkAssignment.WebApi.Controllers;


public class CustomersController : ApiControllerBase
{
    private readonly IHubContext<CustomerHub> _customerHub;

    public CustomersController(
        IHubContext<CustomerHub> customerHub
        )
    {
        _customerHub = customerHub;
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<CustomerDto>>> GetCustomersWithPagination([FromQuery] GetCustomersWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateCustomerCommand command)
    {
        var customerId = await Mediator.Send(command);
        
        await _customerHub.Clients.All.SendAsync("CustomerAdded", customerId);

        return customerId;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateCustomerCommand command)
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
        await Mediator.Send(new DeleteCustomerCommand { Id = id });

        return NoContent();
    }
}
