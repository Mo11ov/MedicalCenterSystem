namespace MCS.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MCS.Data.Models;

    public interface IDoctorService
    {
        Task<IEnumerable<ApplicationUser>> GetAllAsync();

        Task<IEnumerable<ApplicationUser>> GetAllByDepartmentAsync(int departmentId);

        Task<ApplicationUser> GetByIdAsync(string id);

        Task DeleteAsync(string id);
    }
}
