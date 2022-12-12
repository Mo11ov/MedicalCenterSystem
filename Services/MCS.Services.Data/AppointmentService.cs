namespace MCS.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    using MCS.Data.Common.Repositories;
    using MCS.Data.Models;
    using MCS.Web.ViewModels.Appointment;
    using Microsoft.EntityFrameworkCore;

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

        public async Task<AppointmentListViewModel> GetAllAsync()
        {
            var appointments = await this.appointmentRepository.AllAsNoTracking().ToListAsync();

            var appointmentModel = new AppointmentListViewModel
            {
                Appointments = appointments
                .Select(x => new AppointmentViewModel
                {
                    Id = x.Id,
                    PatientName = x.Patient.FirstName + " " + x.Patient.LastName,
                    DoctorName = x.Doctor.FirstName + " " + x.Doctor.LastName,
                    Date = x.DateTime.ToString("MMMM dd"),
                    Time = x.DateTime.ToString("h:mm tt"),
                }).ToArray()
                .OrderBy(x => x.Date)
                .ThenBy(x => x.Time),
            };

            return appointmentModel;
        }

        public Task<AppointmentListViewModel> GetByUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> GetByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task ConfirmAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
