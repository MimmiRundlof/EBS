using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EpiBookingSystem.Models.Pages;
using EpiBookingSystem.Models.ViewModels;
using EpiBookingSystem.Repositories;
using EPiServer;
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
        private readonly BookingRepository _repository;

        public StandardPageController(BookingRepository repository)
        {
            _repository = repository;
        }


        public ActionResult Index(StandardPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

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
                var dbContext = _repository.GetUsersRepository();
                var userStore = new UserStore<IdentityUser>(dbContext);
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