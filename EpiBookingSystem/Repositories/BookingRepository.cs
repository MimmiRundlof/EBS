using EpiBookingSystem.Models.Identity;
using EPiServer.Cms.UI.AspNetIdentity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiBookingSystem.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext<IdentityUser> _context;

        public BookingRepository(ApplicationDbContext<IdentityUser> context)
        {
            _context = context;
        }

        public void GetAllAppointments()
        {
            throw new NotImplementedException();
        }

        public void GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public void GetAppointments()
        {
            throw new NotImplementedException();
        }

        public void GetAppointments(int id)
        {
            throw new NotImplementedException();
        }

        public IdentityDbContext<IdentityUser> GetContext()
        {
            return new IdentityDbContext<IdentityUser>("DefaultConnection");

        }
    }
}