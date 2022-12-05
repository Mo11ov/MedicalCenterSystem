namespace MCS.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using MCS.Common;
    using MCS.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(GlobalConstants.UserCommentMaxLength)]
        [MinLength(GlobalConstants.UserCommentMinLength)]
        public string UserComment { get; set; }

        public int? AnswerId { get; set; }

        public virtual Comment Answer { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
