namespace MCS.Web.Controllers
{
    using System.Threading.Tasks;

    using MCS.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    public class DoctorsController : BaseController
    {
        private readonly IDoctorService doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var doctors = await this.doctorService.GetAllAsync();

            return this.View(doctors);
        }

        [HttpGet]
        public async Task<IActionResult> DoctorsByDepartment(int departmentId)
        {
            var doctors = await this.doctorService.GetAllByDepartmentAsync(departmentId);

            return this.View(doctors);
        }
    }
}
