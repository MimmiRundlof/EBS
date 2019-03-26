using EpiBookingSystem.Models.Identity;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.ServiceLocation;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiBookingSystem.Repositories
{
    [ServiceConfiguration(ServiceType = typeof(IBookingRepository), Lifecycle = ServiceInstanceScope.HttpContext)]
    public class BookingRepository : IBookingRepository
    {
        private ApplicationDbContext _context;  
               
        public BookingRepository(ApplicationDbContext context)
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

        public ApplicationDbContext GetDbContext()
        {
            return new ApplicationDbContext();

        }
    }
}