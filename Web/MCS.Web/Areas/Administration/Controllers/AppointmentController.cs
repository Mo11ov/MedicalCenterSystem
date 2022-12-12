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
    }
}
