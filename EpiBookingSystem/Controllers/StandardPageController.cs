using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using EpiBookingSystem.Models.Identity;
using EpiBookingSystem.Models.Pages;
using EpiBookingSystem.Models.ViewModels;
using EpiBookingSystem.Repositories;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace EpiBookingSystem.Controllers
{
    public class StandardPageController : PageController<StandardPage>
    {
        protected virtual StandardPage CurrentPage
        {
            get
            {
                return PageContext.Page as StandardPage;
            }
        }

        private IBookingRepository _repository;

        private IAuthenticationManager AuthenticationManager { get { return HttpContext.GetOwinContext().Authentication; } }



        public StandardPageController(IBookingRepository repository)
        {
            _repository = repository;

        }

        public ActionResult Index()
        {


            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");
            }
            var userId = User.Identity.GetUserId();


            var model = new StandardPageViewModel()            
            {
                CurrentPage = CurrentPage,
                Appointments = _repository.GetAllAppointments(),
                Treatments = _repository.GetTreatments()

            };




            return View(model);
        }
    }
}