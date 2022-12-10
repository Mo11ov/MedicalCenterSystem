namespace MCS.Web.Controllers
{
    using MCS.Data.Models;
    using MCS.Services.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;

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
    }
}
