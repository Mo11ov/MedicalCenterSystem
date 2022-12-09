namespace MCS.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using MCS.Services.Data;
    using MCS.Web.ViewModels.Department;
    using Microsoft.AspNetCore.Mvc;

    public class DepartmentsController : BaseController
    {
        private readonly IDepartmentService departmentService;

        public DepartmentsController(IDepartmentService specialityService)
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
