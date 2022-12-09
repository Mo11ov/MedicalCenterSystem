namespace MCS.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MCS.Common;
    using MCS.Data.Common.Repositories;
    using MCS.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class DoctorService : IDoctorService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> doctorsRepository;
        private readonly RoleManager<ApplicationRole> roleManager;

        public DoctorService(
            IDeletableEntityRepository<ApplicationUser> doctorsRepository,
            RoleManager<ApplicationRole> roleManager)
        {
            this.doctorsRepository = doctorsRepository;
            this.roleManager = roleManager;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            var role = await this.roleManager.FindByNameAsync(GlobalConstants.DoctorRoleName);

            return await this.doctorsRepository
                .AllAsNoTracking()
                .Where(x => x.Roles.Any(r => r.RoleId == role.Id))
                .Include(x => x.Department)
                .ToListAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllByDepartmentAsync(int departmentId)
        {
            var role = await this.roleManager.FindByNameAsync(GlobalConstants.DoctorRoleName);

            return await this.doctorsRepository
                .AllAsNoTracking()
                .Where(x => x.Roles.Any(r => r.RoleId == role.Id) && x.DepartmentId == departmentId)
                .Include(x => x.Department)
                .ToListAsync();
        }

        public async Task<ApplicationUser> GetByIdAsync(string id)
        {
            return await this.doctorsRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.Department)
                .FirstOrDefaultAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var doctor = await this.doctorsRepository.AllAsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            this.doctorsRepository.Delete(doctor);

            await this.doctorsRepository.SaveChangesAsync();
        }
    }
}
