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

namespace EpiBookingSystem.Controllers
{
    public class TreatmentsListBlockController : BlockController<TreatmentsListBlock>
    {
        private IBookingRepository _repository;

        private ApplicationDbContext _context;


        public TreatmentsListBlockController(IBookingRepository repository, ApplicationDbContext context)
        {
            _context = context;
            _repository = repository;

        }


        public override ActionResult Index(TreatmentsListBlock currentBlock)
        {

            var model = new TreatmentsListBlockViewModel()
            {
                Treatments = _repository.GetTreatments()

            };

            return PartialView(model);
        }
    }
}
