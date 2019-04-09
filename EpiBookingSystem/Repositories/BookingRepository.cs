using EpiBookingSystem.Models;
using EpiBookingSystem.Models.Identity;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.ServiceLocation;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpiBookingSystem.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;

        }


        public void DeleteTreatment(string treatmentId)
        {

            var treatment = _context.Treatment.SingleOrDefault(x => x.TreatmentId.ToString() == treatmentId);
            _context.Appointment.RemoveRange(_context.Appointment.Where(x => x.Treatment.TreatmentId.ToString() == treatmentId));
            _context.Treatment.Remove(treatment);
            _context.SaveChanges();
        }

        public void AddTreatment(string name, string description)
        {
            var treatment = new Treatment()
            {
                Name = name,
                Description = description
            };

            _context.Treatment.Add(treatment);
            _context.SaveChanges();
        }

        public void BookAppointment(int treatmentId, string userId, DateTime date)
        {

            var appointment = new Appointment
            {
                Treatment = _context.Treatment.SingleOrDefault(x => x.TreatmentId == treatmentId),
                Customer = _context.Users.SingleOrDefault(x=> x.Id == userId),
                Date = date
            };
            _context.Appointment.Add(appointment);
            _context.SaveChanges();
        }

        public void CancelAppointment(int appointmentId)
        {
            var appointment = _context.Appointment.SingleOrDefault(x => x.AppointmentId == appointmentId);
            _context.Appointment.Remove(appointment);
            _context.SaveChanges();
        }

        public List<Appointment> GetAllAppointments()
        {
            var appointments = _context.Appointment.Include(t=>t.Treatment).Include(c=> c.Customer).ToList();

            return appointments;
        }


        public List<Appointment> GetAppointments(string userId)
        {
            var appointments = _context.Appointment.Include(t=> t.Treatment).Where(x => x.Customer.Id == userId).ToList();

            return appointments;

        }

        public IEnumerable<SelectListItem> GetTreatments()
        {
            var treatments = _context.Treatment.Select(x => new SelectListItem()
            {
                Value = x.TreatmentId.ToString(),
                Text = x.Name
            });

            return treatments;

        }
    }
}