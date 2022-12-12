namespace MCS.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using MCS.Common;
    using MCS.Data.Common.Repositories;
    using MCS.Data.Models;
    using MCS.Web.ViewModels.Doctor;
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

        public async Task<DoctorsListViewModel> GetAllAsync()
        {
            var role = await this.roleManager.FindByNameAsync(GlobalConstants.DoctorRoleName);

            var doctors = await this.doctorsRepository
                .AllAsNoTracking()
                .Where(x => x.Roles.Any(r => r.RoleId == role.Id) && x.Department != null)
                .Include(x => x.Department)
                .ToListAsync();

            var doctrosModel = new DoctorsListViewModel
            {
                Doctors = doctors
                .Select(x => new DoctorViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ImageUrl = x.ImageUrl,
                    DepartmentId = (int)x.DepartmentId,
                    DepartmentName = x.Department.Name,
                }).ToArray()
                .OrderByDescending(x => x.DepartmentName),
            };

            return doctrosModel;
        }

        public async Task<DoctorsListViewModel> GetAllByDepartmentAsync(int departmentId)
        {
            var role = await this.roleManager.FindByNameAsync(GlobalConstants.DoctorRoleName);

            var doctors = await this.doctorsRepository
                .All()
                .Where(x => x.Roles.Any(r => r.RoleId == role.Id) && x.DepartmentId == departmentId)
                .Include(x => x.Department)
                .ToListAsync();

            var doctorsModel = new DoctorsListViewModel
            {
                Doctors = doctors
               .Select(x => new DoctorViewModel
               {
                   Id = x.Id,
                   FirstName = x.FirstName,
                   LastName = x.LastName,
                   ImageUrl = x.ImageUrl,
                   DepartmentId = (int)x.DepartmentId,
                   DepartmentName = x.Department.Name,
               }).ToArray(),
            };

            return doctorsModel;
        }

        public async Task<DoctorViewModel> GetByIdAsync(string id)
        {
            var doctor = await this.doctorsRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.Department)
                .FirstOrDefaultAsync();

            var doctorModel = new DoctorViewModel
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                ImageUrl = doctor.ImageUrl,
                DepartmentId = (int)doctor.DepartmentId,
                DepartmentName = doctor.Department.Name,
            };

            return doctorModel;
        }

        public async Task DeleteAsync(string id)
        {
            var doctor = await this.doctorsRepository.AllAsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            this.doctorsRepository.Delete(doctor);

            await this.doctorsRepository.SaveChangesAsync();
        }
    }
}
