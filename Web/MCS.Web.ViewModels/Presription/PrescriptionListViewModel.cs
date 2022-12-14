namespace MCS.Web.ViewModels.Presription
{
    using System.Collections.Generic;

    public class PrescriptionListViewModel
    {
        public PrescriptionListViewModel()
        {
            this.Prescriptions = new HashSet<PrescriptionViewModel>();
        }

        public IEnumerable<PrescriptionViewModel> Prescriptions { get; set; }
    }
}
