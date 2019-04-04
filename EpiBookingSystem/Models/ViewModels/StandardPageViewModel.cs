using EpiBookingSystem.Models.Pages;
using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpiBookingSystem.Models.ViewModels
{
    public class StandardPageViewModel
    {
        public StandardPage CurrentPage { get; set; }

        public List<Appointment> Appointments { get; set; }

        [Display(Name ="Namn på behandling")]
        public string Treatment { get; set; }

        [Display(Name = "Beskrivning")]
        public string Description { get; set; }


    }
}