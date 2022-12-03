namespace MCS.Data.Models
{
    using System.Collections.Generic;

    using MCS.Data.Common.Models;

    public class Speciality : BaseDeletableModel<int>
    {
        public Speciality()
        {
            this.Doctors = new HashSet<ApplicationUser>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ApplicationUser> Doctors { get; set; }
    }
}
