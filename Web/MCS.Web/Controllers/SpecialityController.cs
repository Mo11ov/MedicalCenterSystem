namespace MCS.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using MCS.Services.Data;
    using MCS.Web.ViewModels.Speciality;
    using Microsoft.AspNetCore.Mvc;

    public class SpecialityController : BaseController
    {
        private readonly ISpecialtiesService specialityService;

        public SpecialityController(ISpecialtiesService specialityService)
        {
            this.specialityService = specialityService;
        }

        public async Task<IActionResult> Index()
        {
            var specilities = await this.specialityService.GetAllAsync();

            var model = new SpecialityListViewModel
            {
                Specialities = specilities
                .Select(s => new SpecialityViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                }).ToArray(),
            };

            return this.View(model);
        }
    }
}
