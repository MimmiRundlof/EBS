using EpiBookingSystem.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpiBookingSystem.Controllers
{
    public class BookingController : Controller
    {

        public ActionResult CancelAppointment(int appointmentId)
        {

            return RedirectToAction("Index", "StandardPage");
        }
        [HttpPost]
        public ActionResult BookAppointment(StandardPageViewModel model)
        {

            return RedirectToAction("Index", "StandardPage");
        }

    }
}