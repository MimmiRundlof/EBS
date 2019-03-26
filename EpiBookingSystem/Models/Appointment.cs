using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiBookingSystem.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public DateTime Date { get; set; }

        public Treatment Treatment { get; set; }

        public IdentityUser Customer { get; set; }

    }
}