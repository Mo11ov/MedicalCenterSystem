namespace MCS.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MCS.Data.Common.Repositories;
    using MCS.Data.Models;

    public class AppointmentService : IAppointmentService
    {
        private readonly IDeletableEntityRepository<Appointment> appointmentRepository;

        public AppointmentService(IDeletableEntityRepository<Appointment> appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }

        public async Task AddAsync(string userId, string doctorId, DateTime dateTime)
        {
            await this.appointmentRepository.AddAsync(new Appointment
            {
                PatientId = userId,
                DoctorId = doctorId,
                DateTime = dateTime,
            });

            await this.appointmentRepository.SaveChangesAsync();
        }

        public Task ConfirmAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Appointment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Appointment>> GetByDoctorAsync(string doctorId)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> GetByIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}
