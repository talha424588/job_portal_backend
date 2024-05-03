using JobPortal.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.DTO.User.RequestBody
{
    public class RegisterRequestBody
    {
        [Required(ErrorMessage = "Enter First Name")]
        [StringLength(100)]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Enter Last Name")]
        [StringLength(100)]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [StringLength(100)]
        [EmailAddress]
        public string email { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [StringLength(100)]
        public string password { get; set; }

        [Required(ErrorMessage = "Enter City Name")]
        [StringLength(40)]
        public string city { get; set; }

        [Required(ErrorMessage = "Enter State Name")]
        [StringLength(40)]

        public string state { get; set; }

        [Required(ErrorMessage = "Enter Country Name")]
        [StringLength(40)]
        public string country { get; set; }


    }
}
