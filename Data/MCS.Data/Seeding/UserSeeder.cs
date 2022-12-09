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

            // creates admin user
            await CreateApplicationUserAsync(userManager, roleManager, GlobalConstants.AdminEmail, GlobalConstants.AdministratorRoleName);

            // creates doctor user
            await CreateDoctorUserAsync(dbContext, userManager, roleManager, GlobalConstants.DoctorEmail, GlobalConstants.DoctorRoleName);

            // creates regular user
            await CreateApplicationUserAsync(userManager, roleManager, GlobalConstants.UserEmail);
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
            string email,
            string roleName = null)
        {
            var random = new Random();

            var department = await dbContext.Departments.FirstOrDefaultAsync(x => x.Id == random.Next(5));

            var user = new ApplicationUser
            {
                Email = email,
                UserName = email,
                FirstName = "TestName",
                LastName = "TestLastName",
                Department = department,
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
    }
}
