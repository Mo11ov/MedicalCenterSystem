namespace MCS.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using MCS.Data.Common.Models;

    public class PatientDoctor : BaseDeletableModel<int>
    {
        public string PatientId { get; set; }

        [InverseProperty(nameof(ApplicationUser.Patients))]
        public virtual ApplicationUser Patient { get; set; }

        public string DoctorId { get; set; }

        [InverseProperty(nameof(ApplicationUser.Doctors))]
        public virtual ApplicationUser Doctor { get; set; }
    }
}
