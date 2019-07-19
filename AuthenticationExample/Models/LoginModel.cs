using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace AuthenticationExample.Models
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email must be filled")]
        public string Email { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password must be filled")]
        public string Password { get; set; }
    }
}