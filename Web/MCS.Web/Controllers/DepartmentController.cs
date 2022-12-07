namespace MCS.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using MCS.Services.Data;
    using MCS.Web.ViewModels.Speciality;
    using Microsoft.AspNetCore.Mvc;

    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService specialityService)
        {
            this.departmentService = specialityService;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await this.departmentService.GetAllAsync();

            var model = new DepartmentListViewModel
            {
                Departments = departments
                .Select(s => new DepartmentViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    ImageUrl = s.ImageUrl,
                }).ToArray(),
            };

            return this.View(model);
        }
    }

    
}
