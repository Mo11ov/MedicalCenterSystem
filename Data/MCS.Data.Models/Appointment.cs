namespace MCS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using MCS.Data.Common.Models;

    public class Appointment : BaseDeletableModel<int>
    {
        public DateTime DateTime { get; set; }

        public bool IsConfirmed { get; set; }

        public string PatientId { get; set; }

        [InverseProperty(nameof(ApplicationUser.PatientAppointments))]
        public virtual ApplicationUser Patient { get; set; }

        public string DoctorId { get; set; }

        [InverseProperty(nameof(ApplicationUser.DoctorAppointments))]
        public virtual ApplicationUser Doctor { get; set; }
    }
}
