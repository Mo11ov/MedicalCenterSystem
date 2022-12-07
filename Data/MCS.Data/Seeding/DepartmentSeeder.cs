namespace MCS.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MCS.Common;
    using MCS.Data.Models;

    internal class DepartmentSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Departments.Any())
            {
                return;
            }

            await dbContext.Departments.AddAsync(new Department { Name = "Dermatology", ImageUrl = GlobalConstants.DermatolgyDepartmentImage, Description = "Dermatologists are physicians who treat adult and pediatric patients with disorders of the skin, hair, nails, and adjacent mucous membranes. They diagnose everything from skin cancer, tumors, inflammatory diseases of the skin, and infectious diseases. They also perform skin biopsies and dermatological surgical procedures." });

            await dbContext.Departments.AddAsync(new Department { Name = "Allergy and Immunology", ImageUrl = GlobalConstants.AllergyDepartmentImage, Description = "Specialists in allergy and immunology work with both adult and pediatric patients suffering from allergies and diseases of the respiratory tract or immune system. They may help patients suffering from common diseases such as asthma, food and drug allergies, immune deficiencies, and diseases of the lung. Specialists in allergy and immunology can pursue opportunities in research, education, or clinical practice." });

            await dbContext.Departments.AddAsync(new Department { Name = "Family medicine", ImageUrl = GlobalConstants.FamilyDepartmentImage, Description = "While many medical specialties focus on a certain function of the body or particular organ, family medicine focuses on integrated care and treating the patient as a whole. Physicians who specialize in family medicine treat patients of all ages. They are extensively trained to provide comprehensive health care and treat most ailments." });

            await dbContext.Departments.AddAsync(new Department { Name = "Pediatrics", ImageUrl = GlobalConstants.PediatricsDepartmentImage, Description = "Physicians specializing in pediatrics work to diagnose and treat patients from infancy through adolescence. Pediatricians practice preventative medicine and also diagnose common childhood diseases, such as asthma, allergies, and croup." });

            await dbContext.Departments.AddAsync(new Department { Name = "Urology", ImageUrl = GlobalConstants.UrologyDepartmentImage, Description = "Urology is the health care segment that cares for the male and female urinary tract, including kidneys, ureters, bladder, and urethra. It also deals with the male sex organs. Urologists have knowledge of surgery, internal medicine, pediatrics, gynecology, and more." });

            await dbContext.SaveChangesAsync();
        }
    }
}
