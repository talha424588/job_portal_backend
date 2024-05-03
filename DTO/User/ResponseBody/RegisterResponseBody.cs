using System.ComponentModel.DataAnnotations;

namespace JobPortal.DTO.User.ResponseBody
{
    public class RegisterResponseBody
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string token { get; set; }
    }
}
