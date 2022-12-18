namespace MCS.Services.Data.Tests.UseInMemoryDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MCS.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class UsersServicesTest : BaseServiceTests
    {
        private IUserService UserService => this.ServiceProvider.GetRequiredService<IUserService>();

        [Fact]
        public async Task DeleteShouldRemoveUserFromDb()
        {
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = "somename@admin.com",
                FirstName = "Pesho",
                LastName = "Petrov",
            };
            await this.DbContext.Users.AddAsync(user);
            await this.DbContext.SaveChangesAsync();

            await this.UserService.DeleteAsync(user.Id);
            var count = await this.DbContext.Users.Where(x => !x.IsDeleted).CountAsync();
            Assert.Equal(0, count);
        }

        [Fact]
        public async Task GetByIdShouldReturnUser()
        {
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = "somename@admin.com",
                FirstName = "Pesho",
                LastName = "Petrov",
            };
            await this.DbContext.Users.AddAsync(user);
            await this.DbContext.SaveChangesAsync();

            var returnedUser = await this.UserService.GetById(user.Id);

            Assert.NotNull(returnedUser);
        }
    }
}
