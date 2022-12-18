namespace MCS.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using MCS.Services.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class NotificationsController : BaseController
    {
        private readonly INotificationService notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var allNotifications = await this.notificationService.GetAllNotSeenByUserAsync(userId);

            return this.View(allNotifications);
        }

        [HttpGet]
        public async Task<IActionResult> Seen()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var allNotifications = await this.notificationService.GetAllSeenByUserAsync(userId);

            return this.View(allNotifications);
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            await this.notificationService.MarkAsReadAsync(id);

            return RedirectToAction(nameof(this.Index));
        }
    }
}
