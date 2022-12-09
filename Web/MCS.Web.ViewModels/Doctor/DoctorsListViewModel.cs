namespace MCS.Web.ViewModels.Doctor
{
    using System.Collections.Generic;

    public class DoctorsListViewModel
    {
        public DoctorsListViewModel()
        {
            this.Doctors = new HashSet<DoctorViewModel>();
        }

        public IEnumerable<DoctorViewModel> Doctors { get; set; }
    }
}
