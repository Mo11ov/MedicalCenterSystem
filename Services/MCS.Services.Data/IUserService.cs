namespace MCS.Services.Data
{
    using System.Threading.Tasks;

    using MCS.Data.Models;
    using MCS.Web.ViewModels.User;

    public interface IUserService
    {
        Task<UserListViewModel> GetAllAsync();

        Task DeleteAsync(string id);

        Task<ApplicationUser> GetById(string id);
    }
}
