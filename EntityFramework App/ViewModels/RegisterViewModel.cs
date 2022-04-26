using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework_App.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Username can not be empty")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password can not be empty")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password can not be empty")]
        [Compare("Password",ErrorMessage ="Password and confirm password dont match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email can not be empty")]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }
        public string Mobile { get; set; }
       // public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }


    }
}