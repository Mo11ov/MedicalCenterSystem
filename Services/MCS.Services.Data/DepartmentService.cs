namespace MCS.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MCS.Data.Common.Repositories;
    using MCS.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class DepartmentService : IDepartmentService
    {
        private readonly IDeletableEntityRepository<Department> departmentRepository;

        public DepartmentService(IDeletableEntityRepository<Department> specialityRepository)
        {
            this.departmentRepository = specialityRepository;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await this.departmentRepository.AllAsNoTracking().ToListAsync();
        }
    }
}
