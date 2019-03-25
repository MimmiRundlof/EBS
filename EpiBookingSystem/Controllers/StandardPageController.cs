using System;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EpiBookingSystem.Models.Pages;
using EpiBookingSystem.Models.ViewModels;
using EpiBookingSystem.Repositories;
using EPiServer.Core;
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

        private SignInManager<IdentityUser, string> test;

        private IdentityDbContext<IdentityUser> _context;

        private IAuthenticationManager AuthenticationManager { get { return HttpContext.GetOwinContext().Authentication; } }



        public StandardPageController(IBookingRepository repository)
        {
            _context = repository.GetContext();
            _repository = repository;

        }

        [Authorize]
        public ActionResult Index(StandardPage currentPage)
        {

            var model = new StandardPageViewModel()
            {

            };

            return View(model);
        }
    }
}