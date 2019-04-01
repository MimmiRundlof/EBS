using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using EpiBookingSystem.Models.Identity;
using EpiBookingSystem.Models.ViewModels;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace EpiBookingSystem.Repositories
{
    public class UserRepository : IUserRepository
    {

        private UserStore<IdentityUser> _userStore;

        private UserManager<IdentityUser, string> _userManager;

        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
            _userStore = new UserStore<IdentityUser>(_context);
            _userManager = new UserManager<IdentityUser, string>(_userStore);


        }
        public async Task CreateUser(AuthenticateViewModel model, IAuthenticationManager authenticationManager)
        {
            var user = new IdentityUser { Id = Guid.NewGuid().ToString(), UserName = model.Username, Email = model.Email };

            _userManager.Create(user, model.Password);

            await _userManager.AddToRoleAsync(user.Id, "User");

            var signInManager = new SignInManager<IdentityUser, string>
                 (_userManager, authenticationManager);


            await signInManager.PasswordSignInAsync(model.Username, model.Password, true, true);

           
        }

        public async Task<SignInStatus> LogIn(AuthenticateViewModel model, IAuthenticationManager authenticationManager)
        {
            
            var signInManager = new SignInManager<IdentityUser, string>
                   (_userManager, authenticationManager);

            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, true, true);

            return result;

        }

    }
}