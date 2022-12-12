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
        private readonly IDoctorService doctorService;

        public AppointmentsController(
            IAppointmentService appointmentsService,
            IDoctorService doctorService,
            UserManager<ApplicationUser> userManager)
        {
            this.appointmentsService = appointmentsService;
            this.doctorService = doctorService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var userId = await this.userManager.GetUserIdAsync(user);
            var appointments = await this.appointmentsService.GetByPatientAsync(userId);

            return this.View(appointments);
        }

        [HttpGet]
        public async Task<IActionResult> MakeAppointment()
        {
            var model = new AppointmentInputModel
            {
                Doctors = await this.doctorService.GetAllAsync(),
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MakeAppointment(AppointmentInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(this.MakeAppointment));
            }

            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var patientId = await this.userManager.GetUserIdAsync(user);

            await this.appointmentsService.AddAsync(patientId, model.DoctorId, model.Date);

            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpPost]
        public async Task<IActionResult> CancelAppointment(int id)
        {
            await this.appointmentsService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
