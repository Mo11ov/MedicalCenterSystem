namespace MCS.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MCS.Data.Common.Repositories;
    using MCS.Data.Models;
    using MCS.Web.ViewModels.Presription;
    using Microsoft.EntityFrameworkCore;

    public class PrescriptionService : IPrescriptionService
    {
        private readonly IDeletableEntityRepository<Prescription> prescriptionRepository;

        public PrescriptionService(IDeletableEntityRepository<Prescription> prescriptionRepository)
        {
            this.prescriptionRepository = prescriptionRepository;
        }

        public async Task AddAsync(string patientId, string doctorId, string treatment, DateTime issuedDate)
        {
            await this.prescriptionRepository.AddAsync(new Prescription
            {
                PatientId = patientId,
                DoctorId = doctorId,
                Treatment = treatment,
                IssuedDate = issuedDate,
            });

            await this.prescriptionRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var prescription = await this.prescriptionRepository.AllAsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            this.prescriptionRepository.Delete(prescription);

            await this.prescriptionRepository.SaveChangesAsync();
        }

        public async Task<PrescriptionListViewModel> GetAllAsync()
        {
            var prescriptions = await this.prescriptionRepository
                .AllAsNoTracking()
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
                .ToListAsync();

            var prescriptionModel = new PrescriptionListViewModel
            {
                Prescriptions = prescriptions.Select(x => new PrescriptionViewModel
                {
                    PatientName = x.Patient.FirstName + " " + x.Patient.LastName,
                    DoctorName = x.Doctor.FirstName + " " + x.Doctor.LastName,
                    Treatment = x.Treatment,
                    IssuedDate = x.IssuedDate.ToString("MMMM dd"),
                    IssuedTime = x.IssuedDate.ToString("h:mm tt"),
                }),
            };

            return prescriptionModel;
        }

        public async Task<PrescriptionListViewModel> GetAllByDoctorAsync(string doctorId)
        {
            var prescriptions = await this.prescriptionRepository
               .AllAsNoTracking()
               .Where(x => x.DoctorId == doctorId)
               .Include(x => x.Patient)
               .Include(x => x.Doctor)
               .ToListAsync();

            var prescriptionModel = new PrescriptionListViewModel
            {
                Prescriptions = prescriptions.Select(x => new PrescriptionViewModel
                {
                    PatientName = x.Patient.FirstName + " " + x.Patient.LastName,
                    DoctorName = x.Doctor.FirstName + " " + x.Doctor.LastName,
                    Treatment = x.Treatment,
                    IssuedDate = x.IssuedDate.ToString("MMMM dd"),
                    IssuedTime = x.IssuedDate.ToString("h:mm tt"),
                }),
            };

            return prescriptionModel;
        }

        public async Task<PrescriptionListViewModel> GetAllByPatientAsync(string patientId)
        {
            var prescriptions = await this.prescriptionRepository
                .AllAsNoTracking()
                .Where(x => x.PatientId == patientId)
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
                .ToListAsync();

            var prescriptionModel = new PrescriptionListViewModel
            {
                Prescriptions = prescriptions.Select(x => new PrescriptionViewModel
                {
                    PatientName = x.Patient.FirstName + " " + x.Patient.LastName,
                    DoctorName = x.Doctor.FirstName + " " + x.Doctor.LastName,
                    Treatment = x.Treatment,
                    IssuedDate = x.IssuedDate.ToString("MMMM dd"),
                    IssuedTime = x.IssuedDate.ToString("h:mm tt"),
                }),
            };

            return prescriptionModel;
        }
    }
}
