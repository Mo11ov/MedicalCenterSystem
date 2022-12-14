namespace MCS.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using MCS.Web.ViewModels.Presription;

    public interface IPrescriptionService
    {
        Task AddAsync(string patientId, string doctorName, string treatment, DateTime issuedDate);

        Task DeleteAsync(int id);

        Task<PrescriptionListViewModel> GetAllAsync();

        Task<PrescriptionListViewModel> GetAllByUserAsync(string userId);
    }
}
