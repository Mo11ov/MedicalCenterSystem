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

        public DepartmentService(IDeletableEntityRepository<Department> departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public async Task AddAsync(string name, string description, string imageUrl)
        {
            await this.departmentRepository.AddAsync(new Department
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
            });

            await this.departmentRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var department = await this.departmentRepository
                .AllAsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            this.departmentRepository.Delete(department);

            await this.departmentRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await this.departmentRepository.AllAsNoTracking().ToListAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            var department = await this.departmentRepository
                .AllAsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return department;
        }
    }
}
