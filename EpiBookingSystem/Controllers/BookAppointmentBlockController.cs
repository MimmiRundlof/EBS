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
using EPiServer.Framework.Localization;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using Microsoft.AspNet.Identity;

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

        [HttpPost]
        public ActionResult BookAppointment(BookAppointmentBlockViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isNotAvailable = _repository.GetAllAppointments().Any(x => x.Date.ToString().Equals(model.Date.ToString()));
                if (isNotAvailable)
                {
                    ModelState.AddModelError("DateTimeNotAvailable", LocalizationService.Current.GetString("/bookingerrormessage"));


                    model.Treatments = _repository.GetTreatments();

                    return RedirectToAction("Index", "StandardPage");
                }
                else
                {

                    var userId = User.Identity.GetUserId();
                    _repository.BookAppointment(model.TreatmentId, userId, model.Date);

                    return RedirectToAction("Index", "StandardPage");

                }

            }
            else
            {
                
                return RedirectToAction("Index", "StandardPage", model);
            }
        }
    }
}