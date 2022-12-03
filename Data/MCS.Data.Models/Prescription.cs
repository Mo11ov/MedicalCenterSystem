namespace MCS.Data.Models
{
    using System;

    using MCS.Data.Common.Models;

    public class Prescription : BaseDeletableModel<int>
    {
        public string Treatment { get; set; }

        public string DoctorsName { get; set; }

        public DateTime IssuedDate { get; set; }

        public string PatientId { get; set; }

        public virtual ApplicationUser Patient { get; set; }
    }
}
