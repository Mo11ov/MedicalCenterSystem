namespace MCS.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MCS.Data.Models;

    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllAsync();

        Task<Department> GetByIdAsync(int id);

        Task AddSync(string name, string description, string imageUrl);

        Task DeleteAsync(int id);
    }
}
