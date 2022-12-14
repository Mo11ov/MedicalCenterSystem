namespace MCS.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using MCS.Common;
    using MCS.Data.Common.Repositories;
    using MCS.Data.Models;
    using MCS.Web.ViewModels.User;
    using Microsoft.EntityFrameworkCore;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public UserService(IDeletableEntityRepository<ApplicationUser> patientsRepository)
        {
            this.usersRepository = patientsRepository;
        }

        public async Task<UserListViewModel> GetAllAsync()
        {
            var users = await this.usersRepository
                .AllAsNoTracking()
                .Include(x => x.Roles)
                .ToListAsync();

            var usersModel = new UserListViewModel
            {
                Users = users.Select(x => new UserViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Role = !x.Roles.Any() ? "User" : GlobalConstants.DoctorRoleName,
                }).ToArray(),
            };

            return usersModel;
        }

        public async Task DeleteAsync(string id)
        {
            var user = await this.usersRepository.All().FirstOrDefaultAsync(x => x.Id == id);

            this.usersRepository.Delete(user);

            await this.usersRepository.SaveChangesAsync();
        }

        public async Task<ApplicationUser> GetById(string id)
        {
            return await this.usersRepository.All().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
