using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;



namespace EpiBookingSystem.Models.Identity
{

        public class ApplicationDbContext : IdentityDbContext<IdentityUser>
        {
            public ApplicationDbContext()
                : base("DefaultConnection")
            {
            }

        public DbSet<Appointment> Appointment { get; set; }

        public DbSet<Treatment> Treatment { get; set; }
        

        public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
        }
    }


