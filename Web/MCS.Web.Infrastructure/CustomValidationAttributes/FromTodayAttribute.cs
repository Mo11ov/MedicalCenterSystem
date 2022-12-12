namespace MCS.Web.Infrastructure.CustomValidationAttributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FromTodayAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = Convert.ToDateTime(value);

            if (DateTime.Compare(date, DateTime.Now) < 0)
            {
                return new ValidationResult("Date must be past now");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
