namespace MCS.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MCS.Data.Common.Repositories;
    using MCS.Data.Models;
    using Microsoft.EntityFrameworkCore;

    internal class PrescriptionService : IPrescriptionService
    {
        private readonly IDeletableEntityRepository<Prescription> prescriptionRepository;

        public PrescriptionService(IDeletableEntityRepository<Prescription> prescriptionRepository)
        {
            this.prescriptionRepository = prescriptionRepository;
        }

        public async Task AddAsync(string patientId, string doctorName, string treatment, DateTime issuedDate)
        {
            await this.prescriptionRepository.AddAsync(new Prescription
            {
                PatientId = patientId,
                DoctorsName = doctorName,
                Treatment = treatment,
                IssuedDate = issuedDate,
            });
        }

        public async Task DeleteAsync(int id)
        {
            var prescription = await this.prescriptionRepository.AllAsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            this.prescriptionRepository.Delete(prescription);

            await this.prescriptionRepository.SaveChangesAsync();
        }

        public Task<IEnumerable<Prescription>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Prescription>> GetAllByUserAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
