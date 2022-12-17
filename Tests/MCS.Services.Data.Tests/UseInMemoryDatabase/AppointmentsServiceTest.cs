using System.Linq;

namespace MCS.Services.Data.Tests.UseInMemoryDatabase
{
    using System;
    using System.Threading.Tasks;

    using MCS.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class AppointmentsServiceTest : BaseServiceTests
    {
        private IAppointmentService AppointmentService => this.ServiceProvider.GetRequiredService<IAppointmentService>();

        [Fact]
        public async Task CreateShouldCreateProperly()
        {
            await this.CreateAppointmentAsync();

            var appointmentsCount = await this.DbContext.Appointments.CountAsync();

            Assert.Equal(1, appointmentsCount);

            var patientId = Guid.NewGuid().ToString();
            var doctorId = Guid.NewGuid().ToString();
            var dateTime = DateTime.Now;

            await this.AppointmentService.AddAsync(patientId, doctorId, dateTime);
            var count = await this.DbContext.Appointments.CountAsync();

            Assert.Equal(2, count);
        }

        [Fact]
        public async Task GetByIdShouldReturnAppointment()
        {
            var appointment = await this.CreateAppointmentAsync();

            var result = await this.AppointmentService.GetByIdAsync(appointment.Id);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeleteShouldDeleteAppointment()
        {
            var appointment = await this.CreateAppointmentAsync();

            await this.AppointmentService.DeleteAsync(appointment.Id);

            var count = await this.DbContext.Appointments.Where(x => !x.IsDeleted).CountAsync();

            Assert.Equal(0, count);

            var deletedAppointment = await this.AppointmentService.GetByIdAsync(appointment.Id);

            Assert.Null(deletedAppointment);
        }

        [Fact]
        public async Task ConfirmAsyncShouldChangeStatusToConfirm()
        {
            var appointment = await this.CreateAppointmentAsync();

            await this.AppointmentService.ConfirmAsync(appointment.Id);
            var result = await this.DbContext.Appointments.Where(x => x.Id == appointment.Id).Select(x => x.IsConfirmed).FirstOrDefaultAsync();
            Assert.True(result);
        }

        [Fact]
        public async Task CancelAsyncShouldChangeAppointmentStatusToFalse()
        {
            var appointment = await this.CreateAppointmentAsync();
            appointment.IsConfirmed = true;

            await this.AppointmentService.CancelAsync(appointment.Id);
            var result = await this.DbContext.Appointments.Where(x => x.Id == appointment.Id).Select(x => x.IsConfirmed).FirstOrDefaultAsync();
            Assert.False(result);
        }


        private async Task<Appointment> CreateAppointmentAsync()
        {
            var appointment = new Appointment
            {
                PatientId = Guid.NewGuid().ToString(),
                DoctorId = Guid.NewGuid().ToString(),
                DateTime = DateTime.Now,
            };

            await this.DbContext.Appointments.AddAsync(appointment);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Appointment>(appointment).State = EntityState.Detached;

            return appointment;
        }
    }
}
