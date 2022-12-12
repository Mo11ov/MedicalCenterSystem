namespace MCS.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using MCS.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    public class AppointmentController : AdministrationController
    {
        private readonly IAppointmentService appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allApointments = await this.appointmentService.GetAllAsync();

            return this.View(allApointments);
        }

        [HttpPost]
        public async Task<IActionResult> CancelAppointment(int id)
        {
            await this.appointmentService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
