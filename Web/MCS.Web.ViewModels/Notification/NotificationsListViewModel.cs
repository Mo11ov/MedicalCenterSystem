namespace MCS.Web.ViewModels.Notification
{
    using System.Collections.Generic;

    public class NotificationsListViewModel
    {
        public IEnumerable<NotificationViewModel> Notifications { get; set; }
    }
}
