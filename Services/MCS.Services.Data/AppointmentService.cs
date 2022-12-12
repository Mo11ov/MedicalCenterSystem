namespace MCS.Services.Data
{
    using System;
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
            var appointments = await this.appointmentRepository
                .AllAsNoTracking()
                .Include(x => x.Doctor)
                .ThenInclude(d => d.Department)
                .ToListAsync();

            var appointmentModel = new AppointmentListViewModel
            {
                Appointments = appointments
                .Select(x => new AppointmentViewModel
                {
                    Id = x.Id,
                    PatientName = x.Patient.FirstName + " " + x.Patient.LastName,
                    DoctorName = x.Doctor.FirstName + " " + x.Doctor.LastName,
                    DoctorSpeciallity = x.Doctor.Department.Name,
                    Date = x.DateTime.ToString("MMMM dd"),
                    Time = x.DateTime.ToString("h:mm tt"),
                    IsConfirmed = x.IsConfirmed,
                }).ToArray()
                .OrderBy(x => x.Date)
                .ThenBy(x => x.Time),
            };

            return appointmentModel;
        }

        public async Task<Appointment> GetByIdAsync(int id)
        {
            return await this.appointmentRepository.AllAsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task ConfirmAsync(int id)
        {
            var appointment = await this.appointmentRepository.AllAsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            appointment.IsConfirmed = true;

            await this.appointmentRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var appointment = await this.appointmentRepository.AllAsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            this.appointmentRepository.Delete(appointment);

            await this.appointmentRepository.SaveChangesAsync();
        }

        public async Task<AppointmentListViewModel> GetByPatientAsync(string patientId)
        {
            var appointments = await this.appointmentRepository
                .AllAsNoTracking()
                .Where(x => x.Patient.Id == patientId)
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
                .ThenInclude(d => d.Department)
                .ToListAsync();

            var appointmentModel = new AppointmentListViewModel
            {
                Appointments = appointments
                .Select(x => new AppointmentViewModel
                {
                    Id = x.Id,
                    PatientName = x.Patient.FirstName + " " + x.Patient.LastName,
                    DoctorName = x.Doctor.FirstName + " " + x.Doctor.LastName,
                    DoctorSpeciallity = x.Doctor.Department.Name,
                    Date = x.DateTime.ToString("MMMM dd"),
                    Time = x.DateTime.ToString("h:mm tt"),
                    IsConfirmed = x.IsConfirmed,
                }).ToArray()
                .OrderBy(x => x.Date)
                .ThenBy(x => x.Time),
            };

            return appointmentModel;
        }

        public async Task<AppointmentListViewModel> GetByDoctorAsync(string doctorId)
        {
            var appointments = await this.appointmentRepository
                .AllAsNoTracking()
                .Where(x => x.Doctor.Id == doctorId)
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
                .ThenInclude(d => d.Department)
                .ToListAsync();

            var appointmentModel = new AppointmentListViewModel
            {
                Appointments = appointments
                .Select(x => new AppointmentViewModel
                {
                    Id = x.Id,
                    PatientName = x.Patient.FirstName + " " + x.Patient.LastName,
                    DoctorName = x.Doctor.FirstName + " " + x.Doctor.LastName,
                    DoctorSpeciallity = x.Doctor.Department.Name,
                    Date = x.DateTime.ToString("MMMM dd"),
                    Time = x.DateTime.ToString("h:mm tt"),
                    IsConfirmed = x.IsConfirmed,
                }).ToArray()
                .OrderBy(x => x.Date)
                .ThenBy(x => x.Time),
            };

            return appointmentModel;
        }
    }
}
