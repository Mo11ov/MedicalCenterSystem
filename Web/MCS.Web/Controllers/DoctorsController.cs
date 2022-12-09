namespace MCS.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using MCS.Services.Data;
    using MCS.Web.ViewModels.Doctor;
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

            var model = new DoctorsListViewModel
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

            return this.View(model);
        }
    }
}
