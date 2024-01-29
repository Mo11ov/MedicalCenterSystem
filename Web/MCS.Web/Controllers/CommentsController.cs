namespace MCS.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using MCS.Services.Data;
    using MCS.Web.ViewModels.Comment;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CommentsController : BaseController
    {
        private readonly ICommentService commentService;

        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var comments = await this.commentService.GetAllByDateAsync();

            return this.View(comments);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            var model = new CommentInputModel();

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CommentInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.commentService.Create(model.Content, userId);

            return this.RedirectToAction(nameof(this.Index));
        }

    }
}
