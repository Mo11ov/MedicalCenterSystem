namespace MCS.Web.Hubs
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.SignalR;

    public class AppointmentHub : Hub
    {
        public async Task NotifyAppointmentConfirmation(string userId)
        {
            await this.Clients.User(userId).SendAsync("appointmentConfirmed");
        }
    }
}
