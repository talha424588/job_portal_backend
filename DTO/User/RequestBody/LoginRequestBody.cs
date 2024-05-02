using System.ComponentModel.DataAnnotations;

namespace JobPortal.DTO.User.RequestBody
{
    public class LoginRequestBody
    {
        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

    }
}
