namespace MCS.Data.Models
{
    using System;
    using System.Collections.Generic;

    using MCS.Data.Common.Models;

    public class Invoice : BaseDeletableModel<int>
    {
        public string Description { get; set; }

        public decimal NetSum { get; set; }

        public decimal TotalSum { get; set; }

        public DateTime IssuedOn { get; set; }

        public bool IsPaid { get; set; }

        public string ClientId { get; set; }

        public virtual ApplicationUser Client { get; set; }
    }
}
