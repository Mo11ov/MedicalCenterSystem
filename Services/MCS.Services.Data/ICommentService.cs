namespace MCS.Services.Data
{
    using System.Threading.Tasks;

    using MCS.Web.ViewModels.Comment;

    public interface ICommentService
    {
        Task<CommentsListViewModel> GetAllByDateAsync();

        Task Create(string content, string userId);

        Task Delete(int id);
    }
}
