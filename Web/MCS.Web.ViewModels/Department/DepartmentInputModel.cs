namespace MCS.Web.ViewModels.Department
{
    using System.ComponentModel.DataAnnotations;

    using MCS.Common;
    using MCS.Common.CustomValidationAttributes;
    using Microsoft.AspNetCore.Http;

    public class DepartmentInputModel
    {
        [Required]
        [StringLength(GlobalConstants.NameMaxLength, MinimumLength = GlobalConstants.NameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(GlobalConstants.DescriptionMaxLength, MinimumLength = GlobalConstants.DescriptionMinLength)]
        public string Description { get; set; }

        [DataType(DataType.Upload)]
        [ImageFileAttribute(ErrorMessage = "Image should be JPG, PNG or JPEG and less than 1MB")]
        public IFormFile Image { get; set; }
    }
}
