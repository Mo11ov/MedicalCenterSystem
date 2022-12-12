namespace MCS.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using MCS.Common;
    using MCS.Services;
    using MCS.Services.Data;
    using MCS.Web.ViewModels.Department;
    using Microsoft.AspNetCore.Mvc;

    public class DepartmentController : AdministrationController
    {
        private readonly IDepartmentService departmentService;
        private readonly ICloudinaryService cloudinaryService;

        public DepartmentController(
            IDepartmentService departmentService,
            ICloudinaryService cloudinaryService)
        {
            this.departmentService = departmentService;
            this.cloudinaryService = cloudinaryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var departments = await this.departmentService.GetAllAsync();

            return this.View(departments);
        }

        [HttpGet]
        public IActionResult AddDepartment()
        {
            var model = new DepartmentInputModel();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            string imageUrl = string.Empty;

            try
            {
                imageUrl = await this.cloudinaryService.UploadPictureAsync(model.Image, model.Name);
            }
            catch (System.Exception)
            {
                imageUrl = GlobalConstants.PediatricsDepartmentImage;
            }

            await this.departmentService.AddAsync(model.Name, model.Description, imageUrl);

            return this.RedirectToAction(nameof(this.Index));
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
