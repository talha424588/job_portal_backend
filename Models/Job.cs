using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    public class Job
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required]
        public long title { get; set; }

        [Required]
        public long description { get; set; }

        [Required]
        public ICollection<JobSkill> skills { get; set; }

        [Required]
        public string position { get; set; }

        [Required]
        public DateTime applicationDeadline { get; set; }

        [Required]
        public int noOfApplicant { get; set; }

        [Required]
        public string location { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string contactNo { get; set; }

        [Required]
        public long postImage { get; set; }

        public Guid employee_id { get; set; }

        public Employer employer { get; set; }

    }
}
