namespace MCS.Web.ViewModels.Notification
{
    public class NotificationViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public bool IsRead { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }
    }
}
