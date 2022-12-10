namespace MCS.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MCS.Common;
    using MCS.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    internal class UserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            if (dbContext.Users.Any())
            {
                return;
            }

            // Creates admin user
            await CreateApplicationUserAsync(userManager, roleManager, GlobalConstants.AdminEmail, GlobalConstants.AdministratorRoleName);

            // Creates regular user
            await CreateApplicationUserAsync(userManager, roleManager, GlobalConstants.UserEmail);

            // Creates doctor user
            await CreateDoctorUserAsync(dbContext, userManager, roleManager, 1, "doctor@doctor.com", "Todor", "Mavrodiev", GlobalConstants.FirstDoctorImage);

            await CreateDoctorUserAsync(dbContext, userManager, roleManager, 1, "doctor1@doctor.com", "Petar", "Angelov", GlobalConstants.SecondDoctorImage);

            await CreateDoctorUserAsync(dbContext, userManager, roleManager, 2, "doctor2@doctor.com", "Petya", "Kuzmanova", GlobalConstants.ThirdDoctorImage);

            await CreateDoctorUserAsync(dbContext, userManager, roleManager, 2, "doctor3@doctor.com", "Gergana", "Petrova", GlobalConstants.FourthDoctorImage);

            await CreateDoctorUserAsync(dbContext, userManager, roleManager, 3, "doctor4@doctor.com", "Mincho", "Asparuhov", GlobalConstants.FirstDoctorImage);

            await CreateDoctorUserAsync(dbContext, userManager, roleManager, 3, "doctor5@doctor.com", "Ginka", "Pehlivanova", GlobalConstants.FourthDoctorImage);

            await CreateDoctorUserAsync(dbContext, userManager, roleManager, 4, "doctor6@doctor.com", "Vasil", "Petkanov", GlobalConstants.SecondDoctorImage);

            await CreateDoctorUserAsync(dbContext, userManager, roleManager, 4, "doctor7@doctor.com", "Galya", "Vladova", GlobalConstants.ThirdDoctorImage);

            await CreateDoctorUserAsync(dbContext, userManager, roleManager, 5, "doctor8@doctor.com", "Lilyana", "Mihaylova", GlobalConstants.FourthDoctorImage);

            await CreateDoctorUserAsync(dbContext, userManager, roleManager, 5, "doctor9@doctor.com", "Angel", "Ivanov", GlobalConstants.FirstDoctorImage);
        }

        private static async Task CreateApplicationUserAsync(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            string email,
            string roleName = null)
        {
            var user = new ApplicationUser
            {
                Email = email,
                UserName = email,
                FirstName = "TestName",
                LastName = "TestLastName",
            };

            var password = GlobalConstants.UsersPassword;

            if (roleName != null)
            {
                var role = await roleManager.FindByNameAsync(roleName);

                if (role != null)
                {
                    var result = await userManager.CreateAsync(user, password);

                    if (!result.Succeeded)
                    {
                        throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                    }

                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
            else
            {
                var result = await userManager.CreateAsync(user, password);

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }

        private static async Task CreateDoctorUserAsync(
            ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            int departmentId,
            string email,
            string firstName,
            string lastName,
            string imgUrl)
        {
            int id = departmentId;

            var department = await dbContext.Departments.FirstOrDefaultAsync(x => x.Id == id);

            var user = new ApplicationUser
            {
                Email = email,
                UserName = email,
                FirstName = firstName,
                LastName = lastName,
                ImageUrl = imgUrl,
                DepartmentId = departmentId,
                Department = department,
            };

            var password = GlobalConstants.UsersPassword;
            var roleName = GlobalConstants.DoctorRoleName;

            var role = await roleManager.FindByNameAsync(roleName);

            if (role != null)
            {
                var result = await userManager.CreateAsync(user, password);

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }

                await userManager.AddToRoleAsync(user, roleName);
            }
        }
    }
}
