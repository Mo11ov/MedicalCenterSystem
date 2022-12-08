namespace MCS.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using MCS.Common;
    using MCS.Data.Common.Models;

    public class Notification : BaseDeletableModel<int>
    {
        [Required]
        [StringLength(GlobalConstants.NotificationContentMaxLength, MinimumLength = GlobalConstants.NotificationContentMinLength)]
        public string Content { get; set; }

        public string Url { get; set; }

        public bool IsRead { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
