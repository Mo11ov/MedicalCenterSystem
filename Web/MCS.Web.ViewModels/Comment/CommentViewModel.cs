namespace MCS.Web.ViewModels.Comment
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string CreatedOn { get; set; }

        public string OwnerName { get; set; }

        public string OwnerImgUrl { get; set; }
    }
}
