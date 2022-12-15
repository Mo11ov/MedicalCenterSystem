namespace MCS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using MCS.Common;
    using MCS.Data.Common.Models;

    public class Prescription : BaseDeletableModel<int>
    {
        [Required]
        [StringLength(GlobalConstants.PrescriptionTreatmentMaxLength, MinimumLength = GlobalConstants.PrescriptionTreatmentMinLength)]
        public string Treatment { get; set; }

        public DateTime IssuedDate { get; set; }

        public string DoctorId { get; set; }

        [InverseProperty(nameof(ApplicationUser.DoctorPrescriptions))]
        public virtual ApplicationUser Doctor { get; set; }

        public string PatientId { get; set; }

        [InverseProperty(nameof(ApplicationUser.PatientPrescriptions))]
        public virtual ApplicationUser Patient { get; set; }
    }
}
