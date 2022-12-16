namespace MCS.Web.Areas.Doctor.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using MCS.Data.Models;
    using MCS.Services.Data;
    using MCS.Web.ViewModels.Presription;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PrescriptionController : DoctorController
    {
        private readonly IPrescriptionService prescriptionService;
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;

        public PrescriptionController(
            IPrescriptionService rescriptionService
            , IUserService userService,
            UserManager<ApplicationUser> userManager)
        {
            this.prescriptionService = rescriptionService;
            this.userService = userService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var doctorId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var allPrescriptions = await this.prescriptionService.GetAllByDoctorAsync(doctorId);

            return this.View(allPrescriptions);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new PrescriptionInputModel
            {
                Users = await this.userService.GetAllAsync(),
            };
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PrescriptionInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Users = await this.userService.GetAllAsync();
                return this.View(model);
            }

            var doctorId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.prescriptionService.AddAsync(model.PatientId, doctorId, model.Treatment, DateTime.Now);

            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.prescriptionService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
