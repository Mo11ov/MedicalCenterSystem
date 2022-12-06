namespace MCS.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MCS.Common;
    using MCS.Data.Common.Models;

    public class Department : BaseDeletableModel<int>
    {
        public Department()
        {
            this.Doctors = new HashSet<ApplicationUser>();
        }

        [Required]
        [MaxLength(GlobalConstants.SpeciallityNameMaxLength)]
        [MinLength(GlobalConstants.SpeciallityNameMinLength)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ApplicationUser> Doctors { get; set; }
    }
}
