﻿namespace MCS.Web.Areas.Doctor.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using MCS.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    public class AppointmentController : DoctorController
    {
        private readonly IAppointmentService appointmentService;
        private readonly INotificationService notificationServiceService;

        public AppointmentController(
            IAppointmentService appointmentService,
            INotificationService notificationServiceService)
        {
            this.appointmentService = appointmentService;
            this.notificationServiceService = notificationServiceService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var allAppointments = await this.appointmentService.GetByDoctorAsync(userId);

            return this.View(allAppointments);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await this.appointmentService.GetByIdAsync(id);

            if (appointment.IsConfirmed == true)
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            await this.appointmentService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmAppointment(int id)
        {
            var appointment = this.appointmentService.GetByIdAsync(id);

            var patientId = appointment.Result.PatientId;
            var doctorName = appointment.Result.Doctor.FirstName + " " + appointment.Result.Doctor.LastName;

            await this.notificationServiceService
                .CreateAsync(patientId, $"Your appointment with {doctorName} has been confirmed");
            await this.appointmentService.ConfirmAsync(id);

            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpPost]
        public async Task<IActionResult> CancelAppointment(int id)
        {
            var appointment = this.appointmentService.GetByIdAsync(id);

            var patientId = appointment.Result.PatientId;
            var doctorName = appointment.Result.Doctor.FirstName + " " + appointment.Result.Doctor.LastName;
            await this.notificationServiceService
                .CreateAsync(patientId, $"Your appointment with {doctorName} has been canceled");

            await this.appointmentService.CancelAsync(id);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
