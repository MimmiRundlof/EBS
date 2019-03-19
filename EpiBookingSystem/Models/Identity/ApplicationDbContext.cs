using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;



namespace EpiBookingSystem.Models.Identity
{

        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext()
                : base("DefaultConnection")
            {
            }



            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
        }
    }


