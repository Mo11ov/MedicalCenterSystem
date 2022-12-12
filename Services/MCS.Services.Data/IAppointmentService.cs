namespace MCS.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using MCS.Data.Models;
    using MCS.Web.ViewModels.Appointment;

    public interface IAppointmentService
    {
        Task<AppointmentListViewModel> GetAllAsync();

        Task<AppointmentListViewModel> GetByUserAsync(string userId);

        Task<Appointment> GetByIdAsync();

        Task ConfirmAsync(int id);

        Task DeleteAsync(int id);

        Task AddAsync(string userId, string doctorId, DateTime dateTime);
    }
}
