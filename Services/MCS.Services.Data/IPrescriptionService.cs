namespace MCS.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MCS.Data.Models;

    public interface IPrescriptionService
    {
        Task AddAsync(string patientId, string doctorName, string treatment, DateTime issuedDate);

        Task DeleteAsync(int id);

        Task<IEnumerable<Prescription>> GetAllAsync();

        Task<IEnumerable<Prescription>> GetAllByUserAsync(string userId);
    }
}
