using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EpiBookingSystem.Models.Blocks;
using EpiBookingSystem.Models.Identity;
using EpiBookingSystem.Models.ViewModels;
using EpiBookingSystem.Repositories;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace EpiBookingSystem.Controllers
{
    public class ListAppointmentsBlockController : BlockController<ListAppointmentsBlock>
    {
        private IBookingRepository _repository;

        private ApplicationDbContext _context;


        public ListAppointmentsBlockController(IBookingRepository repository, ApplicationDbContext context)
        {
            _context = context;
            _repository = repository;

        }


        public override ActionResult Index(ListAppointmentsBlock currentBlock)
        {
            var userId = User.Identity.GetUserId();

            var model = new ListAppointmentsBlockViewModel
            {
                Appointments = _repository.GetAppointments(userId)
            };
            return PartialView(model);
        }
    }
}
