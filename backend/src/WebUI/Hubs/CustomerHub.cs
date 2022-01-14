using Microsoft.AspNetCore.SignalR;

namespace UpworkAssignment.WebUI.Hubs;

public class CustomerHub : Hub<ICustomerHub>
{
    public async Task CustomerAdded(int customerId)
    {
        await Clients.All.CustomerAdded(customerId);
    }
}
public interface ICustomerHub
{
    Task CustomerAdded(int customerId);
}
