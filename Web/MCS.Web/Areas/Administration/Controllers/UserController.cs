namespace MCS.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using MCS.Common;
    using MCS.Data.Models;
    using MCS.Services.Data;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UserController : AdministrationController
    {
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public UserController(
            IUserService patientService,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            this.userService = patientService;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await this.userService.GetAllAsync();

            return this.View(users);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await this.userService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpPost]
        public async Task<IActionResult> AssignDoctorRole(string id)
        {
            var user = await this.userService.GetById(id);

            var doctorRole = await this.roleManager.FindByNameAsync(GlobalConstants.DoctorRoleName);

            if (user.Roles.Any(x => x.RoleId == doctorRole.Id.ToString()))
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            await this.userManager.AddToRoleAsync(user, GlobalConstants.DoctorRoleName);

            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveDoctorRole(string id)
        {
            var user = await this.userService.GetById(id);

            await this.userManager.RemoveFromRoleAsync(user, GlobalConstants.DoctorRoleName);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
