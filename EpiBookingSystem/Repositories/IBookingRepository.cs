using EpiBookingSystem.Models;
using EpiBookingSystem.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EpiBookingSystem.Repositories
{
    public interface IBookingRepository
    {
        void BookAppointment(int treatmentId, string userId, DateTime date);
        void CancelAppointment(int appointmentId);
        List<Appointment> GetAllAppointments();
        List<Appointment> GetAppointments(string userId);
        IEnumerable<SelectListItem> GetTreatments();

    }
}
