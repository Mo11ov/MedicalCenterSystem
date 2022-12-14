namespace MCS.Common.CustomValidationAttributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FromTodayAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = Convert.ToDateTime(value);

            if (DateTime.Compare(date, DateTime.Now) > 0)
            {
                return true;
            }

            return false;
        }
    }
}
