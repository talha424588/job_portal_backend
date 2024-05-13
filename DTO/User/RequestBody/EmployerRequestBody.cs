using JobPortal.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.DTO.User.RequestBody
{
    public class EmployerRequestBody
    {
        [Required(ErrorMessage = "company name required")]
        [StringLength(100)]
        public string companyName { get; set; }

        [Required(ErrorMessage = "photo required")]
        public string photo { get; set; }

        [Required(ErrorMessage = "city name required")]
        [StringLength(50,ErrorMessage = "city name must not be greater then 50 character")]
        public string city { get; set; }

        [Required(ErrorMessage = "state name required")]
        [StringLength(50, ErrorMessage = "state name must not be greater then 50 character")]
        public string state { get; set; }

        [Required(ErrorMessage = "country name required")]
        [StringLength(50, ErrorMessage = "country name must not be greater then 50 character")]
        public string country { get; set; }

        [Required(ErrorMessage = "company address required")]
        public string address { get; set; }
    }
}
