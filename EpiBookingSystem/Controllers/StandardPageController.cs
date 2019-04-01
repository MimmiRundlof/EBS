using System.Linq;
using System.Web;
using System.Web.Mvc;
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
                return RedirectToAction("Index", "Account");
            }
            var userId = User.Identity.GetUserId();


            var model = new StandardPageViewModel()            
            {
                Appointments = _repository.GetAppointments(userId),
                Treatments = _repository.GetTreatments(),
                Test = CurrentPage.Test
            };




            return View(model);
        }
    }
}