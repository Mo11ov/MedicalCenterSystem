namespace MCS.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MCS.Data.Common.Repositories;
    using MCS.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class SpecialtiesService : ISpecialtiesService
    {
        private readonly IDeletableEntityRepository<Speciality> specialityRepository;

        public SpecialtiesService(IDeletableEntityRepository<Speciality> specialityRepository)
        {
            this.specialityRepository = specialityRepository;
        }

        public async Task<IEnumerable<Speciality>> GetAllAsync()
        {
            return await this.specialityRepository.AllAsNoTracking().ToListAsync();
        }
    }
}
