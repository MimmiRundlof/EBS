using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EpiBookingSystem.Models.Blocks
{
    [ContentType(DisplayName = "ListAppointmentsBlock", GUID = "13db4d13-41d3-40bf-92f7-ca9e5b4648df", Description = "")]
    public class ListAppointmentsBlock : BlockData
    {
        /*
                [CultureSpecific]
                [Display(
                    Name = "Name",
                    Description = "Name field's description",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual string Name { get; set; }
         */
    }
}