using EpiBookingSystem.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiBookingSystem.Repositories
{
    public interface IUserRepository
    {
        Task CreateUser(AuthenticateViewModel model, IAuthenticationManager authenticationManager);
        Task<SignInStatus> LogIn(AuthenticateViewModel model, IAuthenticationManager authenticationManager);
    }
}
