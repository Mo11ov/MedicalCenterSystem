namespace MCS.Web.ViewModels.Presription
{
    using System.ComponentModel.DataAnnotations;

    using MCS.Common;
    using MCS.Web.ViewModels.User;

    public class PrescriptionInputModel
    {
        [Required]
        [StringLength(GlobalConstants.PrescriptionTreatmentMaxLength, MinimumLength = GlobalConstants.PrescriptionTreatmentMinLength)]
        public string Treatment { get; set; }

        public string DoctorId { get; set; }

        [Required]
        public string PatientId { get; set; }

        public UserListViewModel Users { get; set; }
    }
}
