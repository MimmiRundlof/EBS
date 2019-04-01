using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpiBookingSystem.Models.ViewModels
{
    public class TreatmentsListBlockViewModel
    {
        public IEnumerable<SelectListItem> Treatments { get; set; }
        [Required]
        public int TreatmentId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm:ss}")]
        [Display(Name = "Registed Date")]
        public DateTime Date { get; set; }

    }
}