using EpiBookingSystem.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiBookingSystem.Repositories
{
    public interface IBookingRepository
    {
        IdentityDbContext<IdentityUser> GetContext();
        ApplicationDbContext GetDbContext();
        void GetAllUsers();
        void GetAllAppointments();
        void GetAppointments(int id);

    }
}
