namespace MCS.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MCS.Data.Models;

    public interface ISpecialtiesService
    {
        Task<IEnumerable<Speciality>> GetAllAsync();
    }
}
