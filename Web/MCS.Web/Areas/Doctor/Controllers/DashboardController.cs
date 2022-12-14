namespace MCS.Web.Areas.Doctor.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : DoctorController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
