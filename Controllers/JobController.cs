using JobPortal.DTO.User.RequestBody;
using JobPortal.DTO.User.ResponseBody;
using JobPortal.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobRepository jobRepository;

        public JobController(IJobRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }
        [HttpGet]
        [Authorize(Policy = "RequireAdminRole")]
        public Task<JobResponseBody> AddJob(JobRequestBody requestBody) 
        {
            return jobRepository.CreateJob(requestBody);
        }
    }
}
