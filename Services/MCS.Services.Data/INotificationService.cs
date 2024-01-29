namespace MCS.Services.Data
{
    using System.Threading.Tasks;

    using MCS.Web.ViewModels.Notification;

    public interface INotificationService
    {
        Task CreateAsync(string userId, string content);

        Task DeleteAsync(int id);

        Task MarkAsReadAsync(int id);

        Task<NotificationsListViewModel> GetAllSeenByUserAsync(string userId);

        Task<NotificationsListViewModel> GetAllNotSeenByUserAsync(string userId);

        Task<bool> GetUnreadNotifications(string id);
    }
}
