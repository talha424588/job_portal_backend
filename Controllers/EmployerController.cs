using JobPortal.DTO.User.RequestBody;
using JobPortal.DTO.User.ResponseBody;
using JobPortal.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerRepository employerRepository;

        public EmployerController(IEmployerRepository employerRepository)
        {
            this.employerRepository = employerRepository;
        }

        [HttpPost("vendor/registration")]
        public Task<EmployerResponseBody> vendorRegistration(EmployerRequestBody requestBody)
        {
            return employerRepository.addEmployerCompany(requestBody);
        }
    }
}
