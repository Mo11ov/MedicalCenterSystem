namespace MCS.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using MCS.Data.Common.Repositories;
    using MCS.Data.Models;
    using MCS.Web.ViewModels.Comment;
    using Microsoft.EntityFrameworkCore;

    public class CommentService : ICommentService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task Create(string content, string userId)
        {
            await this.commentsRepository.AddAsync(new Comment
            {
                UserId = userId,
                UserComment = content,
            });

            await this.commentsRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var comment = await this.commentsRepository.All().FirstOrDefaultAsync(x => x.Id == id);

            this.commentsRepository.Delete(comment);

            await this.commentsRepository.SaveChangesAsync();
        }

        public async Task<CommentsListViewModel> GetAllByDateAsync()
        {
            var comments = await this.commentsRepository
                .AllAsNoTracking()
                .Include(x => x.User)
                .OrderByDescending(x => x.CreatedOn)
                .ToListAsync();

            var commentsModel = new CommentsListViewModel
            {
                Comments = comments.Select(x => new CommentViewModel
                {
                    Id = x.Id,
                    Content = x.UserComment,
                    OwnerName = x.User.FirstName + " " + x.User.LastName,
                    OwnerImgUrl = x.User.ImageUrl,
                    CreatedDate = x.CreatedOn.ToString("dd/MM/yyyy"),
                    CreatedTime = x.CreatedOn.ToString("hh:mm tt"),
                }).ToArray(),
            };

            return commentsModel;
        }
    }
}
