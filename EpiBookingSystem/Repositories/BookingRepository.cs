using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiBookingSystem.Repositories
{
    public class BookingRepository
    {
        public IdentityDbContext<IdentityUser> GetUsersRepository()
        {
            var dbContext = new IdentityDbContext<IdentityUser>("DefaultConnection");

            return dbContext;
        }

    }
}