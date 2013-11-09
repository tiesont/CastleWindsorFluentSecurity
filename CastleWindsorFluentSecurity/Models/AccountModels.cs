using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CastleWindsorFluentSecurity.Models
{
    public class LoginModel
    {
        [Required, DataType(DataType.EmailAddress), Display(Name="Email address")]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Email address")]
        public string Password { get; set; }

        [Display(Name="Remember me")]
        public bool RememberMe { get; set; }
    }
}