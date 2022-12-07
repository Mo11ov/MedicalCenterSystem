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
        [MaxLength(GlobalConstants.DepartmentNameMaxLength)]
        [MinLength(GlobalConstants.DepartmentNameMinLength)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<ApplicationUser> Doctors { get; set; }
    }
}
