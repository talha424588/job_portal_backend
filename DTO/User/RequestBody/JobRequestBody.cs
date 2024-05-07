using JobPortal.Models;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.DTO.User.RequestBody
{
    public class JobRequestBody
    {
        [Required(ErrorMessage = "job title required")]
        public long title { get; set; }
        [Required(ErrorMessage = "job description required")]
        public long description { get; set; }
        [Required(ErrorMessage = "job skills required")]
        public ICollection<JobSkillRequestBody> skills { get; set; }
        [Required(ErrorMessage = "job position required")]
        public string position { get; set; }
        [Required(ErrorMessage = "job application deadline required")]
        public DateTime applicationDeadline { get; set; }
        [Required]
        public int noOfApplicant { get; set; }
        [Required(ErrorMessage = "location required")]
        public string location { get; set; }
        [Required(ErrorMessage = "email required")]
        public string email { get; set; }
        [Required(ErrorMessage = "contact no required")]
        public string contactNo { get; set; }
        public long postImage { get; set; }

        [Required]
        public string jwt { get; set; }

    }
}
