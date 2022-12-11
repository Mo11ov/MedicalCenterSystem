namespace MCS.Web.ViewModels.Appointment
{
    using System;

    public class AppointmentViewModel
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string PatientName { get; set; }

        public string DoctorName { get; set; }
    }
}
