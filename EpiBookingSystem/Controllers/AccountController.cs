using EpiBookingSystem.Models.ViewModels;
using EpiBookingSystem.Repositories;
using EPiServer.Data;
using EPiServer.Framework.Localization;
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
                return RedirectToAction("LogIn", "Account");
            }
            AuthenticationManager.SignOut();
            return RedirectToAction("LogIn", "Account");


        }

        public ActionResult LogIn()
        {
            if (User.IsInRole(LocalizationService.Current.GetString("/userrole")) || User.IsInRole(LocalizationService.Current.GetString("/adminrole")))
            {
                return RedirectToAction("Index", "StandardPage");
            }

            return View("LogIn");


        }

        [HttpPost]
        public async Task<ActionResult> LogIn(LoginViewModel model)
        {


            if (ModelState.IsValid)
            {

                var result = await _userRepository.LogIn(model, AuthenticationManager);
                if (result.ToString() == LocalizationService.Current.GetString("/successvalidationmessage"))
                {
                    return RedirectToAction("Index", "StandardPage");

                }

            }
            ModelState.AddModelError("LogInError", LocalizationService.Current.GetString("/loginerrormessage"));
            return View("LogIn", model);

        }
        public ActionResult Register()
        {
            if (User.IsInRole(LocalizationService.Current.GetString("/userrole")) || User.IsInRole(LocalizationService.Current.GetString("/adminrole")))
            {
                return RedirectToAction("Index", "StandardPage");
            }

            return View("Register");

        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                await _userRepository.CreateUser(model, AuthenticationManager);

                return RedirectToAction("Index", "StandardPage");

            }
            else
            {
                return View("Register", model);
            }
        }
    }
}