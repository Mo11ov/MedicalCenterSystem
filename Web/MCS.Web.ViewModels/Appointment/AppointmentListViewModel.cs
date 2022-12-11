namespace MCS.Web.ViewModels.Appointment
{
    using System.Collections.Generic;

    public class AppointmentListViewModel
    {
        public AppointmentListViewModel()
        {
            this.Appointments = new HashSet<AppointmentViewModel>();
        }

        public IEnumerable<AppointmentViewModel> Appointments { get; set; }
    }
}
