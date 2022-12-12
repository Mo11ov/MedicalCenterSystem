namespace MCS.Web.ViewModels.Appointment
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MCS.Web.ViewModels.Doctor;

    public class AppointmentInputModel
    {
        public DateTime Date { get; set; }

        // public DateTime Time { get; set; }
        public string DoctorId { get; set; }

        public DoctorsListViewModel Doctors { get; set; }
    }
}
