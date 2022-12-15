namespace MCS.Web.ViewModels.Presription
{
    public class PrescriptionViewModel
    {
        public int Id { get; set; }

        public string Treatment { get; set; }

        public string IssuedDate { get; set; }

        public string IssuedTime { get; set; }

        public string DoctorName { get; set; }

        public string PatientName { get; set; }
    }
}
