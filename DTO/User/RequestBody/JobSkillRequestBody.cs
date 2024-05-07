using System.ComponentModel.DataAnnotations;

namespace JobPortal.DTO.User.RequestBody
{
    public class JobSkillRequestBody
    {
        [Required]
        public List<string> name { get; set; }
    }
}
