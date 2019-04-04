using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpiBookingSystem.Models.ViewModels
{
    public class RegisterViewModel
    {
        public string AuthenticationType { get; set; }


        [Required(ErrorMessage ="Ange ett användarnamn.")]
        [Display(Name = "Användarnamn")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Ange en mailadress.")]
        [EmailAddress(ErrorMessage ="Ange en riktig mailadress.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ange ett lösenord.")]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        [AllowHtml]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekräfta lösenord.")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Lösenorden stämmer inte överrens.")]
        [AllowHtml]
        public string ConfirmPassword { get; set; }
    }

}
