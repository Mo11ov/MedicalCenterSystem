namespace MCS.Web.ViewModels.Appointment
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AppointmentInputModel
    {
        public DateTime Date { get; set; }

        //public DateTime Time { get; set; }

        [Required]
        public string DoctorId { get; set; }
    }
}
