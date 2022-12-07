namespace MCS.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using MCS.Common;
    using MCS.Services.Data;
    using MCS.Web.ViewModels.Department;
    using Microsoft.AspNetCore.Mvc;

    public class DepartmentController : AdministrationController
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
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

        [HttpPost]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            if (id <= GlobalConstants.SeededDepartmentsCount)
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            await this.departmentService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
