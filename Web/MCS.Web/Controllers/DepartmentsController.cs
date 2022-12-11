namespace MCS.Web.Controllers
{
    using System.Threading.Tasks;

    using MCS.Services.Data;
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

            return this.View(departments);
        }
    }
}
