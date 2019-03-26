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

        private readonly UserManager<IdentityUser> _userManager;

        private readonly UserStore<IdentityUser> uss;


        private IAuthenticationManager AuthenticationManager { get { return HttpContext.GetOwinContext().Authentication; } }
        
        public AccountController(IBookingRepository repository, IdentityDbContext<IdentityUser> u)
        {
            _context = repository.GetContext();
            

        }

        public ActionResult LogOut()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Authenticate", "StandardPage");
            }
            AuthenticationManager.SignOut();
            return RedirectToAction("Authenticate", "Account");


        }

        public ActionResult Authenticate()
        {
            if (User.IsInRole("User"))
            {
                return RedirectToAction("Index", "StandardPage");
            }
            return View("Authenticate");

        }

        [HttpPost]
        public async Task<ActionResult> LogIn(AuthenticateViewModel model)
        {

            var userStore = new UserStore<IdentityUser>(_context);
            var userManager = new UserManager<IdentityUser, string>(userStore);

            var signInManager = new SignInManager<IdentityUser, string>
                   (userManager, AuthenticationManager);

            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, true, true);

            if (result == SignInStatus.Success)
            {
                return RedirectToAction("Index", "StandardPage");

            }
            else
            {
                return View("Authenticate", model);
            }

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(AuthenticateViewModel model)
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
                return View("Authenticate", model);
            }
        }
    }
}