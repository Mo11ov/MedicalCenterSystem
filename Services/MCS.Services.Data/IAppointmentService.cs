namespace MCS.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MCS.Data.Models;

    public interface IAppointmentService
    {
        Task<Appointment> GetByIdAsync();

        Task<IEnumerable<Appointment>> GetAllAsync();

        Task<IEnumerable<Appointment>> GetByDoctorAsync(string doctorId);

        Task ConfirmAsync(int id);

        Task DeleteAsync(int id);

        Task AddAsync(string userId, string doctorId, DateTime dateTime);
    }
}
