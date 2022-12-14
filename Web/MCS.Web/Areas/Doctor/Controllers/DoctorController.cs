namespace MCS.Web.Areas.Doctor.Controllers
{
    using MCS.Common;
    using MCS.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.DoctorRoleName)]
    [Area("Doctor")]
    public class DoctorController : BaseController
    {
    }
}
