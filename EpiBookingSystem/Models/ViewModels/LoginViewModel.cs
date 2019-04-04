﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpiBookingSystem.Models.ViewModels
{
    public class LoginViewModel
    {

        public string AuthenticationType { get; set; }


        [Required]
        [Display(Name = "Användarnamn")]
        public string Username { get; set; }

        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        [AllowHtml]
        public string Password { get; set; }


    }
}