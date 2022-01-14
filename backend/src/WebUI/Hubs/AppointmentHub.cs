using Microsoft.AspNetCore.SignalR;

namespace UpworkAssignment.WebUI.Hubs;

public class AppointmentHub : Hub<IAppointmentHub>
{
    public async Task AppointmentAdded(int userId, int appointmentId)
    {
        await Clients.All.AppointmentAdded(userId, appointmentId);
    }
}
public interface IAppointmentHub
{
    Task AppointmentAdded(int userId, int appointmentId);
}
