using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    public class Employer
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("company_name",TypeName="varchar(100)")]
        public string companyName { get; set; }

        [Required]
        [Column("photo", TypeName = "nvarchar(max)")]
        public string photo { get; set; }

        [Required]
        [StringLength(50)]
        [Column("city", TypeName = "varchar(50)")]
        public string city { get; set; }

        [Required]
        [StringLength(50)]
        [Column("state", TypeName = "varchar(50)")]
        public string state { get; set; }

        [Required]
        [StringLength(50)]
        [Column("country", TypeName = "varchar(50)")]
        public string country { get; set; }

        [Required]
        [Column("address", TypeName = "nvarchar(max)")]
        public string address { get; set; }

        [Required]
        public Guid userId { get; set; }
        public User user { get; set; }

        public ICollection<Job> Jobs { get; set; } = new List<Job>();

    }
}
