﻿// ReSharper disable VirtualMemberCallInConstructor
namespace MCS.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MCS.Common;
    using MCS.Data.Common.Models;
    using MCS.Data.Models.Enums;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.PatientAppointments = new HashSet<Appointment>();
            this.DoctorAppointments = new HashSet<Appointment>();
            this.Comments = new HashSet<Comment>();
            this.Invoices = new HashSet<Invoice>();
            this.Notifications = new HashSet<Notification>();
            this.Patients = new HashSet<PatientDoctor>();
            this.Doctors = new HashSet<PatientDoctor>();
            this.PatientPrescriptions = new HashSet<Prescription>();
            this.DoctorPrescriptions = new HashSet<Prescription>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        [StringLength(GlobalConstants.NameMaxLength, MinimumLength = GlobalConstants.NameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(GlobalConstants.NameMaxLength, MinimumLength = GlobalConstants.NameMinLength)]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public string ImageUrl { get; set; }

        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<Appointment> PatientAppointments { get; set; }

        public virtual ICollection<Appointment> DoctorAppointments { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }

        public virtual ICollection<PatientDoctor> Patients { get; set; }

        public virtual ICollection<PatientDoctor> Doctors { get; set; }

        public virtual ICollection<Prescription> PatientPrescriptions { get; set; }

        public virtual ICollection<Prescription> DoctorPrescriptions { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
