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


        public ContentArea MainContentArea { get; set; }

    }
}