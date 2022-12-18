namespace MCS.Services.Data.Tests.UseInMemoryDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Metadata;
    using System.Text;
    using System.Threading.Tasks;

    using MCS.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class CommentsServiceTest : BaseServiceTests
    {
        private ICommentService CommentService => this.ServiceProvider.GetRequiredService<ICommentService>();

        [Fact]
        public async Task CreateShouldAddComment()
        {
            var comment = this.CreateComentAsync();

            var ownerId = Guid.NewGuid().ToString();
            var content = "Hi how are you?";

            await this.CommentService.Create(content, ownerId);
            var count = await this.DbContext.Comments.CountAsync();

            Assert.Equal(2, count);
        }

        //[Fact]
        //public async Task DeleteShouldDeleteComment()
        //{
           
        //}


        private async Task<Comment> CreateComentAsync()
        {
            var comment = new Comment
            {
                UserId = Guid.NewGuid().ToString(),
                UserComment = "Some test text for testing purposes",
            };

            await this.DbContext.Comments.AddAsync(comment);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Comment>(comment).State = EntityState.Detached;

            return comment;
        }
    }
}