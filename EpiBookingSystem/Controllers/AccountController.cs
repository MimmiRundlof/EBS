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

        private IUserRepository _userRepository;

        private IAuthenticationManager AuthenticationManager { get { return HttpContext.GetOwinContext().Authentication; } }


        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        public ActionResult LogOut()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Authenticate", "Account");
            }
            AuthenticationManager.SignOut();
            return RedirectToAction("Authenticate", "Account");


        }

        public ActionResult Index()
        {
            if (User.IsInRole("User"))
            {
                return RedirectToAction("Index", "StandardPage");
            }
            return View("Index");

        }

        [HttpPost]
        public async Task<ActionResult> LogIn(AuthenticateViewModel model)
        {

            await _userRepository.LogIn(model, AuthenticationManager);
            if (AuthenticationManager.User.Identity.IsAuthenticated)
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

                await _userRepository.CreateUser(model, AuthenticationManager);

                return RedirectToAction("Index", "StandardPage");

            }
            else
            {
                return View("Authenticate", model);
            }
        }
    }
}