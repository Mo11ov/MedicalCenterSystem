namespace MCS.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using MCS.Services.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class PrescriptionsController : BaseController
    {
        private readonly IPrescriptionService prescriptionService;

        public PrescriptionsController(IPrescriptionService prescriptionService)
        {
            this.prescriptionService = prescriptionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var patientId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var prescriptions = await this.prescriptionService.GetAllByPatientAsync(patientId);

            return this.View(prescriptions);
        }
    }
}
