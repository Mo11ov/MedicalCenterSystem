namespace MCS.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using MCS.Data.Common.Repositories;
    using MCS.Data.Models;
    using MCS.Web.ViewModels.Notification;
    using Microsoft.EntityFrameworkCore;

    public class NotificationService : INotificationService
    {
        private readonly IDeletableEntityRepository<Notification> notificationRepository;

        public NotificationService(IDeletableEntityRepository<Notification> notificationRepository)
        {
                this.notificationRepository = notificationRepository;
        }

        public async Task CreateAsync(string userId, string content)
        {
            await this.notificationRepository.AddAsync(new Notification
            {
                UserId = userId,
                Content = content,
            });

            await this.notificationRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var notification = await this.notificationRepository.All().FirstOrDefaultAsync(x => x.Id == id);

            this.notificationRepository.Delete(notification);

            await this.notificationRepository.SaveChangesAsync();
        }

        public async Task MarkAsReadAsync(int id)
        {
            var notification = await this.notificationRepository.All().FirstOrDefaultAsync(x => x.Id == id);

            notification.IsRead = true;

            await this.notificationRepository.SaveChangesAsync();
        }

        public async Task<NotificationsListViewModel> GetAllSeenByUserAsync(string id)
        {
            var notifications = await this.notificationRepository
                .AllAsNoTracking()
                .Where(x => x.UserId == id && x.IsRead == true)
                .OrderBy(x => x.CreatedOn)
                .ToListAsync();

            var notificationModel = new NotificationsListViewModel
            {
                Notifications = notifications.Select(x => new NotificationViewModel
                {
                    Id = x.Id,
                    Content = x.Content,
                    IsRead = x.IsRead,
                    Date = x.CreatedOn.ToString("MMMM dd"),
                    Time = x.CreatedOn.ToString("h:mm tt"),
                }).ToArray(),
            };

            return notificationModel;
        }

        public async Task<NotificationsListViewModel> GetAllNotSeenByUserAsync(string id)
        {
            var notifications = await this.notificationRepository
                .AllAsNoTracking()
                .Where(x => x.UserId == id && x.IsRead == false)
                .OrderBy(x => x.CreatedOn)
                .ToListAsync();

            var notificationModel = new NotificationsListViewModel
            {
                Notifications = notifications.Select(x => new NotificationViewModel
                {
                    Id = x.Id,
                    Content = x.Content,
                    IsRead = x.IsRead,
                    Date = x.CreatedOn.ToString("MMMM dd"),
                    Time = x.CreatedOn.ToString("h:mm tt"),
                }).ToArray(),
            };

            return notificationModel;
        }

        public async Task<bool> GetUnreadNotifications(string id)
        {
            var notifications = await this.notificationRepository
                .AllAsNoTracking()
                .Where(x => x.UserId == id && x.IsRead == false)
                .OrderBy(x => x.CreatedOn)
                .ToListAsync();

            if (notifications.Count > 0)
            {
                return true;
            }

            return false;
        }
    }
}
