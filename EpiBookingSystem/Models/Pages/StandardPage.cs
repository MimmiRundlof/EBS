using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EpiBookingSystem.Models.Pages
{
    [ContentType(DisplayName = "StandardPage", GUID = "8f9d2039-8af1-486d-ac68-12b5fe594f68", Description = "")]
    public class StandardPage : PageData
    {

        [CultureSpecific]
        [Display(
            Name = "Content",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual ContentArea MainContentArea { get; set; }



    }
}