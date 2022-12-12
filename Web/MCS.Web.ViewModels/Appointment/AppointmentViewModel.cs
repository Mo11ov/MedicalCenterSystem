namespace MCS.Web.ViewModels.Appointment
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string PatientName { get; set; }

        public string DoctorName { get; set; }

        public string DoctorSpeciallity { get; set; }

        public bool IsConfirmed { get; set; }
    }
}
