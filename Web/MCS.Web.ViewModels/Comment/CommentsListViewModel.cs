namespace MCS.Web.ViewModels.Comment
{
    using System.Collections.Generic;

    public class CommentsListViewModel
    {
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
