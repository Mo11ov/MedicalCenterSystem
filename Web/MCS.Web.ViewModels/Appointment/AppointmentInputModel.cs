namespace MCS.Web.ViewModels.Appointment
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MCS.Web.Infrastructure.CustomValidationAttributes;
    using MCS.Web.ViewModels.Doctor;

    public class AppointmentInputModel
    {
        [FromToday]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        [Required]
        public string DoctorId { get; set; }

        public DoctorsListViewModel Doctors { get; set; }
    }
}
