namespace MCS.Services.Data
{
    using System.Threading.Tasks;

    using MCS.Data.Models;
    using MCS.Web.ViewModels.Department;

    public interface IDepartmentService
    {
        Task<DepartmentListViewModel> GetAllAsync();

        Task<Department> GetByIdAsync(int id);

        Task AddAsync(string name, string description, string imageUrl);

        Task DeleteAsync(int id);
    }
}
