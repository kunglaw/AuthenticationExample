using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthenticationExample.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "FirstName is Required")]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "LastName is Required")]
        [Display(Name = "Last Name:" )]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required.")]
        [Display(Name = "Email : ")]
        public string Email { get; set;  }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password :")]
        public string Password { get; set;  }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm-password is required.")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and Confirm Password should be same ")]
        public string ConfirmPassword { get; set; }

        public DateTime Created_at { get; set; }

        public string SuccessMessage { get; set; }

    }
}