using EpiBookingSystem.Models;
using EpiBookingSystem.Models.ViewModels;
using EpiBookingSystem.Repositories;
using EPiServer.Framework.Localization;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpiBookingSystem.Controllers
{
    public class BookingController : Controller
    {

        private IAuthenticationManager AuthenticationManager { get { return HttpContext.GetOwinContext().Authentication; } }

        private IBookingRepository _repository;
        
        public BookingController(IBookingRepository repository)
        {
            _repository = repository;

        }
        public ActionResult DeleteTreatment(string treatmentId)
        {
            if (!User.IsInRole(LocalizationService.Current.GetString("/adminrole")))
            {
                return RedirectToAction("LogIn", "Account");
            }
            _repository.DeleteTreatment(treatmentId);

            return RedirectToAction("Index", "StandardPage");
        }

        public ActionResult AddTreatment(StandardPageViewModel model)
        {
            if (!User.IsInRole(LocalizationService.Current.GetString("/adminrole")))
            {
                return RedirectToAction("LogIn", "Account");
            }
            _repository.AddTreatment(model.Treatment, model.Description);

            return RedirectToAction("Index", "StandardPage");
        }

        public ActionResult CancelAppointment(int appointmentId)
        {
            
            _repository.CancelAppointment(appointmentId);

            return RedirectToAction("Index", "StandardPage");
        }
       

    }
}