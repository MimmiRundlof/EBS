using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiBookingSystem.Repositories
{
    public interface IBookingRepository
    {
        void GetAllUsers();
        void GetAllAppointments();
        void GetAppointments(int id);

    }
}
