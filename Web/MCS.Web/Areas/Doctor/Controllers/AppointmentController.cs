namespace MCS.Web.Areas.Doctor.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using MCS.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    public class AppointmentController : DoctorController
    {
        private readonly IAppointmentService appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var allApointments = await this.appointmentService.GetByDoctorAsync(userId);

            return this.View(allApointments);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await this.appointmentService.GetByIdAsync(id);

            if (appointment.IsConfirmed == true)
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            await this.appointmentService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmAppointment(int id)
        {
            await this.appointmentService.ConfirmAsync(id);

            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpPost]
        public async Task<IActionResult> CancelAppointment(int id)
        {
            await this.appointmentService.CancelAsync(id);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
