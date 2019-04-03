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
        Task CreateUser(RegisterViewModel model, IAuthenticationManager authenticationManager);
        Task<SignInStatus> LogIn(LoginViewModel model, IAuthenticationManager authenticationManager);
    }
}
