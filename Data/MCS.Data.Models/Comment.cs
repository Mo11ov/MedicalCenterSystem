namespace MCS.Data.Models
{
    using MCS.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public string UserComment { get; set; }

        public int? AnswerId { get; set; }

        public virtual Comment Answer { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
