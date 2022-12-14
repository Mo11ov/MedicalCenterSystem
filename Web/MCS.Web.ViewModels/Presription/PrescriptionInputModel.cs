namespace MCS.Web.ViewModels.Presription
{
    using System;

    public class PrescriptionInputModel
    {
        public string Treatment { get; set; }

        public DateTime IssuedDateTime { get; set; }

        public string DoctorName { get; set; }

        public string PatientId { get; set; }
    }
}
