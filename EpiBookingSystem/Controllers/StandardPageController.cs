using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EpiBookingSystem.Models.Identity;
using EpiBookingSystem.Models.Pages;
using EpiBookingSystem.Models.ViewModels;
using EpiBookingSystem.Repositories;
using EPiServer;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace EpiBookingSystem.Controllers
{
    public class StandardPageController : PageController<StandardPage>
    {
        private readonly IBookingRepository _repository;

        private readonly ApplicationDbContext<IdentityUser> _context;

        public StandardPageController(IBookingRepository repository, ApplicationDbContext<IdentityUser> context)
        {
            _repository = repository;
            _context = context;
        }


        public ActionResult Index(StandardPage currentPage)
        {
          
            var model = new StandardPageViewModel()
            {

            };

            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Index(StandardPageViewModel model)
        {
            if (ModelState.IsValid)
            {

                //var dbContext = new IdentityDbContext<IdentityUser>("DefaultConnection");
                                
                var userStore = new UserStore<IdentityUser>(_context);
                var userManager = new UserManager<IdentityUser, string>(userStore);
                var user = new IdentityUser { Id = Guid.NewGuid().ToString(), UserName = model.Username, Email = model.Email};

                userManager.Create(user, model.Password);


                var signInManager = new SignInManager<IdentityUser, string>
                     (userManager, System.Web.HttpContext.Current.GetOwinContext().Authentication);


              await signInManager.PasswordSignInAsync(model.Username, model.Password, true, true);


                

            }
            
       

            return RedirectToAction("Index", "StandardPage");



        }
    }
}