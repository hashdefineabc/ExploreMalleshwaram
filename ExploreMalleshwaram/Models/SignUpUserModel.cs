using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreMalleshwaram.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage ="Please enter your first name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Key]
        [Required(ErrorMessage ="Please enter your Email")]
        [Display(Name ="Email address")]
        [EmailAddress(ErrorMessage ="Please enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your Password")]
        [Compare("ConfirmPassword", ErrorMessage = "Password doesn't match")]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your Password")]
        [Display(Name = "" +
            "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
