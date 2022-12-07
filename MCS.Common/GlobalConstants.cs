namespace MCS.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "Healthy Med";

        public const string AdministratorRoleName = "Administrator";

        public const string DoctorRoleName = "Doctor";

        // Data Validations
        public const int FirstNameMaxLength = 25;

        public const int FirstNameMinLength = 2;

        public const int LastNameMaxLength = 25;

        public const int LastNameMinLength = 2;

        public const int UserCommentMaxLength = 100;

        public const int UserCommentMinLength = 5;

        public const int InvoiceDescriptionMaxLength = 25;

        public const int InvoiceDescriptionMinLength = 5;

        public const int SpeciallityNameMaxLength = 25;

        public const int SpeciallityNameMinLength = 2;

        public const int NotificationContentMaxLength = 50;

        public const int NotificationContentMinLength = 5;

        public const int PrescriptionTreatmentMaxLength = 100;

        public const int PrescriptionTreatmentMinLength = 10;

        // Image strings
        public const string AllergyDepartmentImage = "https://res.cloudinary.com/healthy-med/image/upload/v1670419980/departments/AlergyDepartment_p3nzrh.jpg";

        public const string DermatolgyDepartmentImage = "https://res.cloudinary.com/healthy-med/image/upload/v1670418109/departments/dermatology_xgff1c.jpg";

        public const string FamilyDepartmentImage = "https://res.cloudinary.com/healthy-med/image/upload/v1670419980/departments/Family-Department_guqcry.jpg";

        public const string PediatricsDepartmentImage = "https://res.cloudinary.com/healthy-med/image/upload/v1670419980/departments/Pediatric-Department_wo658b.jpg";

        public const string UrologyDepartmentImage = "https://res.cloudinary.com/healthy-med/image/upload/v1670418097/departments/Urology-Department_pjimme.jpg";
    }
}
