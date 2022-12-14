namespace MCS.Web.Areas.Doctor.Controllers
{
    using System.Threading.Tasks;

    using MCS.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    public class PrescriptionController : DoctorController
    {
        private readonly IPrescriptionService rescriptionService;

        public PrescriptionController(IPrescriptionService rescriptionService)
        {
            this.rescriptionService = rescriptionService;
        }

        public async Task<IActionResult> Index()
        {
            return this.View();
        }
    }
}
