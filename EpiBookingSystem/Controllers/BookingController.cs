using EpiBookingSystem.Models;
using EpiBookingSystem.Models.ViewModels;
using EpiBookingSystem.Repositories;
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

        public ActionResult CancelAppointment(int appointmentId)
        {
            
            _repository.CancelAppointment(appointmentId);

            return RedirectToAction("Index", "StandardPage");
        }
        [HttpPost]
        public ActionResult BookAppointment(BookAppointmentBlockViewModel model)
        {
            if(ModelState.IsValid)
            {
                var isNotAvailable = _repository.GetAllAppointments().Any(x => x.Date.ToString().Equals(model.Date.ToString()));
                if(isNotAvailable)
                {
                    ModelState.AddModelError("DateTimeNotAvailable", "Tiden är bokad, välj en annan.");


                    model.Treatments = _repository.GetTreatments();
                                       
                    return RedirectToAction("Index","StandardPage");
                }
                else
                {

                    var userId = User.Identity.GetUserId();
                    _repository.BookAppointment(model.TreatmentId, userId, model.Date);

                    return RedirectToAction("Index", "StandardPage");

                }

            }
            else
            {
                
                return RedirectToAction("Index", "StandardPage", model);
            }
        }

    }
}