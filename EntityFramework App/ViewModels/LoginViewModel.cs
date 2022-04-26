using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace EntityFramework_App.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="UserName can not be blank")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password can not be blank")]
        public string Password { get; set; }
    }
}