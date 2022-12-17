namespace MCS.Services.Data.Tests.UseInMemoryDatabase
{
    using System.Linq;
    using System.Threading.Tasks;

    using MCS.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class DepartmentsServiceTests : BaseServiceTests
    {
        private IDepartmentService DepartmentService => this.ServiceProvider.GetRequiredService<IDepartmentService>();

        [Fact]
        public async Task AddAsyncShouldAddProperly()
        {
            await this.CreateDepartmentAsync();

            var name = "Another Department";
            var description = "This is another test description for test";
            var imageUrl =
                "https://res.cloudinary.com/healthy-med/image/upload/v1670418109/departments/dermatology_xgff1c.jpg";

            await this.DepartmentService.AddAsync(name, description, imageUrl);
            var count = await this.DbContext.Departments.CountAsync();
            Assert.Equal(2, count);
        }

        [Fact]
        public async Task DeleteAsyncShouldDelete()
        {
            var department = await this.CreateDepartmentAsync();

            await this.DepartmentService.DeleteAsync(department.Id);

            var count = await this.DbContext.Departments.Where(x => !x.IsDeleted).CountAsync();

            Assert.Equal(0, count);

            var deletedDepartment = await this.DbContext.Departments.FirstOrDefaultAsync(x => x.Id == department.Id);

            Assert.Null(deletedDepartment);
        }

        [Fact]
        public async Task GetByIdShouldReturnDepartment()
        {
            var department = await this.CreateDepartmentAsync();

            var result = await this.DepartmentService.GetByIdAsync(department.Id);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAllShouldReturnListOfDepartments()
        {
            var department = await this.CreateDepartmentAsync();

            var name = "Another Department";
            var description = "This is another test description for test";
            var imageUrl =
                "https://res.cloudinary.com/healthy-med/image/upload/v1670418109/departments/dermatology_xgff1c.jpg";

            await this.DepartmentService.AddAsync(name, description, imageUrl);

            var departments = await this.DepartmentService.GetAllAsync();
            var count = departments.Departments.Count();

            Assert.Equal(2, count);
        }

        private async Task<Department> CreateDepartmentAsync()
        {
            var department = new Department
            {
                Name = "Some Department",
                Description = "This is some test text for testing purposes",
                ImageUrl =
                    "https://res.cloudinary.com/healthy-med/image/upload/v1670418109/departments/dermatology_xgff1c.jpg",
            };

            await this.DbContext.Departments.AddAsync(department);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Department>(department).State = EntityState.Detached;

            return department;
        }
    }
}
