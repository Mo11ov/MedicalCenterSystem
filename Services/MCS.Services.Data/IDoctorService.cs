namespace MCS.Services.Data
{
    using System.Threading.Tasks;

    using MCS.Web.ViewModels.Doctor;

    public interface IDoctorService
    {
        Task<DoctorsListViewModel> GetAllAsync();

        Task<DoctorsListViewModel> GetAllByDepartmentAsync(int departmentId);

        Task<DoctorViewModel> GetByIdAsync(string id);

        Task DeleteAsync(string id);
    }
}
