﻿using System.Linq;
using System.Web;
using System.Web.Mvc;
using EpiBookingSystem.Models.Identity;
using EpiBookingSystem.Models.Pages;
using EpiBookingSystem.Models.ViewModels;
using EpiBookingSystem.Repositories;
using EPiServer.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace EpiBookingSystem.Controllers
{
    public class StandardPageController : PageController<StandardPage>
    {
        private IBookingRepository _repository;

        private ApplicationDbContext _context;

        private IAuthenticationManager AuthenticationManager { get { return HttpContext.GetOwinContext().Authentication; } }



        public StandardPageController(IBookingRepository repository, ApplicationDbContext context)
        {
            _context = context;
            _repository = repository;

        }

        public ActionResult Index(StandardPage currentPage)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Authenticate", "Account");
            }
            var userId = User.Identity.GetUserId();

            var test = _context.Appointment.Include("Treatment").Where(x => x.Customer.Id == userId).ToList();

            var model = new StandardPageViewModel()
            {
                Appointments = test,
                Treatments = _context.Treatment.Select(x=> new SelectListItem()
                {
                    Value = x.TreatmentId.ToString(),
                    Text = x.Name
                })
            };
        



            return View(model);
        }
    }
}