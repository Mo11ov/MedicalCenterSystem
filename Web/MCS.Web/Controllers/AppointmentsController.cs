namespace MCS.Web.Controllers
{
    using System.Threading.Tasks;

    using MCS.Data.Models;
    using MCS.Services.Data;
    using MCS.Web.ViewModels.Appointment;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class AppointmentsController : BaseController
    {
        private readonly IAppointmentService appointmentsService;
        private readonly UserManager<ApplicationUser> userManager;

        public AppointmentsController(
            IAppointmentService appointmentsService,
            UserManager<ApplicationUser> userManager)
        {
            this.appointmentsService = appointmentsService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var patient = await this.userManager.GetUserAsync(this.HttpContext.User);
            var patientId = await this.userManager.GetUserIdAsync(patient);
            var appointments = await this.appointmentsService.GetByPatientAsync(patientId);

            return this.View(appointments);
        }

        [HttpGet]
        public async Task<IActionResult> MakeAppointment(string doctorId)
        {
            var model = new AppointmentInputModel
            {
                DoctorId = doctorId,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MakeAppointment(AppointmentInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(this.MakeAppointment), new { model.DoctorId });
            }

            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var patientId = await this.userManager.GetUserIdAsync(user);

            await this.appointmentsService.AddAsync(patientId, model.DoctorId, model.Date);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
