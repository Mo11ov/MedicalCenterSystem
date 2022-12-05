namespace MCS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MCS.Common;
    using MCS.Data.Common.Models;

    public class Prescription : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(GlobalConstants.PrescriptionTreatmentMaxLength)]
        [MinLength(GlobalConstants.PrescriptionTreatmentMinLength)]
        public string Treatment { get; set; }

        public string DoctorsName { get; set; }

        public DateTime IssuedDate { get; set; }

        public string PatientId { get; set; }

        public virtual ApplicationUser Patient { get; set; }
    }
}
