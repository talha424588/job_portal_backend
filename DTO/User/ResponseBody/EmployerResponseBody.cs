using System.ComponentModel.DataAnnotations;

namespace JobPortal.DTO.User.ResponseBody
{
    public class EmployerResponseBody
    {
        public string companyName { get; set; }

        public string photo { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string country { get; set; }

        public string address { get; set; }

        public Guid userId { get; set; }
    }
}
