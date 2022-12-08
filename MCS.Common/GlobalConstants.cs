namespace MCS.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "Healthy Med";

        public const string AdministratorRoleName = "Administrator";

        public const string DoctorRoleName = "Doctor";

        public const string UsersPassword = "123456";

        public const string AdminEmail = "admin@admin.com";

        public const string DoctorEmail = "doctor@doctor.com";

        public const string UserEmail = "user@appuser.com";

        // Data Validations
        public const int NameMaxLength = 25;

        public const int NameMinLength = 2;

        public const int UserCommentMaxLength = 100;

        public const int UserCommentMinLength = 5;

        public const int InvoiceDescriptionMaxLength = 25;

        public const int InvoiceDescriptionMinLength = 5;

        public const int DescriptionMinLength = 20;

        public const int DescriptionMaxLength = 500;

        public const int NotificationContentMaxLength = 50;

        public const int NotificationContentMinLength = 5;

        public const int PrescriptionTreatmentMaxLength = 100;

        public const int PrescriptionTreatmentMinLength = 10;

        // Image strings for seeded Departments
        public const string AllergyDepartmentImage = "https://res.cloudinary.com/healthy-med/image/upload/v1670419980/departments/AlergyDepartment_p3nzrh.jpg";

        public const string DermatolgyDepartmentImage = "https://res.cloudinary.com/healthy-med/image/upload/v1670418109/departments/dermatology_xgff1c.jpg";

        public const string FamilyDepartmentImage = "https://res.cloudinary.com/healthy-med/image/upload/v1670419980/departments/Family-Department_guqcry.jpg";

        public const string PediatricsDepartmentImage = "https://res.cloudinary.com/healthy-med/image/upload/v1670419980/departments/Pediatric-Department_wo658b.jpg";

        public const string UrologyDepartmentImage = "https://res.cloudinary.com/healthy-med/image/upload/v1670418097/departments/Urology-Department_pjimme.jpg";

        // Count of seeded data
        public const int SeededDepartmentsCount = 5;
    }
}
