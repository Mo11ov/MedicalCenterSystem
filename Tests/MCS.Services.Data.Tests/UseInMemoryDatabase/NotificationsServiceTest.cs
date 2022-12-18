using System.Linq;

namespace MCS.Services.Data.Tests.UseInMemoryDatabase
{
    using System;
    using System.Threading.Tasks;

    using MCS.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class NotificationsServiceTest : BaseServiceTests
    {
        private INotificationService NotificationService =>
            this.ServiceProvider.GetRequiredService<INotificationService>();

        [Fact]
        public async Task CreateShouldAddNotificationToDb()
        {
            var notification = this.CreateNotificationAsync();
            var count = await this.DbContext.Notifications.CountAsync();

            Assert.Equal(1, count);

            var userId = Guid.NewGuid().ToString();
            var content = "You have notification";

            await this.NotificationService.CreateAsync(userId, content);
            var secondCount = await this.DbContext.Notifications.CountAsync();

            Assert.Equal(2, secondCount);
        }

        [Fact]
        public async Task GetAllNotSeenByUserShouldReturnNotReadNotifications()
        {
            var userId = Guid.NewGuid().ToString();
            var content = "Some test text";
            await this.NotificationService.CreateAsync(userId, content);

            var notificationCount = await this.DbContext.Notifications.CountAsync();

            Assert.Equal(1, notificationCount);

            await this.NotificationService.CreateAsync(userId, content);
            var result
                = await this.NotificationService.GetAllNotSeenByUserAsync(userId);
            var count = result.Notifications.Count();
            Assert.Equal(2, count);
        }

        [Fact]
        public async Task GetAllSeenByUserShouldReturnOnlyReadNotifications()
        {
            var userId = Guid.NewGuid().ToString();
            var content = "Some test text";
            var noti = this.DbContext.Notifications
                .AddAsync(new Notification
                {
                    UserId = userId,
                    Content = content,
                    IsRead = true,
                });

            var notification = this.DbContext.Notifications
                .AddAsync(new Notification
                {
                    UserId = userId,
                    Content = content,
                    IsRead = true,
                });
            await this.DbContext.SaveChangesAsync();

            var result
                = await this.NotificationService.GetAllSeenByUserAsync(userId);
            var count = result.Notifications.Count();
            Assert.Equal(2, count);
        }

        [Fact]
        public async Task DeleteShouldRemoveFromDb()
        {
            var notification = this.CreateNotificationAsync();
            await this.NotificationService.DeleteAsync(notification.Id);

            var count = this.DbContext.Notifications.Where(x => !x.IsDeleted).ToArray().Count();

            Assert.Equal(0, count);
        }

        [Fact]
        public async Task ConfirmAsyncShouldChangeStatusToConfirm()
        {
            var notification = await this.CreateNotificationAsync();

            await this.NotificationService.MarkAsReadAsync(notification.Id);
            var result = await this.DbContext.Notifications.Where(x => x.Id == notification.Id).Select(x => x.IsRead).FirstOrDefaultAsync();
            Assert.True(result);
        }


        private async Task<Notification> CreateNotificationAsync()
        {
            var notification = new Notification
            {
                UserId = Guid.NewGuid().ToString(),
                Content = "Something to announce",
            };

            await this.DbContext.Notifications.AddAsync(notification);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Notification>(notification).State = EntityState.Detached;

            return notification;
        }
    }
}
