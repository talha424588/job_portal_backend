using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    public class User
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("first_name", TypeName = "varchar(100)")]
        public string firstName { get; set; }

        [Required]
        [StringLength(100)]
        [Column("last_name", TypeName = "varchar(100)")]
        public string lastName { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        [Column("email", TypeName = "varchar(100)")]
        public string email { get; set; }

        [Required]
        [StringLength(100)]
        [Column("password", TypeName = "varchar(100)")]
        public string password { get; set; }

        [Required]
        [StringLength(40)]
        [Column("city", TypeName = "varchar(40)")]
        public string city { get; set; }

        [Required]
        [StringLength(40)]
        [Column("state", TypeName = "varchar(40)")]
        public string state { get; set; }

        [Required]
        [StringLength(40)]
        public string country { get; set; }

        [Required]
        public Guid roleId { get; set; }

        public Role role { get; set; }

        public Employer employer { get; set; }

    }
}
