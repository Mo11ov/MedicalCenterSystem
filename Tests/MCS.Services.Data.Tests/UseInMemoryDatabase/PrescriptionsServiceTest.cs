namespace MCS.Services.Data.Tests.UseInMemoryDatabase
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MCS.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class PrescriptionsServiceTest : BaseServiceTests
    {
        private IPrescriptionService PrescriptionService =>
            this.ServiceProvider.GetRequiredService<IPrescriptionService>();

        [Fact]
        public async Task CreateShouldAddPrescriptionToDb()
        {
            var prescription = this.CreatePrescriptionAsync();

            var patientId = Guid.NewGuid().ToString();
            var doctorName = "Pesho";
            var treatment = "Some weird herbs to heal yourself";
            var date = DateTime.Now;

            await this.PrescriptionService.AddAsync(patientId, doctorName, treatment, date);
            var count = await this.DbContext.Prescriptions.CountAsync();

            Assert.Equal(2, count);
        }

        //[Fact]
        //public async Task DeleteShouldRemovePrescriptionFromDb()
        //{
        //    var prescription = this.CreatePrescriptionAsync();

        //    await this.PrescriptionService.DeleteAsync(prescription.Id);

        //    var count = this.DbContext.Prescriptions.Where(x => !x.IsDeleted).ToArray().Count();

        //    Assert.Equal(0, count);
        //}




        private async Task<Prescription> CreatePrescriptionAsync()
        {
            var prescription = new Prescription
            {
                PatientId = Guid.NewGuid().ToString(),
                DoctorId = Guid.NewGuid().ToString(),
                Treatment = "Some text for testing purposes",
                IssuedDate = DateTime.Now,
            };

            await this.DbContext.Prescriptions.AddAsync(prescription);
            await this.DbContext.SaveChangesAsync();

            this.DbContext.Entry<Prescription>(prescription).State = EntityState.Detached;

            return prescription;
        }
    }
}
