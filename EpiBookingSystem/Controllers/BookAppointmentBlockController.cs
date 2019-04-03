using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using EpiBookingSystem.Models.Blocks;
using EpiBookingSystem.Models.Identity;
using EpiBookingSystem.Models.ViewModels;
using EpiBookingSystem.Repositories;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc;

namespace EpiBookingSystem.Controllers
{
    public class BookAppointmentBlockController : BlockController<BookAppointmentBlock>
    {
        private IBookingRepository _repository;

        private ApplicationDbContext _context;


        public BookAppointmentBlockController(IBookingRepository repository, ApplicationDbContext context)
        {
            _context = context;
            _repository = repository;

        }


        public override ActionResult Index(BookAppointmentBlock currentBlock)
        {

       

            var model = CreateViewModel();

            return PartialView(model);
        }


        public BookAppointmentBlockViewModel CreateViewModel()
        {

            var list = _repository.GetAllAppointments().Select(x => x.Date).ToList();

            List<Array> array = new List<Array>();

            foreach (var item in list)
            {
                var first = item.AddHours(-1);
                var second = item.AddHours(1);

                String[] arr = new String[] { first.ToString("yyyy-MM-dd HH:mm"), second.ToString("yyyy-MM-dd HH:mm") };

                array.Add(arr);
            }

            var model = new BookAppointmentBlockViewModel()
            {
                Treatments = _repository.GetTreatments(),
                BookedDates = array

            };
            return model;
        }
    }
}