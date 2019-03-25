using EpiBookingSystem.Models.ViewModels;
using EpiBookingSystem.Repositories;
using EPiServer.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EpiBookingSystem.Controllers
{
    public class AccountController : Controller
    {

        private IdentityDbContext<IdentityUser> _context;

        private IAuthenticationManager AuthenticationManager { get { return HttpContext.GetOwinContext().Authentication; } }



        public AccountController(IBookingRepository repository)
        {
            _context = repository.GetContext();


        }
        
        public ActionResult LogOut()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            AuthenticationManager.SignOut();
            return RedirectToAction("LogIn", "Account");


        }

        public ActionResult LogIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "StandardPage");
            }
            return View();

        }

        [HttpPost]
        public async Task<ActionResult> LogIn(StandardPageViewModel model)
        {
          
            var userStore = new UserStore<IdentityUser>(_context);
            var userManager = new UserManager<IdentityUser, string>(userStore);

            var signInManager = new SignInManager<IdentityUser, string>
                   (userManager, AuthenticationManager);

            await signInManager.PasswordSignInAsync(model.Username, model.Password, true, true);


            return RedirectToAction("Index", "StandardPage");
            
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Index(StandardPageViewModel model)
        {
            if (ModelState.IsValid)
            {

                var userStore = new UserStore<IdentityUser>(_context);
                var userManager = new UserManager<IdentityUser, string>(userStore);
                var user = new IdentityUser { Id = Guid.NewGuid().ToString(), UserName = model.Username, Email = model.Email };

                userManager.Create(user, model.Password);


                var signInManager = new SignInManager<IdentityUser, string>
                     (userManager, AuthenticationManager);


                await signInManager.PasswordSignInAsync(model.Username, model.Password, true, true);

                return RedirectToAction("Index", "StandardPage");

            }
            else
            {
                return View(model);
            }
        }
    }
}